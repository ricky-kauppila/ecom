using System;
using System.Threading.Tasks;
using Ecom.Infrastructure.Commands;
using MassTransit;

namespace Ecom.Infrastructure.ServiceBus
{
    public class MassTransitCommandExecutor : ICommandExecutor
    {
        private readonly ISendEndpointProvider endpointProvider;
        public MassTransitCommandExecutor(ISendEndpointProvider endpointProvider)
        {
            this.endpointProvider = endpointProvider;
        }

        public async Task BeginExecute<T>(T command) where T : class, ICommand
        {
            var endpoint = await this.endpointProvider.GetSendEndpoint(new Uri("rabbitmq://localhost/ecom-create-product"));
            await endpoint.Send(message: command);
        }
    }
}