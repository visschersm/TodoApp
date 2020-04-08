using System.Threading.Tasks;
using MTech.RequestHandler;
using MTech.TodoApp.TodoItem.Results;

namespace MTech.TodoApp.TodoItem.Commands
{
    public class CreateTodoItemCommand : ICommandRequest
    {
        public CreateTodoItemCommand(MTech.TodoApp.ViewModel.TodoItem.CreateView toCreate)
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