using MTech.Utilities.ViewModel;

namespace MTech.TodoApp.ViewModel.TodoList
{
    public class DetailedView : IViewOf<Entities.TodoList>
    {
        static DetailedView()
        {
            ViewHelper<Entities.TodoList, DetailedView>.SelectExpression = x => new DetailedView
            {

            };
        }
    }
}
