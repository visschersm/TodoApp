using System;

namespace MTech.TodoApp.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Priority { get; set; }
        public bool IsDone { get; set; }
        public DateTime EndDate { get; set; }
        public int ParentId { get; set; }
    }
}
