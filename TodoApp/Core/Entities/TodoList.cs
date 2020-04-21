using System.Collections.Generic;
using System.Drawing;

namespace MTech.TodoApp.Entities
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
        public Color LabelColor { get; set; }
    }
}
