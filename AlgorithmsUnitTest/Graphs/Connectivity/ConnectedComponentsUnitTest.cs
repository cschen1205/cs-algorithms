using Algorithms.DataStructures.Graphs;
using Algorithms.Graphs.Connectivity;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.Graphs.Connectivity
{
    public class ConnectedComponentsUnitTest
    {
        private ITestOutputHelper console;
        public ConnectedComponentsUnitTest(ITestOutputHelper console)
        {
            this.console = console;
        }

        [Fact]
        public void Test()
        {
            var g = GraphGenerator.graph4ConnectedComponents();
            var cc = new ConnectedComponents(g);
            console.WriteLine("count: {0}", cc.Count);
            for(var v = 0;  v < g.V(); ++v) {
                console.WriteLine(v + "\t:" + cc.componentId(v));
            }
        }
    }
}