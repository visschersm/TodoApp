using Microsoft.EntityFrameworkCore;
using MTech.TodoApp.CQRS.Results;
using MTech.TodoApp.DataModel.Interfaces;
using MTech.Utilities.RequestHandler;
using MTech.Utilities.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace MTech.TodoApp.CQRS.Queries
{
    public class GetTodoItemsByListIdQuery : IQueryRequest
    {
        private readonly int id;

        public GetTodoItemsByListIdQuery(int id)
        {
            this.id = id;
        }

        public class GetTodoItemsByListIdQueryHandler : IQueryHandler<GetTodoItemsByListIdQuery, GetTodoItemsByListIdQueryResult>
        {
            private readonly ITodoContext _context;

            public GetTodoItemsByListIdQueryHandler(ITodoContext context)
            {
                _context = context;
            }

            public async Task<GetTodoItemsByListIdQueryResult> Handle(GetTodoItemsByListIdQuery request)
            {
                var result = await _context.TodoLists.AsNoTracking()
                    .Where(x => x.Id == request.id)
                    .SelectMany(x => x.TodoItems)
                    .ProjectTo<Entities.TodoItem, ViewModel.TodoItem.ListView>()
                    .ToArrayAsync();

                return new GetTodoItemsByListIdQueryResult
                {
                    Successfull = true,
                    Data = result
                };
            }
        }
    }
}
