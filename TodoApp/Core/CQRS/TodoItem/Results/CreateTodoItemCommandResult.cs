using MTech.Utilities.RequestHandler;

namespace MTech.TodoApp.TodoItem.Results
{
    public class CreateTodoItemCommandResult : ICommandResult
    {
        public bool Successfull { get; set; }
    }
}