using System.Linq;
using Algorithms.DataStructures.Queue;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.DataStrutures.Queue
{
    public class IndexMinPQUnitTest
    {
        private ITestOutputHelper console;

        public IndexMinPQUnitTest(ITestOutputHelper console)
        {
            this.console = console;
        }

        [Fact]
        public void Test()
        {
            var pq = new IndexMinPQ<int>(10);

            pq.Enqueue(1, 20);
            pq.Enqueue(2, 15);

            Assert.Equal(15, pq.MinKey());

            pq.Enqueue(1, 10);

            Assert.Equal(10, pq.MinKey());

            pq.Enqueue(3, 11);

            Assert.Equal(1, pq.DelMin());

            Assert.Equal(11, pq.MinKey());

            Assert.Equal(2, pq.Count);

            Assert.False(pq.IsEmpty);

            pq.Enqueue(2, 10);

            Assert.Equal(10, pq.MinKey());
            Assert.Equal(2, pq.DelMin());

            foreach (var v in pq)
            {
                console.WriteLine("key: {0}", v);
            }



        }
    }
}