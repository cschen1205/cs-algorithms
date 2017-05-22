namespace Algorithms.Strings.Sort
{
    public class LSD
    {
        public static void Sort(string[] a)
        {
            var N = a.Length;
            var M = a[0].Length;

            var R = 256;

            var aux = new string[N];

            for (var d = M-1; d >= 0; --d)
            {
                var counts = new int[R + 1];

                for (var i = 0; i < N; ++i)
                {
                    counts[a[i][d]+1]++;
                }

                for (var r = 0; r < R; ++r)
                {
                    counts[r + 1] += counts[r];
                }

                for (var i = 0; i < N; ++i)
                {
                    aux[counts[a[i][d]]++] = a[i];
                }

                for (var i = 0; i < N; ++i)
                {
                    a[i] = aux[i];
                }
            }
        }
    }
}