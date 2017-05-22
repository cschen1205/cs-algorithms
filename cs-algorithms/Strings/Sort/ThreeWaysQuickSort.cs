using System;
using Algorithms.Utils;

namespace Algorithms.Strings.Sort
{
    public class ThreeWaysQuickSort
    {
        public static void Sort(string[] a)
        {
            Sort(a, 0, a.Length-1, 0);
        }

        private static void Sort(string[] a, int lo, int hi, int d)
        {
            if (lo >= hi)
            {
                return;
            }

            var c = charAt(a[lo], d);

            int i = lo, lt = lo, gt = hi;
            while (i <= gt)
            {
                var cmp = c.CompareTo(charAt(a[i], d));
                if(cmp > 0) SortUtil.Exchange(a, i++, lt++);
                else if (cmp < 0) SortUtil.Exchange(a, i, gt--);
                else i++;
            }

            Sort(a, lo, lt-1, d);
            if(c >= 0) Sort(a, lt, gt, d+1);
            Sort(a, gt+1, hi, d);
        }

        private static int charAt(string a, int d)
        {
            if (a.Length <= d)
            {
                return -1;
            }
            return a[d];
        }
    }
}