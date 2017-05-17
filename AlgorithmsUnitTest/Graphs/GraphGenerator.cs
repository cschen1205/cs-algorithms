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

        //directed acyclic graph
        public static DiGraph dag(){
            var dag = new DiGraph(7);

            dag.addEdge(0, 5);
            dag.addEdge(0, 2);
            dag.addEdge(0, 1);
            dag.addEdge(3, 6);
            dag.addEdge(3, 5);
            dag.addEdge(3, 4);
            dag.addEdge(5, 4);
            dag.addEdge(6, 4);
            dag.addEdge(6, 0);
            dag.addEdge(3, 2);
            dag.addEdge(1, 4);






            return dag;
        }

        public static Graph graph4ConnectedComponents() {
            var g = new Graph(13);
            g.addEdge(0, 5);
            g.addEdge(4, 3);
            g.addEdge(0, 1);
            g.addEdge(9, 12);
            g.addEdge(6, 4);
            g.addEdge(5, 4);
            g.addEdge(0, 2);
            g.addEdge(11, 12);
            g.addEdge(9,10);
            g.addEdge(0, 6);
            g.addEdge(7, 8);
            g.addEdge(9, 11);
            g.addEdge(5, 3);
            return g;
        }

        public static DiGraph dag4StronglyConnectedComponents(){
            var graph = new DiGraph(13);
            graph.addEdge(4, 2);
            graph.addEdge(2, 3);
            graph.addEdge(3, 2);
            graph.addEdge(6, 0);
            graph.addEdge(0, 1);
            graph.addEdge(2, 0);
            graph.addEdge(11, 12);
            graph.addEdge(12, 9);
            graph.addEdge(9, 10);
            graph.addEdge(9, 11);
            graph.addEdge(8, 9);
            graph.addEdge(10, 12);
            graph.addEdge(11, 4);
            graph.addEdge(4, 3);
            graph.addEdge(3, 5);
            graph.addEdge(7, 8);
            graph.addEdge(8, 7);
            graph.addEdge(5, 4);
            graph.addEdge(0, 5);
            graph.addEdge(6, 4);
            graph.addEdge(6, 9);
            graph.addEdge(7, 6);

            return graph;
        }

        public static WeightedGraph edgeWeightedGraph(){
            var g = new WeightedGraph(8);
            g.addEdge(new Edge(0, 7, 0.16));
            g.addEdge(new Edge(2, 3, 0.17));
            g.addEdge(new Edge(1, 7, 0.19));
            g.addEdge(new Edge(0, 2, 0.26));
            g.addEdge(new Edge(5, 7, 0.28));
            g.addEdge(new Edge(1, 3, 0.29));
            g.addEdge(new Edge(1, 5, 0.32));
            g.addEdge(new Edge(2, 7, 0.34));
            g.addEdge(new Edge(4, 5, 0.35));
            g.addEdge(new Edge(1, 2, 0.36));
            g.addEdge(new Edge(4, 7, 0.37));
            g.addEdge(new Edge(0, 4, 0.38));
            g.addEdge(new Edge(6, 2, 0.4));
            g.addEdge(new Edge(3, 6, 0.52));
            g.addEdge(new Edge(6, 0, 0.58));
            g.addEdge(new Edge(6, 4, 0.93));

            return g;
        }


        public static WeightedDiGraph directedEdgeWeightedGraph()
        {
            var g = new WeightedDiGraph(8);
            
            g.addEdge(new Edge(0, 1, 5.0));
            g.addEdge(new Edge(0, 4, 9.0));
            g.addEdge(new Edge(0, 7, 8.0));
            g.addEdge(new Edge(1, 2, 12.0));
            g.addEdge(new Edge(1, 3, 15.0));
            g.addEdge(new Edge(1, 7, 4.0));
            g.addEdge(new Edge(2, 3, 3.0));
            g.addEdge(new Edge(2, 6, 11.0));
            g.addEdge(new Edge(3, 6, 9.0));
            g.addEdge(new Edge(4, 5, 5.0));
            g.addEdge(new Edge(4, 6, 20.0));
            g.addEdge(new Edge(4, 7, 5.0));
            g.addEdge(new Edge(5, 2, 1.0));
            g.addEdge(new Edge(5, 6, 13.0));
            g.addEdge(new Edge(7, 5, 6.0));
            g.addEdge(new Edge(7, 2, 7.0));
            return g;

        }
    }


}