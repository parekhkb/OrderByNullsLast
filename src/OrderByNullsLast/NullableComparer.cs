using System.Collections.Generic;

namespace OrderByNullsLast
{
    internal class NullableComparer<T> : IComparer<T?> where T : struct
    {
        public static NullableComparer<T> Larger => new NullableComparer<T>(true);
        public static NullableComparer<T> Smaller => new NullableComparer<T>(false);

        private readonly bool _isLarger;

        private NullableComparer(bool isLarger)
        {
            _isLarger = isLarger;
        }

        public int Compare(T? x, T? y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null)
            {
                return _isLarger ? 1 : -1;
            }

            if (y == null)
            {
                return _isLarger ? -1 : 1;
            }

            return Comparer<T>.Default.Compare(x.Value, y.Value);
        }
    }
}
