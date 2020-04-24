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
        private readonly int _parentId;
        private readonly int _id;

        public ViewModel.TodoItem.UpdateView UpdateView { get; set; }

        public UpdateTodoItemCommand(int parentId, int id, ViewModel.TodoItem.UpdateView updateView)
        {
            _parentId = parentId;
            _id = id;

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
                var item = await _context.TodoLists
                    .Where(x => x.Id == request._parentId)
                    .SelectMany(x => x.TodoItems)
                    .Where(x => x.Id == request._id)
                    .SingleOrDefaultAsync();

                item.Title = request.UpdateView.Title;
                item.Priority = request.UpdateView.Priority;
                item.DueDate = request.UpdateView.DueDate;
                item.Note = request.UpdateView.Note;
                //item.Status = request.UpdateView.Status;

                await _context.SaveChangesAsync();

                return new UpdateTodoItemCommandResult
                {
                    Successfull = true,
                    Data = new ViewModel.TodoItem.ListView
                    {
                        Title = item.Title,
                        Priority = item.Priority,
                        Status = item.TodoStatus,
                        DueDate = item.DueDate,
                    }
                };
            }
        }
    }
}
