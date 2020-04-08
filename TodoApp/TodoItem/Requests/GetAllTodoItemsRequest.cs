using System;
using MTech.RequestHandler;
using System.Threading.Tasks;
using MTech.TodoApp.TodoItem.Results;
using MTech.TodoApp.DataModel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MTech.TodoApp.ViewModel.TodoItem;
using MTech.TodoApp.ViewModel;

namespace MTech.TodoApp.TodoItem.Requests
{
    public class GetAllTodoItemsRequest : IQueryRequest
    {
        internal class GetAllTodoItemsRequestHandler : IQueryHandler<GetAllTodoItemsRequest, TodoItemListViewResult>
        {
            private readonly ITodoContext _context;
            private readonly DbSet<Entities.TodoItem> _repository;

            public GetAllTodoItemsRequestHandler(ITodoContext context)
            {
                _context = context;
                _repository = _context.Set<Entities.TodoItem>();
            }

            public async Task<TodoItemListViewResult> Handle(GetAllTodoItemsRequest request)
            {
                var result = await _repository.AsNoTracking()
                    .ProjectTo<Entities.TodoItem, TodoItemListView>()
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