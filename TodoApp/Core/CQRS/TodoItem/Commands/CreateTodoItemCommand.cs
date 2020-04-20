using MTech.TodoApp.TodoItem.Results;
using MTech.Utilities.RequestHandler;
using System.Threading.Tasks;

namespace MTech.TodoApp.TodoItem.Commands
{
    public class CreateTodoItemCommand : ICommandRequest
    {
        public CreateTodoItemCommand(ViewModel.TodoItem.CreateView toCreate)
        {

        }

        internal class CreateTodoItemCommandHandler : ICommandHandler<CreateTodoItemCommand, CreateTodoItemCommandResult>
        {
            public Task<CreateTodoItemCommandResult> Handle(CreateTodoItemCommand request)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}