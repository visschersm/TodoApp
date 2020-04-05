using Microsoft.EntityFrameworkCore;
using MTech.TodoApp.Entities;

namespace MTech.TodoApp.DataModel.Interfaces
{
    public interface ITodoContext
    {
        DbSet<TodoItem> TodoItems { get; set; }
    }
}
