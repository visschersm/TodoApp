using System;
using MTech.RequestHandler;
using System.Threading.Tasks;
using MTech.TodoApp.TodoItem.Results;
using MTech.TodoApp.DataModel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MTech.TodoApp.ViewModel.TodoItem;
using MTech.TodoApp.ViewModel;
using MTech.TodoApp.Entities;

namespace MTech.TodoApp.TodoItem.Requests
{
    public class GetAllTodoItemsRequest<TView> : IQueryRequest
        where TView : IViewOf<Entities.TodoItem>
    {
        internal class GetAllTodoItemsRequestHandler 
            : IQueryHandler<GetAllTodoItemsRequest<TView>, TodoItemListViewResult<TView>>
        {
            private readonly ITodoContext _context;
            private readonly DbSet<Entities.TodoItem> _repository;

            public GetAllTodoItemsRequestHandler(ITodoContext context)
            {
                _context = context;
                _repository = _context.Set<Entities.TodoItem>();
            }

            public async Task<TodoItemListViewResult<TView>> Handle(GetAllTodoItemsRequest<TView> request)
            {
                var result = await _repository.AsNoTracking()
                    .ProjectTo<Entities.TodoItem, TView>()
                    .ToArrayAsync();

                return new TodoItemListViewResult<TView>
                {
                    Successfull = true,
                    Data = result
                };
            }
        }
    }
}