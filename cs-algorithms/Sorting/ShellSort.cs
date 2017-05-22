using System;
using Algorithms.Utils;

namespace Algorithms.Sorting
{
    public class ShellSort
    {
        public static void Sort<T>(T[] a, Comparison<T> compare)
        {
            var n = a.Length;
            var h = 1;
            while (h < n / 3)
            {
                h = 3 * h + 1;
            }

            var step = h;
            while (step > 0)
            {
                for (var i = step; i < n; i++)
                {
                    for (var j = i; j >= step; j -= step)
                    {
                        if (SortUtil.IsLessThan(a[j], a[j - step], compare))
                        {
                            SortUtil.Exchange(a, j, j - step);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                step--;
            }
        }

        public static void Sort<T>(T[] ints) where T : IComparable<T>
        {
            Sort(ints, (a1, a2) => a1.CompareTo(a2));
        }
    }
}