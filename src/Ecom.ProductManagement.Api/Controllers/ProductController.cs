using System;
using System.Threading.Tasks;
using Ecom.Infrastructure.Commands;
using Ecom.Infrastructure.ServiceBus;
using Ecom.ProductManagement.Api.Models;
using Ecom.ProductManagement.Commands;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.ProductManagement.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static IBusControl bus;

        static ProductController()
        {
            bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });

            bus.Start();
        }

        private readonly ICommandExecutor commandPublisher;

        public ProductController()
        {
            this.commandPublisher = new MassTransitCommandExecutor(bus);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductModel model)
        {
            await commandPublisher.BeginExecute<ICreateProductCommand>(new CreateProductCommand(Guid.NewGuid(), model.ArticleNumber));
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
            return await Task.FromResult(Content("Hello world"));
        }
    }
}