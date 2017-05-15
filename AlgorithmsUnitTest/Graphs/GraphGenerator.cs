using Algorithms.DataStructures.Graphs;

namespace AlgorithmsUnitTest.Graphs
{
    public class GraphGenerator
    {
        public static Graph graph(){
            var g = new Graph(6);
            g.addEdge(0, 5);
            g.addEdge(2, 4);
            g.addEdge(2, 3);
            g.addEdge(1, 2);
            g.addEdge(0, 1);
            g.addEdge(3, 4);
            g.addEdge(3, 5);
            g.addEdge(0, 2);

            return g;
        }
    }
}