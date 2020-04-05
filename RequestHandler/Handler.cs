using System.Threading.Tasks;
using System;
namespace MTech.RequestHandler
{
    public class Handler : IHandler
    {
        public Task<IRequestResult> Handle(IRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ICommandResult> Handle(ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}