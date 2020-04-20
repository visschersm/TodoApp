using Microsoft.EntityFrameworkCore;
using MTech.TodoApp.CQRS.TodoItem.Results;
using MTech.TodoApp.DataModel.Interfaces;
using MTech.Utilities.RequestHandler;
using MTech.Utilities.ViewModel;
using System.Threading.Tasks;

namespace MTech.TodoApp.CQRS.TodoItem.Requests
{
    public class GetAllTodoItemsRequest : IQueryRequest
    {
        public class GetAllTodoItemsRequestHandler
            : IQueryHandler<GetAllTodoItemsRequest, TodoItemListViewResult>
        {
            private readonly ITodoContext _context;
            private readonly DbSet<Entities.TodoItem> _repository;

            public GetAllTodoItemsRequestHandler(ITodoContext context)
            {
                _context = context;
                _repository = _context.Set<Entities.TodoItem>();
            }

            public async Task<TodoItemListViewResult> HandleAsync(
                GetAllTodoItemsRequest request)
            {
                var result = await _repository.AsNoTracking()
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