using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MTech.Utilities.ViewModel
{
    public static class Extensions
    {
        public static IQueryable<TView> ProjectTo<TEntity, TView>(this IQueryable<TEntity> source)
            where TEntity : class
            where TView : IViewOf<TEntity>
        {
            return source.Select(ViewHelper<TEntity, TView>.SelectExpression);
        }

        public static IEnumerable<TView> ProjectTo<TEntity, TView>(this IEnumerable<TEntity> source)
            where TEntity : class
            where TView : IViewOf<TEntity>
        {
            return source.Select(ViewHelper<TEntity, TView>.SelectExpression.Compile());
        }
    }

    public static class ViewHelper<TEntity, TView>
        where TEntity : class
        where TView : IViewOf<TEntity>
    {
        public static Expression<Func<TEntity, TView>> SelectExpression
        {
            get
            {
                Activator.CreateInstance(typeof(TView));

                return _expression;
            }
            set
            {
                _expression = value;
            }
        }

        private static Expression<Func<TEntity, TView>> _expression = null!;
    }
}