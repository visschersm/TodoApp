using Microsoft.EntityFrameworkCore;
using MTech.TodoApp.CQRS.Results;
using MTech.TodoApp.DataModel.Interfaces;
using MTech.Utilities.RequestHandler;
using MTech.Utilities.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace MTech.TodoApp.CQRS.Requests
{
    public class GetAllTodoItemsQuery : IQueryRequest
    {
        internal readonly int _parentId;

        public GetAllTodoItemsQuery(int parentId)
        {
            _parentId = parentId;
        }

        public class GetAllTodoItemsQueryHandler
            : IQueryHandler<GetAllTodoItemsQuery, TodoItemListViewResult>
        {
            private readonly ITodoContext _context;
            private readonly DbSet<Entities.TodoItem> _repository;

            public GetAllTodoItemsQueryHandler(ITodoContext context)
            {
                _context = context;
                _repository = _context.Set<Entities.TodoItem>();
            }

            public async Task<TodoItemListViewResult> Handle(
                GetAllTodoItemsQuery request)
            {
                var result = await _repository.AsNoTracking()
                    .Where(x => x.ParentId == request._parentId)
                    .ProjectTo<Entities.TodoItem, ViewModel.TodoItem.ListView>()
                    .ToArrayAsync();

                return new TodoItemListViewResult
                {
                    Successfull = true,
                    Data = result
                };
            }
        }
    }
}