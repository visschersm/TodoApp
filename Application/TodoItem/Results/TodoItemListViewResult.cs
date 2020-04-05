using MTech.RequestHandler;
using MTech.TodoApp.ViewModel.TodoItem;
using System.Collections.Generic;

namespace MTech.TodoApp.TodoItem.Results
{
    public class TodoItemListViewResult : IRequestResult
    {
        public bool Succesfull { get; set; }
        public IEnumerable<TodoItemListView> TodoItemList { get; set; }
    }
}
