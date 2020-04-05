using MTech.RequestHandler;
using MTech.TodoApp.TodoItem.Results;
using System.Threading.Tasks;

namespace MTech.TodoApp.TodoItem.Requests
{
    public class GetAllTodoItemsRequest : IRequest
    {
        internal class GetAllTodoItemsRequestHandler
            : IQueryHandler<GetAllTodoItemsRequest, TodoItemListViewResult>
        {
            public GetAllTodoItemsRequestHandler()
            {
            }

            public Task<TodoItemListViewResult> HandleAsync(GetAllTodoItemsRequest request)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}