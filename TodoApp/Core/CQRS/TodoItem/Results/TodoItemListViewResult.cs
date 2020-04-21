using MTech.Utilities.RequestHandler;

namespace MTech.TodoApp.CQRS.TodoItem.Results
{
    public class TodoItemListViewResult : IQueryResult
    {
        public bool Successfull { get; set; }
        public ViewModel.TodoItem.ListView[] Data { get; set; } = null!;
    }
}
