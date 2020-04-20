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
                IsDone = x.IsDone,
                EndDate = x.EndDate
            };
        }

        public string Title { get; set; }
        public int Priority { get; set; }
        public bool IsDone { get; set; }
        public DateTime EndDate { get; set; }
    }
}
