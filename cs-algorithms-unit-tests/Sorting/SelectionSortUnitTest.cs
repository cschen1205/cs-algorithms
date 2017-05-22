using Algorithms.Sorting;
using Xunit;

namespace AlgorithmsUnitTest.Sorting
{
    public class SelectionSortUnitTest
    {
        [Fact]
        public void testSort()
        {
            var a = new[] {5, 4, 3, 2, 6, 1, 0};
            SelectionSort.Sort(a);
            Assert.Equal(new[]{0, 1, 2, 3, 4, 5, 6}, a);
        }
    }
}