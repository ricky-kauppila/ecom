using System;
using Ecom.Infrastructure.Events;

namespace Ecom.ProductManagement.Events
{
    public interface IProductCreated : IEvent
    {
        Guid Id { get; }         
    }
}