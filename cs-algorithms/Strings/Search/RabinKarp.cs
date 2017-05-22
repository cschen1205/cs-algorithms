using System;
using System.Security.Cryptography;

namespace Algorithms.Strings.Search
{
    public class RabinKarp
    {
        private const int R = 256;
        private int Q = 179426549;
        private int patHash;
        private int M;
        private int RM;
        public RabinKarp(string pat)
        {
            var N = pat.Length;
            RM = 1;
            for (var i = 1; i < N; ++i)
            {
                RM = (RM * R) % Q;
            }
            patHash = Hash(pat, pat.Length);
            M = pat.Length;
        }

        private int Hash(String text, int k)
        {
            int h = 0;
            for (var i = 0; i < k; ++i)
            {
                h = (h * R + text[i]) % Q;
            }
            return h;
        }

        public int Search(string text)
        {
            int N = text.Length;
            var h = Hash(text, M);
            if (h == patHash) return 0;
            for (var i = 1; i < N - M; ++i)
            {
                h = (h + Q - RM * text[i - 1] % Q) % Q;
                h = (h * R + text[i + M - 1]) % Q;

                if (h == patHash) return i;
            }
            return -1;
        }
    }
}