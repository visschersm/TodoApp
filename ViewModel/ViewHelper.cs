using System;
using System.Linq.Expressions;
using System.Linq;

namespace MTech.TodoApp.ViewModel
{
    public static class Extensions
    {
        public static IQueryable<TView> ProjectTo<TEntity, TView>(this IQueryable<TEntity> source)
            where TEntity : class
            where TView : IViewOf<TEntity>
        {
            return source.Select(ViewHelper<TEntity, TView>.SelectExpression);
        }

        //public static IQueryable<TView> ProjectTo<TView>(this IQueryable source)
        //{
        //
        //    var elementType = source.ElementType;
        //    return source.Select(ViewHelper.SelectExpression<TView>(source.ElementType));
        //}
    }

    public static class ViewHelper<TEntity, TView>
        where TEntity : class
        where TView : IViewOf<TEntity>
    {
        public static Expression<Func<TEntity, TView>> SelectExpression
        {
            get
            {
                //Activator.CreateInstance(typeof(TView);
                return _expression;
            }
            set
            {
                _expression = value;
            }
        }

        private static Expression<Func<TEntity, TView>> _expression;
    }
}