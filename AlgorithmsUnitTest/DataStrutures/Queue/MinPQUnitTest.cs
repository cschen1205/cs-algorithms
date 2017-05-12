using Algorithms.DataStructures.Queue;
using Xunit;

namespace AlgorithmsUnitTest.DataStrutures.Queue
{
    public class MinPQUnitTest
    {
        [Fact]
        public void TestMinPQ()
        {
            MinPQ<int> pq = new MinPQ<int>();

            for (var i = 0; i < 100; ++i)
            {
                pq.Enqueue(99-i);
            }
            Assert.Equal(100, pq.Count);
            Assert.False(pq.IsEmpty);
            for (var i = 0; i < 100; ++i)
            {
                Assert.Equal(i, pq.DelMin());
                Assert.Equal(99-i, pq.Count);
            }
            Assert.True(pq.IsEmpty);
        }
    }
}