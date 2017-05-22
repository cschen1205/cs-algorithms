namespace Algorithms.Strings.Sort
{
    public class MSD
    {
        public static void Sort(string[] a)
        {
            string[] aux = new string[a.Length];
            Sort(a, aux, 0, a.Length-1, 0);
        }

        private static void Sort(string[] a, string[] aux, int lo, int hi, int d)
        {
            if (lo >= hi) return;

            var R = 256;
            var count = new int[R + 2];

            for (var i = lo; i <= hi; ++i)
            {
                count[charAt(a[i], d) + 2]++;
            }

            for (var r = 0; r < R + 1; ++r)
            {
                count[r + 1] += count[r];
            }

            for (var i = lo; i <= hi; ++i)
            {
                aux[count[charAt(a[i], d) + 1]++] = a[i];
            }

            for (var i = lo; i <= hi; ++i)
            {
                a[i] = aux[i-lo];
            }

            for (var r = 0; r < R+1; ++r)
            {
                Sort(a, aux, lo + count[r], lo + count[r+1]-1, d+1);
            }
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