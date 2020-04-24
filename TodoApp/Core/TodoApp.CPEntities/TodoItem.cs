using System;

namespace MTech.TodoApp.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Priority Priority { get; set; }
        public bool IsDone { get; set; }
        public DateTime DueDate { get; set; }
        public int ParentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Note { get; set; }
        public TodoStatus Status { get; set; }
    }
}
