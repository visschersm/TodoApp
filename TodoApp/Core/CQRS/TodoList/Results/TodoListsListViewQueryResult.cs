using MTech.Utilities.RequestHandler;
using System.Collections.Generic;

namespace MTech.TodoApp.CQRS.Results
{
    public class TodoListsListViewQueryResult : IQueryResult
    {
        public bool Successfull { get; set; }
        public IEnumerable<ViewModel.TodoList.ListView> Data { get; set; } = null!;
    }
}
