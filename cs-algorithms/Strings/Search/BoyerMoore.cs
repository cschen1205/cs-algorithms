using System;

namespace Algorithms.Strings.Search
{
    public class BoyerMoore
    {
        private int[] right;
        private const int R = 256;
        private int M;
        private string pat;
        public BoyerMoore(string pat)
        {
            this.pat = pat;
            right = new int[R];
            for (int i = 0; i < pat.Length; ++i)
            {
                right[pat[i]] = i;
            }
            M = pat.Length;
        }

        public int Search(string text)
        {
            int skip;
            for (int i = 0; i < text.Length - M; i+=skip)
            {
                skip = 0;
                for (var j = M - 1; j >= 0; j--)
                {
                    if (text[i + j] != pat[j])
                    {
                        skip = Math.Max(1, j - right[text[i + j]]);
                        break;
                    }
                }
                if (skip == 0) return i;
            }
            return -1;
        }

    }
}