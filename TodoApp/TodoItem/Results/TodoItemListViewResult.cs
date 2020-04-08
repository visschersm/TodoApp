using MTech.RequestHandler;
using MTech.TodoApp.ViewModel.TodoItem;
using System.Collections.Generic;

namespace MTech.TodoApp.TodoItem.Results
{
    public class TodoItemListViewResult : IQueryResult
    {
        public bool Successfull { get; set; }
        public TodoItemListView[] Data { get; internal set; }
    }
}
