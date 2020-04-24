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
                Id = x.Id,
                ParentId = x.ParentId,
                Title = x.Title,
                Priority = x.Priority,
                Status = x.Status,
                DueDate = x.DueDate
            };
        }

        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; } = null!;
        public Priority Priority { get; set; }
        public bool IsDone
        {
            get
            {
                return Status == TodoStatus.Done;
            }
            set
            {
                Status = value ? TodoStatus.Done : Status;

            }
        }
        public TodoStatus Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}
