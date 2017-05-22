using System;
using Algorithms.DataStructures.Graphs;
using Algorithms.Graphs.MaxFlow;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.Graphs.MaxFlow
{
    public class FordFulkersonUnitTest
    {
        private ITestOutputHelper console;

        public FordFulkersonUnitTest(ITestOutputHelper console)
        {
            this.console = console;
        }

        [Fact]
        public void Test()
        {
            FlowNetwork network = GraphGenerator.flowNetwork();

            FordFulkerson fordFulkerson = new FordFulkerson(network, 0, 7);
            console.WriteLine("max-flow: " + fordFulkerson.Value);
            Console.WriteLine("max-flow: " + fordFulkerson.Value);
        }
    }
}