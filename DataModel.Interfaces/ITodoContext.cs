using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MTech.TodoApp.Entities;

namespace MTech.TodoApp.DataModel.Interfaces
{
    public interface ITodoContext
    {
        DbSet<TodoItem> TodoItems { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
