using System;
using Algorithms.Utils;

namespace Algorithms.Sorting
{
    public class ThreeWayQuickSort
    {
        public static void Sort<T>(T[] a) where T : IComparable<T>
        {
            Sort(a, 0, a.Length-1, (a1, a2) => a1.CompareTo(a2));
        }
        
        public static void Sort<T>(T[] a, int lo, int hi, Comparison<T> compare)
        {
            if (lo >= hi)
            {
                return;
            }

            if (hi - lo < 7)
            {
                InsertionSort.Sort(a, lo, hi, compare);
                return;
            }


            int i = lo, lt = lo, gt = hi;
            while (i < gt)
            {
                if (SortUtil.IsLessThan(a[lo], a[lt], compare))
                {
                    SortUtil.Exchange(a, i++, lt++);
                }
                if (SortUtil.IsLessThan(a[gt], a[lo], compare))
                {
                    SortUtil.Exchange(a, i, gt--);
                }
            }

            Sort(a, lo, lt-1, compare);
            Sort(a, gt+1, hi, compare);

        }
    }
}