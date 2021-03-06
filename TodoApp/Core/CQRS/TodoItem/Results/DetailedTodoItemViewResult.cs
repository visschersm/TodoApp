using MTech.TodoApp.ViewModel.TodoItem;
using MTech.Utilities.RequestHandler;

namespace MTech.TodoApp.CQRS.Results
{
    public class DetailedTodoItemViewResult : IQueryResult
    {
        public bool Successfull { get; set; }
        public DetailedView Data { get; set; } = null!;
    }
}