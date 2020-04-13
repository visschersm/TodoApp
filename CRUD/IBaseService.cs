using Microsoft.AspNetCore.JsonPatch;

namespace MTech.CRUD
{
    public interface IBaseService<TEntity>
        where TEntity : class
    {
        Task<TView> Create<TView>(ICreate toCreate) where TView : IViewOf<TEntity>;
        Task<TView> Get<TView>() where TView : IViewOf<TEntity>;
        TasK<TView> GetById<TKey, TView>(TKey key) where TView : IViewOf<TEntity>;
        Task<TView> Update<TKey, TView>(TKey key, JsonPatchDocument patchDocument)
            where TView : IViewOf<TEntity>;
    }
}