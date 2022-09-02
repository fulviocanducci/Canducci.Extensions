using System;
using System.Linq;
using System.Linq.Expressions;
namespace Canducci.Extensions.EntityFramework
{
    public static class EfExtensions
    {
        public static IQueryable<IGrouping<char, T>> Group<T>(this IQueryable<T> query)
        {
            return query.GroupBy(g => 'c');
        }

        public static IQueryable<TResult> Group<T, TResult>(this IQueryable<T> query, Expression<Func<IGrouping<char, T>, TResult>> selector)
        {
            return query.Group().Select(selector);
        }
    }
}