using Algorithms.DataStructures.Queue;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.DataStrutures.Queue
{
    public class MaxPQUnitTest
    {
        private ITestOutputHelper console;
        public MaxPQUnitTest(ITestOutputHelper console)
        {
            this.console = console;
        }
        [Fact]
        public void TestMaxPQ()
        {
            var pq = new MaxPQ<int>();

            for (var i = 0; i < 100; ++i)
            {
                pq.Enqueue(i);
            }
            Assert.Equal(100, pq.Count);
            Assert.False(pq.IsEmpty);
            for (var i = 0; i < 100; ++i)
            {
                Assert.Equal(99-i, pq.DelMax());
                Assert.Equal(99-i, pq.Count);
            }
            Assert.True(pq.IsEmpty);

            foreach (var v in pq)
            {
                console.WriteLine("{0}", v);
            }
        }
    }
}