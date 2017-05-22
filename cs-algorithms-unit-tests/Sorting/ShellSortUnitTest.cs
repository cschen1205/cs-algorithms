using Algorithms.Shuffling;
using Algorithms.Sorting;
using Xunit;

namespace AlgorithmsUnitTest.Sorting
{
    public class ShellSortUnitTest
    {
        [Fact]
        public void testSort()
        {
            var a = new int[100];
            var b = new int[100];
            for (var i = 0; i < a.Length; ++i)
            {
                a[i] = i;
                b[i] = i;
            }
            KnuthShuffle.Shuffle(a);
            Assert.NotEqual(b, a);
            ShellSort.Sort(a);
            Assert.Equal(b, a);
        }
    }
}