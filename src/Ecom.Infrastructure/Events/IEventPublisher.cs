using System.Threading.Tasks;

namespace Ecom.Infrastructure.Events
{
    public interface IEventPublisher
    {
        Task Publish<T>(T @event) where T : class, IEvent;
    }
}