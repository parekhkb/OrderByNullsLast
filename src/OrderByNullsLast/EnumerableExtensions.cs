using System;
using System.Collections.Generic;
using System.Linq;

namespace NullOrderBy
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> list, Func<T, TKey?> keySelector, NullOrder nullOrder)
        where TKey : struct
        {
            switch (nullOrder)
            {
                case NullOrder.NullsLast:
                    return list.OrderBy(keySelector, NullsComparer<TKey>.Larger);
                case NullOrder.NullsFirst:
                    return list.OrderBy(keySelector, NullsComparer<TKey>.Smaller);
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
                    return list.OrderByDescending(keySelector, NullsComparer<TKey>.Smaller);
                case NullOrder.NullsFirst:
                    return list.OrderByDescending(keySelector, NullsComparer<TKey>.Larger);
                default:
                    throw new ArgumentOutOfRangeException(nameof(nullOrder), nullOrder, null);
            }
        }
    }
}