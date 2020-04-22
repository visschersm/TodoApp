using MTech.Utilities.ViewModel;
using System.Collections.Generic;

namespace MTech.TodoApp.ViewModel.TodoList
{
    public class ListView : IViewOf<Entities.TodoList>
    {
        static ListView()
        {
            ViewHelper<Entities.TodoList, ListView>.SelectExpression = x => new ListView
            {
                Id = x.Id,
                Title = x.Title,
                TodoItems = x.TodoItems.ProjectTo<Entities.TodoItem, TodoItem.ListView>(),
                LabelColor = System.Drawing.ColorTranslator.ToHtml(x.LabelColor)
            };
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string LabelColor { get; set; } = "#000000";
        public IEnumerable<TodoItem.ListView> TodoItems { get; set; } = new List<TodoItem.ListView>();
    }
}
