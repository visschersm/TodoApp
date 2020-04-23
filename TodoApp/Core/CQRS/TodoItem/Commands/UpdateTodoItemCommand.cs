using Microsoft.EntityFrameworkCore;
using MTech.TodoApp.CQRS.Results;
using MTech.TodoApp.DataModel.Interfaces;
using MTech.Utilities.RequestHandler;
using System.Linq;
using System.Threading.Tasks;

namespace MTech.TodoApp.CQRS.Commands
{
    public class UpdateTodoItemCommand : ICommandRequest
    {
        public int Id { get; set; }
        public ViewModel.TodoItem.UpdateView UpdateView { get; set; }

        public UpdateTodoItemCommand(int id, ViewModel.TodoItem.UpdateView updateView)
        {
            Id = id;
            UpdateView = updateView;
        }

        public class UpdateTodoItemCommandHandler : ICommandHandler<UpdateTodoItemCommand, UpdateTodoItemCommandResult>
        {
            private readonly ITodoContext _context;

            public UpdateTodoItemCommandHandler(ITodoContext context)
            {
                _context = context;
            }

            public async Task<UpdateTodoItemCommandResult> Handle(UpdateTodoItemCommand request)
            {
                var item = await _context.TodoItems.Where(x => x.Id == request.Id)
                    .SingleOrDefaultAsync();

                item.Title = request.UpdateView.Title;
                item.Priority = request.UpdateView.Priority;
                item.DueDate = request.UpdateView.DueDate;
                item.Note = request.UpdateView.Note;

                await _context.SaveChangesAsync();

                return new UpdateTodoItemCommandResult
                {
                    Successfull = true,
                    Data = new ViewModel.TodoItem.ListView
                    {
                        Title = item.Title,
                        Priority = item.Priority,
                        Status = item.Status,
                        DueDate = item.DueDate,
                    }
                };
            }
        }
    }
}
