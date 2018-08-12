using System.Threading.Tasks;

namespace Ecom.Infrastructure.Commands
{
    public interface ICommandExecutor
    {
        Task BeginExecute<T>(T command) where T : ICommand;
    }
}