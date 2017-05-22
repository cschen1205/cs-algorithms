using System;
using Algorithms.Utils;

namespace Algorithms.Sorting
{
    public class InsertionSort
    {
        public static void Sort<T>(T[] a, int lo, int hi, Comparison<T> compare)
        {
            for (var i = lo + 1; i <= hi; ++i)
            {
                for (var j = i-1; j >= lo; --j)
                {
                    if (SortUtil.IsLessThan(a[j+1], a[j], compare))
                    {
                        SortUtil.Exchange(a, j, j + 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public static void Sort<T>(T[] a) where T : IComparable<T>
        {
            Sort(a, 0, a.Length-1, (a1, a2) => a1.CompareTo(a2));
        }
    }
}