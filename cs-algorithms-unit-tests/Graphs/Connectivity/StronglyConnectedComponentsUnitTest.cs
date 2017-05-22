using Algorithms.DataStructures.Graphs;
using Algorithms.Graphs.Connectivity;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.Graphs.Connectivity
{
    public class StronglyConnectedComponentsUnitTest
    {
        private ITestOutputHelper console;
        public StronglyConnectedComponentsUnitTest(ITestOutputHelper console)
        {
            this.console = console;
        }

        [Fact]
        public void Test()
        {
            var g = GraphGenerator.dag4StronglyConnectedComponents();

            var scc = new StronglyConnectedComponents(g);

            for(var v = 0; v < g.V(); ++v){
                console.WriteLine(v + "\t:" + scc.componentId(v));
            }
        }
    }
}