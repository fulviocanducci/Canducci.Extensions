using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace Canducci.Extensions.EntityFramework
{
    public static class EfExtensions
    {
        public static IQueryable<IGrouping<long, T>> Group<T>(this IQueryable<T> query)
        {
            return query.GroupBy(g => 1L);
        }

        public static IQueryable<TResult> Group<T, TResult>(this IQueryable<T> query, Expression<Func<IGrouping<long, T>, TResult>> select)
        {
            return query.Group().Select(select);
        }

        public static IEnumerable<TResult> Group<T, TResult>(this IQueryable<T> query, Func<IGrouping<long, T>, TResult> select)
        {
            return query.Group().Select(select);
        }

        public static IQueryable<TResult> Group<T, TResult>(this IQueryable<T> query, Expression<Func<IGrouping<long, T>, int, TResult>> select)
        {
            return query.Group().Select(select);
        }

        public static IEnumerable<TResult> Group<T, TResult>(this IQueryable<T> query, Func<IGrouping<long, T>, int, TResult> select)
        {
            return query.Group().Select(select);
        }
    }
}
