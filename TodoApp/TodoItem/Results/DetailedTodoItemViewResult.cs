using MTech.RequestHandler;
using MTech.TodoApp.ViewModel.TodoItem;

namespace MTech.TodoApp.TodoItem.Results
{
    public class DetailedTodoItemViewResult : IQueryResult
    {
        public bool Succesfull { get; set; }
        public DetailedTodoItemView Data { get; set; }
    }
}