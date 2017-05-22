using Algorithms.DataStructures.Graphs;
using Algorithms.Graphs.TopologicalSort;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.Graphs.TopologicalSort
{
    public class DepthFirstPostOrderUnitTest
    {
        private ITestOutputHelper console;

        public DepthFirstPostOrderUnitTest(ITestOutputHelper console)
        {
            this.console = console;
        }

        [Fact]
        public void Test()
        {
            DiGraph dag = GraphGenerator.dag();

            var dfo = new DepthFirstPostOrder(dag);
            console.WriteLine(dfo.PostOrderToString());
        }
    }
}