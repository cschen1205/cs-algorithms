using Algorithms.DataStructures.Graphs;
using Algorithms.Graphs.MST;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.Graphs.MST
{
    public class KruskalUnitTest
    {
        private ITestOutputHelper console;
        public KruskalUnitTest(ITestOutputHelper console)
        {
            this.console = console;
        }

        [Fact]
        public void Test()
        {
            var g = GraphGenerator.edgeWeightedGraph();
            var mst = new Kruskal(g);
            foreach(var e in mst.MST){
                console.WriteLine(e.ToString());
            }
        }
    }
}