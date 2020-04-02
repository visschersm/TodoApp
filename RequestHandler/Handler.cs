using System;
namespace MTech.RequestHandler
{
    public class Handler : IHandler
    {
        public IRequestResult Handle(IRequest request)
        {
            throw new NotImplementedException();
        }

        public ICommandResult Handle(ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}