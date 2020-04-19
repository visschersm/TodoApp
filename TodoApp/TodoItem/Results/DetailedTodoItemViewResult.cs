using MTech.RequestHandler;
using ViewModel = MTech.TodoApp.ViewModel;

namespace MTech.TodoApp.TodoItem.Results
{
    public class DetailedTodoItemViewResult : IQueryResult
    {
        public bool Successfull { get; set; }
        public ViewModel.TodoItem.DetailedView Data { get; set; }
    }
}