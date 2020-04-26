using CPExtensions;
using MTech.Utilities.ViewModel;
using System.Collections.Generic;

namespace MTech.TodoApp.ViewModel.TodoList
{
    public class DetailedView : IViewOf<Entities.TodoList>
    {
        static DetailedView()
        {
            ViewHelper<Entities.TodoList, DetailedView>.SelectExpression = x => new DetailedView
            {
                Id = x.Id,
                LabelColor = x.LabelColor.ToHtml(),
                Title = x.Title,
                TodoItems = x.TodoItems.ProjectTo<Entities.TodoItem, TodoItem.ListView>(),
            };
        }

        public int Id { get; set; }
        public string LabelColor { get; set; } = "#000000";
        public string Title { get; set; } = "";
        public IEnumerable<TodoItem.ListView> TodoItems { get; set; } = new List<TodoItem.ListView>();
    }
}

