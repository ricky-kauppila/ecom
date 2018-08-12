using System;
using Ecom.Infrastructure.Commands;

public interface IUpdateProductCommand : ICommand
{
    Guid Id { get; }

    string ArticleNumber { get; }
}