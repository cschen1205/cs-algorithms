using Xunit;
using DataStructures.Stack;

namespace AlgorithmsUnitTest.DataStrutures.Stack
{
    public class StackArrayUnitTest
    {
        [Fact]
        public void TestStack()
        {
            var stack = new StackArray<int>();
            stack.Push(10);
            stack.Push(20);
            Assert.Equal(2, stack.Count);
            Assert.False(stack.IsEmpty);
            Assert.Equal(20, stack.Pop());
            Assert.Equal(10, stack.Pop());
            Assert.True(stack.IsEmpty);
        }
    }
}