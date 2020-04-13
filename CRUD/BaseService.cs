using System;
using System.Threading.Tasks;
using MTech.TodoApp.ViewModel;
using Microsoft.AspNetCore.JsonPatch;

namespace MTech.CRUD
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class
    {
        public Task<TView> Create<TView>(ICreate<TEntity> toCreate) 
            where TView : IViewOf<TEntity>
        {
            throw new NotImplementedException();
        }

        public Task<TView> Get<TView>() 
            where TView : IViewOf<TEntity>
        {
            throw new NotImplementedException();
        }

        public Task<TView> GetById<TKey, TView>(TKey key) 
            where TView : IViewOf<TEntity>
        {
            throw new NotImplementedException();
        }

        public Task<TView> Update<TKey, TView>(TKey key, JsonPatchDocument patchDocument)
            where TView : IViewOf<TEntity>
        {
            throw new NotImplementedException();
        }

        public Task Delete<TKey>(TKey key)
        {
            throw new NotImplementedException();
        }
    }
}