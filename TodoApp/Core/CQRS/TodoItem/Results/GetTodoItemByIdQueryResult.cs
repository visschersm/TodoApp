using MTech.TodoApp.ViewModel.TodoItem;
using MTech.Utilities.RequestHandler;

namespace MTech.TodoApp.CQRS.Results
{
    public class GetTodoItemByIdQueryResult : IQueryResult
    {
        public bool Successfull { get; set; }
        public DetailedView Data { get; internal set; } = null!;
    }
}
