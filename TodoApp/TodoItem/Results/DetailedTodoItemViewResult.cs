using MTech.RequestHandler;
using MTech.TodoApp.ViewModel.TodoItem;

namespace MTech.TodoApp.TodoItem.Results
{
    public class DetailedTodoItemViewResult : IQueryResult
    {
        public bool Successfull { get; set; }
        public DetailedTodoItemView Data { get; set; }
    }
}