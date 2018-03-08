using System.Collections.Generic;

namespace OrderByNullsLast
{
    internal class ClassComparer<T> : IComparer<T> where T : class
    {
        public static ClassComparer<T> Larger => new ClassComparer<T>(true);
        public static ClassComparer<T> Smaller => new ClassComparer<T>(false);

        private readonly bool _isLarger;

        private ClassComparer(bool isLarger)
        {
            _isLarger = isLarger;
        }

        public int Compare(T x, T y)
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

            return Comparer<T>.Default.Compare(x, y);
        }
    }
}
