using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DataStructures.Algo
{
    internal class HashMap
    {
        private class Node
        {
            public string Key;
            public int Value;
            public Node Next;

            public Node(string key, int value)
            {
                Key = key;
                Value = value;
                Next = null;
            }
        }

        private Node[] buckets;
        private const int Size = 10; // Size of the hash table

        public HashMap()
        {
            buckets = new Node[Size];
        }

        // Simple hash function
        private int GetHash(string key)
        {
            int hash = 0;
            foreach (char c in key)
            {
                hash = (hash + c) % Size;
            }
            return hash;
        }

        // Insert a key-value pair into the HashMap
        public void Insert(string key, int value)
        {
            int index = GetHash(key);
            Node newNode = new Node(key, value);

            if (buckets[index] == null)
            {
                // No collision, insert the node
                buckets[index] = newNode;
            }
            else
            {
                // Handle collision by chaining (linked list)
                Node current = buckets[index];
                while (current.Next != null)
                {
                    if (current.Key == key)
                    {
                        // Key already exists, update value
                        current.Value = value;
                        return;
                    }
                    current = current.Next;
                }
                // Insert at the end of the linked list
                current.Next = newNode;
            }
        }

        // Retrieve a value by key
        public int? Get(string key)
        {
            int index = GetHash(key);
            Node current = buckets[index];

            while (current != null)
            {
                if (current.Key == key)
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return null; // Key not found
        }

        // Remove a key-value pair
        public void Remove(string key)
        {
            int index = GetHash(key);
            Node current = buckets[index];
            Node previous = null;

            while (current != null)
            {
                if (current.Key == key)
                {
                    if (previous == null)
                    {
                        // Remove the first node in the list
                        buckets[index] = current.Next;
                    }
                    else
                    {
                        // Remove from the linked list
                        previous.Next = current.Next;
                    }
                    return;
                }
                previous = current;
                current = current.Next;
            }
        }
    }
}
