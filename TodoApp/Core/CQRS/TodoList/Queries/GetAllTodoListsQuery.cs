using Microsoft.EntityFrameworkCore;
using MTech.TodoApp.CQRS.Results;
using MTech.TodoApp.DataModel.Interfaces;
using MTech.Utilities.RequestHandler;
using MTech.Utilities.ViewModel;
using System.Threading.Tasks;

namespace MTech.TodoApp.CQRS.Queries
{
    public class GetAllTodoListsQuery : IQueryRequest
    {
        public class GetAllTodoListsQueryHandler
            : IQueryHandler<GetAllTodoListsQuery, TodoListsListViewQueryResult>
        {
            private readonly ITodoContext _context;
            private readonly DbSet<Entities.TodoList> _repository;

            public GetAllTodoListsQueryHandler(ITodoContext context)
            {
                _context = context;
                _repository = _context.Set<Entities.TodoList>();
            }

            public async Task<TodoListsListViewQueryResult> Handle(
                GetAllTodoListsQuery request)
            {
                var result = await _repository.AsNoTracking()
                    .ProjectTo<Entities.TodoList, ViewModel.TodoList.ListView>()
                    .ToArrayAsync();

                return new TodoListsListViewQueryResult
                {
                    Successfull = true,
                    Data = result
                };
            }
        }
    }
}
