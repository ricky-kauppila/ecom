using System.Threading.Tasks;
using Ecom.Infrastructure.Commands;
using Ecom.Infrastructure.Events;
using MassTransit;

namespace Ecom.Infrastructure.ServiceBus
{
    public class MassTransitEventPublisher : IEventPublisher, ICommandExecutor
    {
        private readonly IBusControl bus;

        public MassTransitEventPublisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task BeginExecute<T>(T command) where T : class, ICommand
        {
            await bus.Publish(message: command);
        }

        public async Task Publish<T>(T @event) where T : class, IEvent
        {
            await bus.Publish(message: @event);
        }
    }
}