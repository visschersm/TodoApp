using MTech.Utilities.RequestHandler;

namespace MTech.TodoApp.CQRS.Results
{
    public class GetTodoListByIdQueryResult : IQueryResult
    {
        public bool Successfull { get; set; }
        public ViewModel.TodoList.DetailedView Data { get; set; } = null!;
    }
}
