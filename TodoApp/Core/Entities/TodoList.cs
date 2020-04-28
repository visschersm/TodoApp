using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace MTech.TodoApp.Entities
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();

        public int Argb
        {
            get
            {
                return LabelColor.ToArgb();
            }
            set
            {
                LabelColor = Color.FromArgb(value);
            }
        }


        [NotMapped]
        public Color LabelColor { get; set; }
    }
}
