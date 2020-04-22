using MTech.TodoApp.CQRS.Results;
using MTech.TodoApp.DataModel.Interfaces;
using MTech.TodoApp.ViewModel.TodoList;
using MTech.Utilities.RequestHandler;
using System.Drawing;
using System.Threading.Tasks;

namespace MTech.TodoApp.CQRS.Commands
{
    public class CreateTodoListCommand : ICommandRequest
    {
        internal readonly CreateView _toCreate;

        public CreateTodoListCommand(CreateView toCreate)
        {
            _toCreate = toCreate;
        }

        internal class CreateTodoListCommandHandler : ICommandHandler<CreateTodoListCommand, CreateTodoListCommandResult>
        {
            private readonly ITodoContext _context;

            public CreateTodoListCommandHandler(ITodoContext context)
            {
                _context = context;
            }

            public async Task<CreateTodoListCommandResult> Handle(CreateTodoListCommand request)
            {
                var color = System.Drawing.ColorTranslator.FromHtml(request._toCreate.LabelColor);
                color = Color.FromArgb(color.R, color.G, color.B);

                var newEntity = _context.TodoLists.Add(new Entities.TodoList
                {
                    Title = request._toCreate.Title,
                    LabelColor = color
                }).Entity;

                await _context.SaveChangesAsync();

                return new CreateTodoListCommandResult
                {
                    Successfull = true,
                    Data = new CreatedView
                    {
                        Title = newEntity.Title
                    }
                };
            }
        }
    }
}
