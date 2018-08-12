using System.Threading.Tasks;
using Ecom.Infrastructure.Commands;
using Ecom.Infrastructure.Events;
using Ecom.ProductManagement;
using Ecom.ProductManagement.Events;
using Ecom.ProductManagement.Repositories;

namespace Ecom.ProductManagement.Commands
{
    internal class ProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductFactory factory;
        private readonly IProductRepository repository;
        private readonly IEventPublisher eventPublisher;

        public ProductCommandHandler(
            IProductFactory productFactory,
            IProductRepository productRepository,
            IEventPublisher eventPublisher)
        {
            this.factory = productFactory;
            this.repository = productRepository;
            this.eventPublisher = eventPublisher;
        }
        public async Task Handle(CreateProductCommand command)
        {
            var product = this.factory.Create(command);
            await this.repository.Save(product);
            await this.eventPublisher.Publish(new ProductCreated(product.Id));
        }
    }
}