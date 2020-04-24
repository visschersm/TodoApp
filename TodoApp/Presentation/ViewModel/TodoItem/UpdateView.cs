using MTech.Utilities.ViewModel;
using System;

namespace MTech.TodoApp.ViewModel.TodoItem
{
    public class UpdateView : IViewOf<Entities.TodoItem>
    {
        public string Title { get; set; } = "";
        public Priority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string? Note { get; set; }
    }
}
 