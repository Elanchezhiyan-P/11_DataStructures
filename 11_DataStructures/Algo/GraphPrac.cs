using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DataStructures.Algo
{
    internal class GraphPrac
    {
        private Dictionary<string, List<Edge>> adjList;

        // Edge class to store the destination and the distance (distance)
        public class Edge
        {
            public string Destination { get; set; }
            public int Distance { get; set; }

            public Edge(string destination, int weight)
            {
                Destination = destination;
                Distance = weight;
            }
        }

        // Constructor to initialize the graph
        public GraphPrac()
        {
            adjList = new Dictionary<string, List<Edge>>();
        }

        // Add a node (intersection) to the graph
        public void AddNode(string node)
        {
            if (!adjList.ContainsKey(node))
            {
                adjList[node] = new List<Edge>();
            }
        }

        // Add an edge (road) between two nodes
        public void AddEdge(string node1, string node2, int distance)
        {
            AddNode(node1);
            AddNode(node2);

            adjList[node1].Add(new Edge(node2, distance));
            adjList[node2].Add(new Edge(node1, distance));  // Undirected graph
        }

        // Dijkstra's algorithm to find the shortest path
        public Dictionary<string, int> Dijkstra(string start)
        {
            // Dictionary to hold the shortest distances from the start node
            var distances = adjList.ToDictionary(n => n.Key, n => int.MaxValue);
            distances[start] = 0;

            // Min-heap (priority queue) to pick the node with the smallest distance
            var priorityQueue = new SortedSet<(int distance, string node)>(new TupleComparer());
            priorityQueue.Add((0, start));

            while (priorityQueue.Count > 0)
            {
                // Get the node with the smallest distance
                var (currentDistance, currentNode) = priorityQueue.Min;
                priorityQueue.Remove(priorityQueue.Min);

                // Explore all neighbors of the current node
                foreach (var neighbor in adjList[currentNode])
                {
                    var newDistance = currentDistance + neighbor.Distance;

                    // If a shorter path is found, update the distance
                    if (newDistance < distances[neighbor.Destination])
                    {
                        distances[neighbor.Destination] = newDistance;
                        priorityQueue.Add((newDistance, neighbor.Destination));
                    }
                }
            }

            return distances;
        }

        private class TupleComparer : IComparer<(int distance, string node)>
        {
            public int Compare((int distance, string node) x, (int distance, string node) y)
            {
                // First, compare by distance
                int compareResult = x.distance.CompareTo(y.distance);
                if (compareResult == 0)
                {
                    // If distances are equal, compare by node (alphabetical order)
                    compareResult = x.node.CompareTo(y.node);
                }
                return compareResult;
            }
        }
    }
}
