using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresExercises.Graphs
{
    internal class GraphQuestions
    {
        internal static void Execute()
        {
            Graph<int> graph = new Graph<int>();

            // Add edges for an undirected graph
            graph.AddEdge(1, 2,0);
            graph.AddEdge(1, 3,0);
            graph.AddEdge(2, 4,0);
            graph.AddEdge(3, 4,0);
            graph.AddEdge(4, 5,0);
            graph.AddEdge(1, 5,0);
            //graph.AddEdge(3, 5,0);

            int startNode = 1;
            int targetNode = 5;

            int shortestPath = graph.FindShortestUnwightedPathBFS(startNode, targetNode);
            
            Console.WriteLine(shortestPath);
        }
        
        internal static void ExecuteDijkstra()
        {
            Graph<char> graph = new Graph<char>();

            // Add edges for an undirected graph
            graph.AddEdge('A', 'C',3);
            graph.AddEdge('A', 'F',2);
            graph.AddEdge('F', 'C',2);
            graph.AddEdge('F', 'E',3);
            graph.AddEdge('F', 'B',3);
            graph.AddEdge('F', 'G',5);
            graph.AddEdge('C', 'E',1);
            graph.AddEdge('C', 'D',4);
            graph.AddEdge('D', 'B',1);
            graph.AddEdge('E', 'B',2);
            graph.AddEdge('G', 'B',2);
            
            char startNode = 'A';
            char targetNode = 'B';

            int shortestPath = graph.FindShortestWeightedPathDijkstra(startNode, targetNode);
            
            Console.WriteLine(shortestPath);
        }

        
    }
}
