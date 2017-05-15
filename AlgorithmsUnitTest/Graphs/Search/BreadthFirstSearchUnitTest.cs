using Algorithms.DataStructures.Graphs;
using Algorithms.Graphs.Search;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.Graphs.Search
{
    public class BreadthFirstSearchUnitTest
    {
        private ITestOutputHelper console;
        public BreadthFirstSearchUnitTest(ITestOutputHelper console)
        {
            this.console = console;
        }

        [Fact]
        public void TestSearch()
        {
            var g = GraphGenerator.graph();

            var s = 0;
            var dfs = new BreadthFirstSearch(g, s);

            for(var v=0; v < g.V(); ++v) {
                if (!dfs.CanReach(v)) continue;
                console.WriteLine(s + " is connected to " + v);
                console.WriteLine("path: " + dfs.PathToString(v));
            }
        }
    }
}