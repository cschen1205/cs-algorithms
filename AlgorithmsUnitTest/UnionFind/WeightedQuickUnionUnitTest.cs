using CSChen.Algorithms.UnionFind;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.UnionFind
{
    public class WeightedQuickUnionUnitTest
    {
        private readonly ITestOutputHelper logger;
        public WeightedQuickUnionUnitTest(ITestOutputHelper console)
        {
            this.logger = console;
        }

        [Fact]
        public void test_union_find()
        {
            var uf = new QuickUnion(10);
            uf.Union(1, 3);
            uf.Union(2, 3);
            uf.Union(5, 6);
            uf.Union(4, 5);

            Assert.True(uf.IsConnected(1, 3));
            Assert.True(uf.IsConnected(2, 3));
            Assert.True(uf.IsConnected(1, 2));
            Assert.True(uf.IsConnected(4, 5));
            Assert.True(uf.IsConnected(4, 6));
            Assert.False(uf.IsConnected(1, 6));
            Assert.False(uf.IsConnected(3, 4));

            this.logger.WriteLine("Connected: {1, 2, 3}");
        }
    }
}