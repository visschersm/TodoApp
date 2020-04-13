using MTech.RequestHandler;
using MTech.TodoApp.ViewModel.TodoItem;
using System.Collections.Generic;

namespace MTech.TodoApp.TodoItem.Results
{
    public class TodoItemListViewResult<TView> : IQueryResult
    {
        public bool Successfull { get; set; }
        public TView[] Data { get; internal set; }
    }
}
