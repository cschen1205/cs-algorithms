using Algorithms.Shuffling;
using Algorithms.Sorting;
using Xunit;

namespace AlgorithmsUnitTest.Sorting
{
    public class QuickSortUnitTest
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
            QuickSort.Sort(a);
            for (var i = 0; i < a.Length; ++i)
            {
                Assert.Equal(b[i], a[i]);
            }
        }
    }
}