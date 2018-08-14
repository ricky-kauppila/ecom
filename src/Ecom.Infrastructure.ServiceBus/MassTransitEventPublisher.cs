using System.Threading.Tasks;
using Ecom.Infrastructure.Commands;
using Ecom.Infrastructure.Events;
using MassTransit;

namespace Ecom.Infrastructure.ServiceBus
{
    public class MassTransitEventPublisher : IEventPublisher
    {
        private readonly IPublishEndpoint endpoint;

        public MassTransitEventPublisher(IPublishEndpoint endpoint)
        {
            this.endpoint = endpoint;
        }

        public async Task Publish<T>(T @event) where T : class, IEvent
        {
            await this.endpoint.Publish(message: @event);
        }
    }
}