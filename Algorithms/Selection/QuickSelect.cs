using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms.Utils;

namespace SimuKit.Algorithms.Selection
{
    public class QuickSelect
    {
        public static T Select<T>(T[] a, int k, Comparison<T> compareTo = null)
        {
            int lo = 0;
            int hi = a.Length - 1;
            while (lo < hi)
            {
                int j = Partition(a, lo, hi, compareTo);
                if (j < k) lo = j + 1;
                else if (j > k) hi = j - 1;
                else return a[k];
            }

            return a[k];
        }

        public static int Partition<T>(T[] a, int lo, int hi, Comparison<T> compareTo)
        {
            int i = lo;
            int j = hi + 1;
            while (true)
            {
                while (SortUtil.IsLessThan(a[++i], a[lo], compareTo))
                {
                    if (i == hi) break;
                }
                while(SortUtil.IsLessThan(a[lo], a[--j], compareTo))
                {
                    if(j==lo) break;
                }

                if(i >= j) break;

                SortUtil.Exchange(a, i, j);
            }

            SortUtil.Exchange(a, lo, j);
            return j;

        }
    }
}
