using System;
using Ecom.Infrastructure.Commands;

namespace Ecom.ProductManagement.Commands
{
    public class CreateProductCommand : ICommand
    {

        public CreateProductCommand(Guid id, string articleNumber)
        {
            this.Id = id;
            this.ArticleNumber = articleNumber;

        }
        public Guid Id { get; set; }

        public string ArticleNumber { get; }
    }
}