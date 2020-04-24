using Microsoft.EntityFrameworkCore;
using MTech.TodoApp.CQRS.Results;
using MTech.TodoApp.DataModel.Interfaces;
using MTech.Utilities.RequestHandler;
using MTech.Utilities.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace MTech.TodoApp.CQRS.Queries
{
    public class GetTodoItemByIdQuery : IQueryRequest
    {
        private readonly int _parentId;
        private readonly int _id;

        public GetTodoItemByIdQuery(int parentId, int id)
        {
            _parentId = parentId;
            _id = id;
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
                var result = await _context.TodoLists.AsNoTracking()
                    .Where(x => x.Id == request._parentId)
                    .SelectMany(x => x.TodoItems)
                    .Where(x => x.Id == request._id)
                    .ProjectTo<Entities.TodoItem, ViewModel.TodoItem.DetailedView>()
                    .SingleOrDefaultAsync();

                if (result == null)
                    return new GetTodoItemByIdQueryResult { Successfull = false };

                return new GetTodoItemByIdQueryResult
                {
                    Successfull = true,
                    Data = result
                };
            }
        }
    }
}
