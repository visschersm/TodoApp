using Microsoft.EntityFrameworkCore;
using MTech.TodoApp.DataModel.Interfaces;
using MTech.TodoApp.Entities;

namespace MTech.TodoApp.DataModel
{
    public class TodoContext : DbContext, ITodoContext
    {
        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }
}
