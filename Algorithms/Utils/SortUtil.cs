using System;
using System.Collections.Generic;
using System.Globalization;

namespace Algorithms.Utils
{
    public class SortUtil
    {
        public static bool IsLessThan<T>(T p0, T p1, Comparison<T> compareTo)
        {
            return compareTo(p0, p1) < 0;
        }

        public static bool IsGreaterThan<T>(T p0, T p1, Comparison<T> compareTo)
        {
            return compareTo(p0, p1) > 0;
        }

        public static void Exchange<T>(T[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        public static bool IsLessThan<T>(T p0, T p1) where T : IComparable<T>
        {
            return IsLessThan(p0, p1, (a1, a2) => a1.CompareTo(a2));
        }
    }
}