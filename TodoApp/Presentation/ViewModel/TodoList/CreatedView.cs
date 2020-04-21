using MTech.Utilities.ViewModel;

namespace MTech.TodoApp.ViewModel.TodoList
{
    public class CreatedView : IViewOf<Entities.TodoList>
    {
        public string Title { get; set; }
    }
}
