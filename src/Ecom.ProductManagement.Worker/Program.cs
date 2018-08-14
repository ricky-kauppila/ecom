using System;
using Ecom.Infrastructure.ServiceBus;
using Ecom.ProductManagement.Commands;
using Ecom.ProductManagement.Database;
using MassTransit;

namespace Ecom.ProductManagement.Worker
{
    class Program
    {
        private static IBusControl bus;

        static void Main(string[] args)
        {
            bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                sbc.ReceiveEndpoint(host, "ecom-create-product", ep =>
                {
                    ep.Consumer(() =>
                        new CreateProductCommandConsumer(
                            new ProductCommandHandler(
                                new ProductFactory(),
                                new ProductRepository(),
                                new MassTransitEventPublisher(bus))
                        ));
                });
            });

            bus.Start();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();
        }
    }
}