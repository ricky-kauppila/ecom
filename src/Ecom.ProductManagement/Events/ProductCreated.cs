using System;
using Ecom.Infrastructure.Events;

namespace Ecom.ProductManagement.Events
{
    public class ProductCreated : IEvent
    {
        internal ProductCreated(Guid id)
        {
            this.Id = id;

        }
        public Guid Id { get; }
    }
}