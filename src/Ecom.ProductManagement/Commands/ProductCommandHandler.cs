using System.Threading.Tasks;
using Ecom.Infrastructure.Commands;
using Ecom.Infrastructure.Events;
using Ecom.ProductManagement;
using Ecom.ProductManagement.Repositories;
using Ecom.ProductManagement.Events;

namespace Ecom.ProductManagement.Commands
{
    internal class ProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductFactory productFactory;

        private readonly IProductRepository repository;

        private readonly IEventPublisher eventPublisher;

        public async Task Handle(CreateProductCommand command)
        {
            var product = this.productFactory.Create(command);
            await this.repository.Save(product);
            await this.eventPublisher.Publish(new ProductCreated(product.Id));
        }
    }
}