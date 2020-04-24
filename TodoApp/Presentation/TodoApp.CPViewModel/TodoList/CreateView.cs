using MTech.Utilities.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace MTech.TodoApp.ViewModel.TodoList
{
    public class CreateView : IViewOf<Entities.TodoList>
    {
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Title { get; set; } = "";
        public string LabelColor { get; set; } = "#000000";
    }
}
