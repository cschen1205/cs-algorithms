using Algorithms.Search;
using Xunit;

namespace AlgorithmsUnitTest.Search
{
    public class BinarySearchUnitTest
    {
        [Fact]
        public void TestSearch()
        {
            var a = new[] {1, 2, 4, 5, 7, 9};
            Assert.Equal(BinarySearch.IndexOf(a, 4), 2);
        }
    }
}