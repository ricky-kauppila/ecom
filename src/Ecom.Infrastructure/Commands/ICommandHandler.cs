using System.Threading.Tasks;

namespace Ecom.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task Handle(T command);
    }
}