using System.Collections.Generic;

namespace NullOrderBy
{
    internal class NullsComparer<T> : IComparer<T?> where T : struct
    {
        public static NullsComparer<T> Larger => new NullsComparer<T>(true);
        public static NullsComparer<T> Smaller => new NullsComparer<T>(false);

        private readonly bool _isLarger;

        private NullsComparer(bool isLarger)
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
