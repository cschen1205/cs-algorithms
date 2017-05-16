using Algorithms.DataStructures.Graphs;
using Algorithms.Graphs.MST;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.Graphs.MST
{
    public class LazyPrimUnitTest
    {
        private ITestOutputHelper console;
        public LazyPrimUnitTest(ITestOutputHelper console)
        {
            this.console = console;
        }

        [Fact]
        public void Test()
        {
            var g = GraphGenerator.edgeWeightedGraph();
            var mst = new LazyPrim(g);
            foreach(var e in mst.MST){
                console.WriteLine(e.ToString());
            }
        }
    }
}