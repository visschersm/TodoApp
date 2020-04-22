using Microsoft.EntityFrameworkCore;
using MTech.TodoApp.CQRS.Results;
using MTech.TodoApp.DataModel.Interfaces;
using MTech.Utilities.RequestHandler;
using MTech.Utilities.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace MTech.TodoApp.CQRS.Queries
{
    public class GetTodoListByIdQuery : IQueryRequest
    {
        public GetTodoListByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

        public class GetTodoListByIdQueryHandler : IQueryHandler<GetTodoListByIdQuery, GetTodoListByIdQueryResult>
        {
            private readonly ITodoContext _context;

            public GetTodoListByIdQueryHandler(ITodoContext context)
            {
                _context = context;
            }

            public async Task<GetTodoListByIdQueryResult> Handle(GetTodoListByIdQuery request)
            {
                var result = await _context.TodoLists.AsNoTracking()
                    .Where(x => x.Id == request.Id)
                    .ProjectTo<Entities.TodoList, ViewModel.TodoList.ListView>()
                    .SingleOrDefaultAsync();

                return new GetTodoListByIdQueryResult
                {
                    Successfull = true,
                    Data = result
                };
            }
        }
    }
}
