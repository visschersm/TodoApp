using MTech.Utilities.RequestHandler;

namespace MTech.TodoApp.TodoItem.Results
{
    public class TodoItemListViewResult<TView> : IQueryResult
    {
        public bool Successfull { get; set; }
        public TView[] Data { get; internal set; } = null!;
    }
}
