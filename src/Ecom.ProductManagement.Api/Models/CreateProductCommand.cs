using System;
using Ecom.ProductManagement.Commands;

namespace Ecom.ProductManagement.Api.Controllers
{
    internal class CreateProductCommand : ICreateProductCommand
    {
        public CreateProductCommand(Guid id, string articleNumber)
        {
            this.Id = id;
            this.ArticleNumber = articleNumber;
        }

        public Guid Id { get; }
        public string ArticleNumber { get; }
    }
}