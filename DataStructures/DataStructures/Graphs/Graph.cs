using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresExercises.Graphs
{
    internal class Graph<T>
    {
        internal Dictionary<T, Dictionary<T,int>> GraphState;

        public Graph()
        {
            GraphState = new Dictionary<T, Dictionary<T, int>>();
        }
        
        internal Dictionary<T, int> AddOrGetVertex(T vertex)
        {            
            if (!GraphState.TryGetValue(vertex,out var edges))
            {
                edges = new Dictionary<T, int>();
                GraphState[vertex] = edges;
            }
            return edges;
        }

        internal Dictionary<T, int> GetEdges(T vertex)
        {
            this.GraphState.TryGetValue(vertex, out var edges);
            return edges ?? new Dictionary<T, int>();
        }

        internal void RemoveVertex(T vertex)
        {
            if (!GraphState.Remove(vertex, out _))
            {
                throw new InvalidOperationException("Vertex doesnt exists");
            }
        }

        internal void AddEdge(T fromVertex,T toVertex, int weight)
        {
            if (!GraphState.TryGetValue(fromVertex, out var edges))
            {
                edges = AddOrGetVertex(fromVertex);
            }
            AddOrGetVertex(toVertex);
            edges.Add(toVertex, weight);
        }

        internal void Print()
        {
            foreach (var vertexEntry in GraphState)
            {
                Console.WriteLine($"{vertexEntry.Key}:{string.Join(',',vertexEntry.Value.OrderBy(e=>e.Value).Select(e=>e.Key))}");
            }
        }

        

        private void InitGraph<T>()
        {
            HashSet<T> visited = new HashSet<T>();
        }
    }
}
