using System;
using System.Collections.Generic;

namespace _11_DataStructures
{
    internal class Graph
    {
        private Dictionary<string, List<string>> adjList;

        public Graph()
        {
            adjList = new Dictionary<string, List<string>>();
        }

        public void AddNode(string node)
        {
            // Only add the node if it doesn't already exist
            if (!adjList.ContainsKey(node))
            {
                adjList[node] = new List<string>();
            }
        }

        // Add an edge between two nodes
        public void AddEdge(string node1, string node2)
        {
            // Make sure both nodes exist before connecting them
            if (!adjList.ContainsKey(node1))
            {
                AddNode(node1);
            }
            if (!adjList.ContainsKey(node2))
            {
                AddNode(node2);
            }

            // Add the connection in both directions (undirected)
            adjList[node1].Add(node2);
            adjList[node2].Add(node1);
        }

        public void DisplayGraph()
        {
            foreach (var vertex in adjList)
            {
                Console.Write(vertex.Key + ": ");
                foreach (var neighbor in vertex.Value)
                {
                    Console.Write(neighbor + " ");
                }
                Console.WriteLine();
            }
        }
    }
}