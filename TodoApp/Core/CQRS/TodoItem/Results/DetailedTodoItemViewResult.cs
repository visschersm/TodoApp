using MTech.TodoApp.ViewModel.TodoItem;
using MTech.Utilities.RequestHandler;

namespace MTech.TodoApp.TodoItem.Results
{
    public class DetailedTodoItemViewResult : IQueryResult
    {
        public bool Successfull { get; set; }
        public DetailedView? Data { get; set; }
    }
}