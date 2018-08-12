using System;
using Ecom.Infrastructure.Commands;

namespace Ecom.ProductManagement.Commands
{
    public interface ICreateProductCommand : ICommand
    {
        Guid Id { get; }

        string ArticleNumber { get; }
    }
}