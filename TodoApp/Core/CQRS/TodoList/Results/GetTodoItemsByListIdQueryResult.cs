using MTech.TodoApp.ViewModel.TodoItem;
using MTech.Utilities.RequestHandler;

namespace MTech.TodoApp.CQRS.Results
{
    public class GetTodoItemsByListIdQueryResult : IQueryResult
    {
        public bool Successfull { get; set; }
        public ListView[] Data { get; internal set; } = null!;
    }
}
