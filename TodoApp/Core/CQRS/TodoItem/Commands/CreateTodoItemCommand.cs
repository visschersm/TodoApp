using MTech.TodoApp.CQRS.TodoItem.Results;
using MTech.TodoApp.DataModel.Interfaces;
using MTech.TodoApp.ViewModel.TodoItem;
using MTech.Utilities.RequestHandler;
using System.Threading.Tasks;

namespace MTech.TodoApp.CQRS.TodoItem.Commands
{
    public class CreateTodoItemCommand : BaseTodoCommand
    {
        public readonly CreateView CreateView;

        public CreateTodoItemCommand(ViewModel.TodoItem.CreateView toCreate)
        {
            CreateView = toCreate;
        }

        internal class CreateTodoItemCommandHandler : ICommandHandler<CreateTodoItemCommand, CreateTodoItemCommandResult>
        {
            private readonly ITodoContext _context;

            public CreateTodoItemCommandHandler(ITodoContext context)
            {
                _context = context;
            }

            public async Task<CreateTodoItemCommandResult> Handle(CreateTodoItemCommand request)
            {
                var toCreate = new Entities.TodoItem
                {
                    Title = request.CreateView.Title
                };

                var entity = _context.TodoItems.Add(toCreate).Entity;

                await _context.SaveChangesAsync();

                return new CreateTodoItemCommandResult
                {
                    Successfull = true,
                    Data = new CreatedView
                    {
                        Title = entity.Title
                    }
                };
            }
        }
    }
}