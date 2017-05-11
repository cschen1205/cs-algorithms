using System;
using Algorithms.Utils;

namespace Algorithms.Sorting
{
    public class QuickSort
    {
        public static void Sort<T>(T[] a) where T : IComparable<T>
        {
            Sort(a, 0, a.Length - 1, (a1, a2) => a1.CompareTo(a2));
        }

        public static void Sort<T>(T[] a, int lo, int hi, Comparison<T> compare)
        {
            if (lo >= hi)
            {
                return;
            }

            if (hi - lo <= 7)
            {
                InsertionSort.Sort(a, lo, hi, compare);
                return;
            }

            var j = Partition(a, lo, hi, compare);
            Sort(a, lo, j-1, compare);
            Sort(a, j+1, hi, compare);
        }

        public static int Partition<T>(T[] a, int lo, int hi, Comparison<T> compare)
        {
            var v = a[lo];
            int i = lo, j = hi+1;
            while (true)
            {
                while (SortUtil.IsLessThan(a[++i], v, compare))
                {
                    if (i >= hi) break;
                }
                while (SortUtil.IsLessThan(v, a[--j], compare))
                {
                    if (j <= lo) break;
                }

                if (i >= j)
                {
                    break;
                }

                SortUtil.Exchange(a, i, j);
            }
            SortUtil.Exchange(a, lo, j);
            return j;
        }

    }
}