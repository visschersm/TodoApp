using MTech.Utilities.ViewModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace MTech.TodoApp.ViewModel.TodoItem
{
    public class CreateView : IViewOf<Entities.TodoItem>
    {
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Title { get; set; } = "";

        public Priority Priority { get; set; } = Priority.None;
        public DateTime DueDate { get; set; }
        public string? Note { get; set; }
    }
}
