using MTech.TodoApp.Enumerations;
using System;

namespace MTech.TodoApp.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public Priority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public int ParentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Note { get; set; }
        public Status Status { get; set; }
    }
}
