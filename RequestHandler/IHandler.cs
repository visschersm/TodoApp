using System;

namespace MTech.RequestHandler
{
    public interface IHandler
    {
        IRequestResult Handle(IRequest request);
        ICommandResult Handle(ICommand command);
    }
}
