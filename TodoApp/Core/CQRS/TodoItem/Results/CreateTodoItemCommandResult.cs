using MTech.Utilities.RequestHandler;

namespace MTech.TodoApp.CQRS.TodoItem.Results
{
    public class CreateTodoItemCommandResult : ICommandResult
    {
        public bool Successfull { get; set; }
        public ViewModel.TodoItem.CreatedView Data { get; set; } = null!;
    }
}