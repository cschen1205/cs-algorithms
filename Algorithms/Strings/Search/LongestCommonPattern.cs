using System;
using Algorithms.Sorting;

namespace Algorithms.Strings.Search
{
    public class LongestCommonPattern
    {
        public String Find(String s1, String s2)
        {
            int N = s1.Length;
            String[] a = new String[N];
            for (var i = 0; i < N; ++i)
            {
                a[i] = s1.Substring(i, N);
            }
            QuickSort.Sort(a);

            String lcs = "";
            for (var i = 0; i < N; ++i)
            {
                String s = LongestCommonString(a[i], s2);
                if (s.Length > lcs.Length)
                {
                    lcs = s;
                }
            }
            return lcs;
        }

        public String LongestCommonString(String s, String pat)
        {
            int J = 0;
            for (var i = 0; i < s.Length; ++i)
            {
                for (var j = 0; j < pat.Length; ++j)
                {

                    if (i+j >= s.Length || s[i + j] != pat[j])
                    {
                        J = Math.Max(J, j);
                        break;
                    }
                }
            }
            return pat.Substring(0, J);
        }
    }
}