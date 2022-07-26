using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Text;
using JetBrains.Annotations;

namespace UtilitiesLib
{
    [SuppressMessage("ReSharper", "RedundantTypeArgumentsOfMethod")]
    public static class LinqExtensions
    {
        [ContractAnnotation("null => true")]
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) =>
            source switch
            {
                null => true,
                ICollection<T> genericCollection => genericCollection.Count == 0,
                ICollection nonGenericCollection => nonGenericCollection.Count == 0,
                _ => !source.Any()
            };

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> func)
        {
            if (source.IsNullOrEmpty())
                return;

            foreach (var item in source)
                func?.Invoke(item);
        }

        public static IEnumerable<TResult> ExtractIEnumerable<TSource, TResult>(this IEnumerable<TSource> source, Converter<TSource, TResult> converter)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            foreach (var item in source)
                yield return converter(item);
        }

        /// <summary>
        /// For use with Dapper since there is no need to send a DBNull with Dapper, also handles NULLs nicely
        /// Quoted should be true when used to put in an IN list with string concatenation ({0})
        /// Quoted should be false when used with (SELECT CONVERT(UNIQUEIDENTIFIER,ParameterValue) FROM uf_SplitCommaList(@listOfGuids,','))
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="quoted"></param>
        /// <returns></returns>
        public static string? AsSqlValuesList<T>(this IEnumerable<T> items, bool quoted = false)
        {
            if (items.IsNullOrEmpty())
                return null;

            if (typeof(T) == typeof(int))
                quoted = false;

            var stringBuilder = new StringBuilder();
            foreach (var item in items.Distinct())
            {
                if (quoted)
                    stringBuilder.AppendFormat(format: stringBuilder.Length == 0
                        ? "'{0}'"
                        : ", '{0}'", arg0: item?.ToString()?.Replace("'", "''"));
                else
                    stringBuilder.AppendFormat(format: stringBuilder.Length == 0
                        ? "{0}"
                        : ",{0}", arg0: item);
            }

            return stringBuilder.ToString();
        }

        [Obsolete("Use AsSqlValuesList()")]
        public static string ConcatString<T>(this IEnumerable<T> items)
        {
            var stringBuilder = new StringBuilder();
            foreach (var item in items.Distinct())
                stringBuilder.AppendFormat(stringBuilder.Length == 0
                    ? "{0}"
                    : ",{0}", item);

            return stringBuilder.ToString();
        }

        public static T? FirstOrDefaultFromHierarchy<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> selector, Predicate<T> condition)
        {
            if (source.IsNullOrEmpty()) return default;

            var match = source.FirstOrDefault(t => condition(t));

            return !Equals(match, default(T))
                ? match
                : source.SelectMany(selector).FirstOrDefaultFromHierarchy(selector, condition);
        }

        public static IOrderedQueryable<T>? OrderBy<T>(this IQueryable<T> source, string property) =>
            ApplyOrder<T>(source, property, "OrderBy");

        public static IOrderedQueryable<T>? OrderByDescending<T>(this IQueryable<T> source, string property) =>
            ApplyOrder<T>(source, property, "OrderByDescending");

        public static IOrderedQueryable<T>? ThenBy<T>(this IOrderedQueryable<T> source, string property) =>
            ApplyOrder<T>(source, property, "ThenBy");

        public static IOrderedQueryable<T>? ThenByDescending<T>(this IOrderedQueryable<T> source, string property) =>
            ApplyOrder<T>(source, property, "ThenByDescending");

        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        static IOrderedQueryable<T>? ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            var props = property.Split('.');

            var type = typeof(T);
            var arg = Expression.Parameter(type, "x");
            Expression expr = arg;

            foreach (var prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                var propertyInfo = type.GetProperty(prop);
                expr = Expression.Property(expr, propertyInfo);
                type = propertyInfo.PropertyType;
            }

            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            var lambda = Expression.Lambda(delegateType, expr, arg);

            var result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                              && method.IsGenericMethodDefinition
                              && method.GetGenericArguments().Length == 2
                              && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), type)
                .Invoke(null, new object[] {source, lambda});

            return (IOrderedQueryable<T>?) result;
        }

        /// <summary>
        /// Returns a concatenated list of objects (comma delimited) used for a SQL Contains clause (i.e. '1','2','3',...)
        /// </summary>
        /// <typeparam name="T">object type within list object</typeparam>
        /// <param name="items">list objects</param>
        /// <returns>concatenated string with list of objects (comma delimited w/quotes)</returns>
        [Obsolete("Use SqlValuesList(true)")]
        public static string ConcatList<T>(this IEnumerable<T> items) where T : notnull
        {
            if (items.IsNullOrEmpty()) return string.Empty;
            var stringBuilder = new StringBuilder();
            foreach (var item in items)
            {
                if (item is int)
                    stringBuilder.AppendFormat(stringBuilder.Length == 0
                        ? "{0}"
                        : ", {0}", item);
                else
                {
                    stringBuilder.AppendFormat(stringBuilder.Length == 0
                        ? "'{0}'"
                        : ", '{0}'", item.ToString()?.Replace("'", "''"));
                }
            }

            return stringBuilder.ToString();
        }

        public static IEnumerable<IEnumerable<TSource>> Chunk<TSource>(this IEnumerable<TSource> source, int chunkSize)
        {
            // copy the source into a list
            var chunkList = source.ToList();

            // return chunks of 'chunkSize' items
            while (chunkList.Count > chunkSize)
            {
                yield return chunkList.GetRange(0, chunkSize);
                chunkList.RemoveRange(0, chunkSize);
            }

            // return the rest
            yield return chunkList;
        }

        public static IEnumerable<TSource[]> Chunk<TSource>(this TSource[] source, int chunkSize)
        {
            // copy the source into a list
            var chunkList = source.ToList();

            // return chunks of 'chunkSize' items
            while (chunkList.Count > chunkSize)
            {
                yield return chunkList.GetRange(0, chunkSize).ToArray();
                chunkList.RemoveRange(0, chunkSize);
            }

            // return the rest
            yield return chunkList.ToArray();
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int size = 50)
        {
            return source
                .ToList()
                .Select((x, i) => new {Index = i, Value = x})
                .GroupBy(x => x.Index / size)
                .Select(x => x.Select(v => v.Value));
        }

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items, int batchSize) =>
            items.IsNullOrEmpty()
                ? new[] {new T[] { }}
                : items.Select((item, pos) => new {item, pos})
                    .GroupBy(x => x.pos / batchSize)
                    .Select(g => g.Select(x => x.item));
    }
}