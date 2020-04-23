using MTech.Utilities.RequestHandler;

namespace MTech.TodoApp.CQRS.Results
{
    public class UpdateTodoItemCommandResult : ICommandResult
    {
        public bool Successfull { get; set; }
        public ViewModel.TodoItem.ListView Data { get; set; } = null!;
    }
}
