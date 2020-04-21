using Microsoft.AspNetCore.JsonPatch;
using MTech.Utilities.ViewModel;
using System.Threading.Tasks;

namespace MTech.Utilities.CRUD
{
    public interface IBaseService<TEntity>
        where TEntity : class
    {
        Task<TView> Create<TView>(ICreate<TEntity> toCreate)
            where TView : IViewOf<TEntity>;
        Task<TView> Get<TView>()
            where TView : IViewOf<TEntity>;
        Task<TView> GetById<TKey, TView>(TKey key)
            where TView : IViewOf<TEntity>;
        Task<TView> Update<TKey, TView>(TKey key, JsonPatchDocument patchDocument)
            where TView : IViewOf<TEntity>;
        Task Delete<TKey>(TKey key);
    }
}