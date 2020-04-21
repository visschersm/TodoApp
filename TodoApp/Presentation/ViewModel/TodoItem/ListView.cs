using MTech.Utilities.ViewModel;

namespace MTech.TodoApp.ViewModel.TodoItem
{
    public class ListView : IViewOf<Entities.TodoItem>
    {
        public ListView()
        {
            ViewHelper<Entities.TodoItem, ListView>.SelectExpression = x => new ListView
            {
                Title = x.Title
            };
        }

        public string Title { get; internal set; }
    }
}
