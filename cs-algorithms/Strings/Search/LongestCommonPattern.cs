using System;
using Algorithms.Sorting;

namespace Algorithms.Strings.Search
{
    public class LongestCommonPattern
    {


        public static String LongestCommonString(String s, String pat)
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