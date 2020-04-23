using MTech.TodoApp.Enumerations;
using MTech.Utilities.ViewModel;
using System;

namespace MTech.TodoApp.ViewModel.TodoItem
{
    public class ListView : IViewOf<Entities.TodoItem>
    {
        public ListView()
        {
            ViewHelper<Entities.TodoItem, ListView>.SelectExpression = x => new ListView
            {
                Title = x.Title,
                Priority = x.Priority,
                IsDone = x.Status == Status.Done,
                EndDate = x.DueDate
            };
        }

        public string Title { get; set; } = null!;
        public Priority Priority { get; set; }
        public bool IsDone { get; set; }
        public DateTime EndDate { get; set; }
    }
}
