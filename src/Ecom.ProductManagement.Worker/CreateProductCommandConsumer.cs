using System.Threading.Tasks;
using Ecom.Infrastructure.Commands;
using Ecom.ProductManagement.Commands;
using MassTransit;

namespace Ecom.ProductManagement.Worker
{
    public class CreateProductCommandConsumer : IConsumer<ICreateProductCommand>
    {
        private readonly ICommandHandler<ICreateProductCommand> commandHandler;

        public CreateProductCommandConsumer(ICommandHandler<ICreateProductCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
        }

        public async Task Consume(ConsumeContext<ICreateProductCommand> context)
        {
            await this.commandHandler.Handle(context.Message);    
        }
    }
}