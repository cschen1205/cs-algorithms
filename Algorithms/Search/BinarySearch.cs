using System;
using System.Security.Cryptography;
using Algorithms.Utils;

namespace Algorithms.Search
{
    public class BinarySearch
    {
        public static int IndexOf<T>(T[] a, T v) where T: IComparable<T>
        {
            var lo = 0;
            var hi = a.Length - 1;
            int comparison(T a1, T a2) => a1.CompareTo(a2);

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (SortUtil.IsLessThan(a[mid], v, comparison)) lo = mid;
                else if (SortUtil.IsGreaterThan(a[mid], v, comparison)) hi = mid;
            }
            return -1;
        }
    }
}