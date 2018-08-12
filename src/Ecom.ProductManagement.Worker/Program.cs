using System;
using Ecom.Infrastructure.ServiceBus;
using Ecom.ProductManagement.Commands;
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

                sbc.ReceiveEndpoint(host, "test_queue", ep =>
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

            bus.Publish(message: new CreateProductCommand(Guid.NewGuid(), "ABC123"));

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();
        }

        public class CreateProductCommand : ICreateProductCommand
        {
            public CreateProductCommand(Guid id, string articleNumber)
            {
                this.Id = id;
                this.ArticleNumber = articleNumber;

            }
            public Guid Id { get; }

            public string ArticleNumber { get; }
        }
    }
}