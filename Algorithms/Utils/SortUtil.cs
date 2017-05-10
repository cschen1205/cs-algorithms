using System.Collections.Generic;
using System.Globalization;

namespace Algorithms.Utils
{
    public class SortUtil
    {
        public static bool IsLessThan<T>(T p0, T p1, IComparer<T> compareTo)
        {
            return compareTo.Compare(p0, p1) < 0;
        }

        public static bool IsGreaterThan<T>(T p0, T p1, IComparer<T> compareTo)
        {
            return compareTo.Compare(p0, p1) < 0;
        }

        public static void Exchange<T>(T[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}