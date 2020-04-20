using Microsoft.EntityFrameworkCore;
using MTech.TodoApp.DataModel.Interfaces;
using MTech.TodoApp.TodoItem.Results;
using MTech.TodoApp.ViewModel.TodoItem;
using MTech.Utilities.RequestHandler;
using MTech.Utilities.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace MTech.TodoApp.TodoItem.Requests
{
    public class GetTodoItemByIdRequest : IQueryRequest
    {
        public int Id { get; private set; }
        public GetTodoItemByIdRequest(int id)
        {
            Id = id;
        }

        internal class GetTodoItemByIdRequestHandler : IQueryHandler<GetTodoItemByIdRequest, DetailedTodoItemViewResult>
        {
            private readonly ITodoContext _context;
            private readonly DbSet<Entities.TodoItem> _repository;

            public GetTodoItemByIdRequestHandler(ITodoContext context)
            {
                _context = context;
                _repository = _context.Set<Entities.TodoItem>();
            }
            public async Task<DetailedTodoItemViewResult> Handle(GetTodoItemByIdRequest request)
            {
                var result = await _repository.AsNoTracking()
                    .Where(x => x.Id == request.Id)
                    .ProjectTo<Entities.TodoItem, DetailedView>()
                    .SingleOrDefaultAsync();

                return new DetailedTodoItemViewResult
                {
                    Successfull = true,
                    Data = result
                };
            }
        }
    }
}