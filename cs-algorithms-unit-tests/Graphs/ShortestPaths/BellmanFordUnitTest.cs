using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.DataStructures.Graphs;
using Algorithms.Graphs.ShortestPaths;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.Graphs.ShortestPaths
{
    public class BellmanFordUnitTest
    {
        private ITestOutputHelper console;

        public BellmanFordUnitTest(ITestOutputHelper console)
        {
            this.console = console;
        }

        [Fact]
        public void Test()
        {
            WeightedDiGraph G = GraphGenerator.directedEdgeWeightedGraph();
            BellmanFulkerson BellmanFulkerson = new BellmanFulkerson(G, 0);
            for(var v=1; v < G.V(); ++v)
            {
                if (!BellmanFulkerson.HasPathTo(v))
                {
                    Console.WriteLine("Path not found for {0}", v);
                    continue;
                }
                IEnumerable<Edge> path = BellmanFulkerson.PathTo(v);

                console.WriteLine(ToString(path));
                Console.WriteLine(ToString(path));
            }
        }

        private String ToString(IEnumerable<Edge> path)
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (var e in path)
            {
                if (first)
                {
                    first = false;
                    sb.Append(e.from());
                }
                sb.Append("=(").Append(e.Weight).Append(")=>").Append(e.to());
            }
            return sb.ToString();
        }
    }
}