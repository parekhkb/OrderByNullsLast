using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByNullsLast
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> list, Func<T, TKey?> keySelector, NullOrder nullOrder)
        where TKey : struct
        {
            switch (nullOrder)
            {
                case NullOrder.NullsLast:
                    return list.OrderBy(keySelector, NullableComparer<TKey>.Larger);
                case NullOrder.NullsFirst:
                    return list.OrderBy(keySelector, NullableComparer<TKey>.Smaller);
                default:
                    throw new ArgumentOutOfRangeException(nameof(nullOrder), nullOrder, null);
            }
        }

        public static IEnumerable<T> OrderByDescending<T, TKey>(this IEnumerable<T> list, Func<T, TKey?> keySelector, NullOrder nullOrder)
        where TKey : struct
        {
            switch (nullOrder)
            {
                case NullOrder.NullsLast:
                    return list.OrderByDescending(keySelector, NullableComparer<TKey>.Smaller);
                case NullOrder.NullsFirst:
                    return list.OrderByDescending(keySelector, NullableComparer<TKey>.Larger);
                default:
                    throw new ArgumentOutOfRangeException(nameof(nullOrder), nullOrder, null);
            }
        }

        public static IEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> list, Func<T, TKey> keySelector, NullOrder nullOrder)
            where TKey : class
        {
            switch (nullOrder)
            {
                case NullOrder.NullsLast:
                    return list.OrderBy(keySelector, ClassComparer<TKey>.Larger);
                case NullOrder.NullsFirst:
                    return list.OrderBy(keySelector, ClassComparer<TKey>.Smaller);
                default:
                    throw new ArgumentOutOfRangeException(nameof(nullOrder), nullOrder, null);
            }
        }

        public static IEnumerable<T> OrderByDescending<T, TKey>(this IEnumerable<T> list, Func<T, TKey> keySelector, NullOrder nullOrder)
            where TKey : class
        {
            switch (nullOrder)
            {
                case NullOrder.NullsLast:
                    return list.OrderByDescending(keySelector, ClassComparer<TKey>.Smaller);
                case NullOrder.NullsFirst:
                    return list.OrderByDescending(keySelector, ClassComparer<TKey>.Larger);
                default:
                    throw new ArgumentOutOfRangeException(nameof(nullOrder), nullOrder, null);
            }
        }
    }
}