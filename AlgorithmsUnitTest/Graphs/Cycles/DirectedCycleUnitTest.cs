using Algorithms.DataStructures.Graphs;
using Algorithms.Graphs.Cycles;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.Graphs.Cycles
{
    public class DirectedCycleUnitTest
    {
        private ITestOutputHelper console;

        public DirectedCycleUnitTest(ITestOutputHelper console)
        {
            this.console = console;
        }

        [Fact]
        public void Test()
        {
            var G1 = GraphGenerator.dag();
            var dc = new DirectedCycles(G1);
            console.WriteLine("dag has cycles: " + dc.HasCycle);


        }
    }
}