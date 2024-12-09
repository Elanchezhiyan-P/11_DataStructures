using _11_DataStructures.Model;
using System;

namespace _11_DataStructures.Algo
{
    internal class LinkedList
    {
        private Node head;  // Reference to the first node (head) of the list

        public LinkedList()
        {
            head = null;  // Initially, the list is empty
        }

        // Method to add a node at the end of the linked list
        public void Add(int value)
        {
            Node newNode = new Node(value);  // Create a new node with the given value

            if (head == null)
            {
                // If the list is empty, the new node becomes the head
                head = newNode;
            }
            else
            {
                // If the list is not empty, traverse to the last node and add the new node
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;  // Set the next reference of the last node to the new node
            }
        }

        // Method to display the linked list
        public void Display()
        {
            Node current = head;  // Start from the head
            while (current != null)
            {
                Console.Write(current.Value + " ");  // Print the value of the current node
                current = current.Next;  // Move to the next node
            }
            Console.WriteLine();  // Print a new line at the end
        }
    }
}
