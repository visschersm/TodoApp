using MTech.Utilities.ViewModel;
using System;

namespace MTech.TodoApp.ViewModel.TodoItem
{
    public class DetailedView : IViewOf<Entities.TodoItem>
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; } = "";
        public Priority Priority { get; set; }
        public TodoStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public string? Note { get; set; }

        static DetailedView()
        {
            ViewHelper<Entities.TodoItem, ViewModel.TodoItem.DetailedView>.SelectExpression = x => new DetailedView
            {
                Id = x.Id,
                ParentId = x.ParentId,
                Title = x.Title,
                Priority = x.Priority,
                Status = x.Status,
                DueDate = x.DueDate,
                Note = x.Note
            };
        }
    }
}
