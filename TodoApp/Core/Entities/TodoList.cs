using System.Collections.Generic;

namespace MTech.TodoApp.Entities
{
    public class TodoList
    {
        public int Id { get; set; }
        public ICollection<TodoItem> TodoItems { get; set; } = new HashSet<TodoItem>();
    }
}
