using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresExercises.Graphs
{
    internal static class GraphExtensions
    {
        public static int FindShortestUnwightedPathBFS(this Graph<int> graph, int from, int to)
        {
            Queue<(int Vertex, int Distance)> queue = new Queue<(int Vertex, int Distance)> ();
            queue.Enqueue((from, 0));

            while (queue.TryDequeue(out var prevNode))
            {
                if (prevNode.Vertex == to)
                {
                    return prevNode.Distance;
                }

                var edges = graph.GetEdges(prevNode.Vertex);
                if (edges == null || !edges.Any())
                    continue;


                foreach (var edge in edges)
                {
                    queue.Enqueue((edge.Key, prevNode.Distance + 1));
                }
            }
            return -1;
        }

        internal static int FindShortestWeightedPathDijkstra<T>(this Graph<T> graph, T startNode, T targetNode) where T : IEquatable<T>
        {
            //init
            HashSet<T> unvisited = new HashSet<T>(graph.GraphState.Keys);

            Dictionary<T, int> VertexDistances = new Dictionary<T, int> ();
            foreach (var vertex in graph.GraphState)
            {
                VertexDistances[vertex.Key] = vertex.Key.Equals(startNode) ? 0 : int.MaxValue;
            }
            
            var currentNode = startNode;
            while (unvisited.Count > 0)
            {
                unvisited.Remove(currentNode);

                (T edge,int distance)? nearestEdge = null;
                foreach (var edge in graph.GetEdges(currentNode))
                {

                    var fromStartMinDistance = Math.Min(VertexDistances[currentNode] + edge.Value, VertexDistances[edge.Key]);
                    VertexDistances[edge.Key] = fromStartMinDistance;
                    if(unvisited.Contains(edge.Key) && (nearestEdge == null || nearestEdge.Value.distance > fromStartMinDistance))
                    {
                        nearestEdge = (edge.Key, fromStartMinDistance);
                    }                    
                }
                currentNode = nearestEdge.Value.edge;

                if (currentNode.Equals(targetNode))
                    break;
            }

            VertexDistances.TryGetValue(targetNode,out var distance);
            return distance;
        }
    }
}
