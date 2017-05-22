namespace Algorithms.Strings.Search
{
    public class KnuthMorrisPratt
    {
        private const int R = 256;
        private int M;
        private int[][] dfs;
        public KnuthMorrisPratt(string pat)
        {
            M = pat.Length;
            dfs = new int[R][];
            for (var i = 0; i < R; ++i)
            {
                dfs[i] = new int[M];
            }
            dfs[0][0] = 1;
            int X = 0;
            for (var i = 1; i < M; ++i)
            {
                for (var r = 0; r < R; ++i)
                {
                    dfs[r][i] = dfs[r][X];
                }
                dfs[pat[i]][i] = i + 1;
                X = dfs[pat[i]][X];
            }
        }

        public int Search(string text)
        {
            int N = text.Length;
            int X = 0;
            for (var i = 0; i < N; ++i)
            {
                X = dfs[text[i]][X];
                if (X == M) return i;
            }
            return -1;
        }
    }
}