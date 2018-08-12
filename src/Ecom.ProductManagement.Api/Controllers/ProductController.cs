using System;
using System.Threading.Tasks;
using Ecom.Infrastructure.Commands;
using Ecom.ProductManagement.Api.Models;
using Ecom.ProductManagement.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.ProductManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICommandExecutor commandPublisher;

        public ProductController(ICommandExecutor commandPublisher)
        {
            this.commandPublisher = commandPublisher;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductModel model)
        {
            await commandPublisher.BeginExecute(new CreateProductCommand(Guid.NewGuid(), model.ArticleNumber));
            return Accepted($"api/product/{model.ArticleNumber}");
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductModel model)
        {
            await commandPublisher.BeginExecute(new UpdateProductCommand(model.Id, model.ArticleNumber));
            return Accepted($"api/product/{model.ArticleNumber}");
        }

        [HttpGet("{articleNumber}")]
        public async Task<IActionResult> Get(string articleNumber)
        {
            return await Task.FromResult(NotFound());
        }
    }
}