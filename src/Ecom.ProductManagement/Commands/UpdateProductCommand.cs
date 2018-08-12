using System;
using Ecom.Infrastructure.Commands;

namespace Ecom.ProductManagement.Commands
{
    public class UpdateProductCommand : ICommand
    {
        public UpdateProductCommand(Guid id, string articleNumber)
        {
            this.Id = id;
            this.ArticleNumber = articleNumber;
        }

        public Guid Id { get; }
        public string ArticleNumber { get; }
    }
}