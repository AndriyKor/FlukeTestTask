using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Fluke.API.Extentions
{
    public static class IQueryableExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            if (!IsPropertyValid(source, propertyName))
                return source.OrderBy(s => 0);

            return source.OrderBy(ToLambda<T>(propertyName));
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            if (!IsPropertyValid(source, propertyName))
                return source.OrderByDescending(s => 0);

            return source.OrderByDescending(ToLambda<T>(propertyName));
        }

        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }

        private static bool IsPropertyValid<T>(IQueryable<T> source, string propertyName)
        {
            return source.FirstOrDefault().GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null;
        }
    }
}
