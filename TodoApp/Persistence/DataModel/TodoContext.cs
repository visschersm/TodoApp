using Microsoft.EntityFrameworkCore;
using MTech.TodoApp.DataModel.Interfaces;
using MTech.TodoApp.Entities;

namespace MTech.TodoApp.DataModel
{
    public class TodoContext : DbContext, ITodoContext
    {
        public DbSet<TodoItem> TodoItems { get; set; } = null!;
        public DbSet<TodoList> TodoLists { get; set; } = null!;

        public TodoContext()
            : base()
        {

        }

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TodoContext");
        }
    }
}
