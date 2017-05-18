using System;
using Algorithms.Sorting;

namespace Algorithms.Strings.Search
{
    public class LongestRepeatedPattern
    {
        public static String Find(String text)
        {
            int N = text.Length;
            String[] a = new String[N];
            for (var i = 0; i < N; ++i)
            {
                a[i] = text.Substring(i, N-i);
            }

            QuickSort.Sort(a);

            String result = "";
            for (int i = 0; i < a.Length-1; ++i)
            {
                var j = lcp(a[i], a[i + 1]);
                if (result.Length < j)
                {
                    result = a[i].Substring(0, j);
                }
            }
            return result;
        }

        private static int lcp(String s1, String s2)
        {
            int k = Math.Min(s1.Length, s2.Length);
            var i = 0;
            for (i = 0; i < k; ++i)
            {
                if (s1[i] != s2[i])
                {
                    break;
                }
            }
            return i;
        }
    }
}