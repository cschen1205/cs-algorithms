using System;
using System.Runtime.InteropServices.ComTypes;
using Algorithms.Utils;

namespace Algorithms.Sorting
{
    public class HeapSort
    {
        public static void Sort<T>(T[] a) where T : IComparable<T>
        {
            Sort(a, (a1, a2) => a1.CompareTo(a2));
        }

        public static void Sort<T>(T[] a, Comparison<T> comparison)
        {
            var N = a.Length;
            for (var i = N / 2; i >= 1; --i)
            {
                Sink(a, i, N, comparison);
            }
            while (N > 0)
            {
                SortUtil.Exchange(a, Index(1), Index(N));
                Sink(a, 1, --N, comparison);
            }
        }

        private static void Sink<T>(T[] a, int k, int N, Comparison<T> comparison)
        {
            while (k * 2 <= N)
            {
                var child = 2 * k;
                if (child < N && SortUtil.IsGreaterThan(a[Index(child + 1)], a[Index(child)], comparison))
                {
                    child++;
                }
                if (SortUtil.IsGreaterThan(a[Index(child)], a[Index(k)], comparison))
                {
                    SortUtil.Exchange(a, Index(child), Index(k));
                    k = child;
                }
                else
                {
                    break;
                }
            }
        }

        private static int Index(int j)
        {
            return j - 1;
        }
    }
}