using System;
using Algorithms.Utils;

namespace Algorithms.Sorting
{
    public class MergeSort
    {
        public static void Sort<T>(T[] a) where T : IComparable<T>
        {
            Sort(a, 0, a.Length-1, (a1, a2) => a1.CompareTo(a2));
        }

        public static void Sort<T>(T[] a, int lo, int hi, Comparison<T> compare)
        {
            var aux = new T[a.Length];
            Sort(a, aux, lo, hi, compare);
        }

        private static void Sort<T>(T[] a, T[] aux, int lo, int hi, Comparison<T> compare)
        {
            if (lo >= hi) return;

            if (hi - lo <= 7)
            {
                InsertionSort.Sort(a, lo, hi, compare);
                return;
            }

            var mid = (hi - lo) / 2 + lo;
            Sort(a, aux, lo, mid, compare);
            Sort(a, aux, mid, hi, compare);
            Merge(a, aux, lo, mid, hi, compare);
        }

        private static void Merge<T>(T[] a, T[] aux, int lo, int mid, int hi, Comparison<T> compare)
        {
            int i, j;
            for (i = lo; i <= hi; ++i)
            {
                aux[i] = a[i];
            }

            i = lo;
            j = mid;
            for(var k=lo; k <= hi; ++k)
            {
                if (i >= mid) a[k] = aux[j++];
                if (j >= hi) a[k] = aux[i++];
                if (SortUtil.IsLessThan(a[i], a[j], compare))
                {
                    a[k] = aux[i++];
                }
                else
                {
                    a[k] = aux[j++];
                }
            }
        }
    }
}