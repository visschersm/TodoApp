using MTech.Utilities.ViewModel;

namespace MTech.TodoApp.ViewModel.TodoList
{
    public class CreateView : IViewOf<Entities.TodoList>
    {
        public string Title { get; set; }
        public string Color { get; set; }
    }
}
