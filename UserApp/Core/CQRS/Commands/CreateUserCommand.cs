using System.Threading.Tasks;
using MTech.UserApp.User.Results;

namespace MTech.UserApp.User.Commands
{
    public class CreateUserCommand : ICommandRequest
    {
        internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, CreateUserCommandResult>
        {
            public Task<CreateUserCommandResult> Handle(CreateUserCommand request)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}