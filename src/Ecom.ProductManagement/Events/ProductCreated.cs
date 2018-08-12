using System;
using Ecom.Infrastructure.Events;

namespace Ecom.ProductManagement.Events
{
    public class ProductCreated : IEvent
    {
        public ProductCreated(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; }
    }
}