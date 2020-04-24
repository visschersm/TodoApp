using MTech.Utilities.ViewModel;

namespace MTech.TodoApp.ViewModel.TodoItem
{
    public class CreatedView : IViewOf<Entities.TodoItem>
    {
        public string Title { get; set; } = "";

        static CreatedView()
        {
            ViewHelper<Entities.TodoItem, CreatedView>.SelectExpression = x => new CreatedView
            {
                Title = x.Title
            };
        }
    }
}
