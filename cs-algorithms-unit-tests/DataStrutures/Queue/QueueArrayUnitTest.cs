using Algorithms.DataStructures.Queue;
using Xunit;

namespace AlgorithmsUnitTest.DataStrutures.Queue
{
    public class QueueArrayUnitTest
    {
        [Fact]
        public void TestQueue()
        {
            var queue = new QueueArray<int>();
            queue.Enqueue(10);
            Assert.Equal(1, queue.Count);
            queue.Enqueue(20);
            Assert.Equal(2, queue.Count);
            Assert.False(queue.IsEmpty);
            Assert.Equal(10, queue.Dequeue());
            Assert.Equal(20, queue.Dequeue());
            Assert.True(queue.IsEmpty);
        }
    }
}