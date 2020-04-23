using Microsoft.EntityFrameworkCore;
using MTech.TodoApp.CQRS.Results;
using MTech.TodoApp.DataModel.Interfaces;
using MTech.Utilities.RequestHandler;
using System.Linq;
using System.Threading.Tasks;

namespace MTech.TodoApp.CQRS.Queries
{
    public class GetTodoItemByIdQuery : IQueryRequest
    {
        private readonly int id;

        public GetTodoItemByIdQuery(int id)
        {
            this.id = id;
        }

        public class GetTodoItemByIdQueryHandler : IQueryHandler<GetTodoItemByIdQuery, GetTodoItemByIdQueryResult>
        {
            private readonly ITodoContext _context;

            public GetTodoItemByIdQueryHandler(ITodoContext context)
            {
                _context = context;
            }

            public async Task<GetTodoItemByIdQueryResult> Handle(GetTodoItemByIdQuery request)
            {
                var result = await _context.TodoItems.Where(x => x.Id == request.id)
                    .SingleOrDefaultAsync();

                if (result == null)
                    return new GetTodoItemByIdQueryResult { Successfull = false };

                return new GetTodoItemByIdQueryResult
                {
                    Successfull = true,
                    Data = new ViewModel.TodoItem.DetailedView
                    {

                    }
                };
            }
        }
    }
}
