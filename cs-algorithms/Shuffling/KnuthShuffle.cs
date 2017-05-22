using System;
using System.Runtime.CompilerServices;
using Algorithms.Utils;

namespace Algorithms.Shuffling
{
    public class KnuthShuffle
    {

        public static void Shuffle<T>(T[] a)
        {
            var random = new Random();
            for (var i = 1; i < a.Length; ++i)
            {
                var j = random.Next(i + 1);
                SortUtil.Exchange(a, i, j);
            }
        }
    }
}