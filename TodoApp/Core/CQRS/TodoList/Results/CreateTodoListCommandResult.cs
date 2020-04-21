using MTech.Utilities.RequestHandler;

namespace MTech.TodoApp.CQRS.Results
{
    public class CreateTodoListCommandResult : ICommandResult
    {
        public bool Successfull { get; set; }
        public ViewModel.TodoList.CreatedView Data { get; set; } = null!;
    }
}
