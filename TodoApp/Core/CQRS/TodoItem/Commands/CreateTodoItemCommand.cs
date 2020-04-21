using MTech.TodoApp.CQRS.Results;
using MTech.TodoApp.DataModel.Interfaces;
using MTech.TodoApp.ViewModel.TodoItem;
using MTech.Utilities.RequestHandler;
using System.Linq;
using System.Threading.Tasks;

namespace MTech.TodoApp.CQRS.Commands
{
    public class CreateTodoItemCommand : BaseTodoCommand
    {
        public int ParentId { get; }

        public readonly CreateView CreateView;

        public CreateTodoItemCommand(int parentId, ViewModel.TodoItem.CreateView toCreate)
        {
            ParentId = parentId;
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
                    ParentId = request.ParentId,
                    Title = request.CreateView.Title
                };

                var list = _context.TodoLists.SingleOrDefault(x => x.Id == request.ParentId);
                if (list == null)
                    return new CreateTodoItemCommandResult { Successfull = false };

                //var entity = _context.TodoItems.Add(toCreate).Entity;
                list!.TodoItems.Add(toCreate);

                await _context.SaveChangesAsync();

                return new CreateTodoItemCommandResult
                {
                    Successfull = true,
                    Data = new CreatedView
                    {
                        Title = toCreate.Title
                    }
                };
            }
        }
    }
}