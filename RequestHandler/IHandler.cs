using System.Threading.Tasks;

namespace MTech.RequestHandler
{
    public interface IHandler
    {
        Task<IRequestResult> Handle(IRequest request);
        Task<ICommandResult> Handle(ICommand command);
    }
}
