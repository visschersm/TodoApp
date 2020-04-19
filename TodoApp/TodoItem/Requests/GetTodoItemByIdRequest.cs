using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System;
using MTech.RequestHandler; 
using MTech.TodoApp.TodoItem.Results;
using MTech.TodoApp.DataModel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ViewModel = MTech.TodoApp.ViewModel;
using MTech.TodoApp.ViewModel;

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
                _repository = context.Set<Entities.TodoItem>();
            }
            public async Task<DetailedTodoItemViewResult> Handle(GetTodoItemByIdRequest request)
            {
                var result = await _repository.AsNoTracking()
                    .Where(x => x.Id == request.Id)
                    .ProjectTo<Entities.TodoItem, ViewModel.TodoItem.DetailedView>()
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