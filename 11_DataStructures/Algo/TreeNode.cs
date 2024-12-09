using System;
using System.Collections.Generic;

namespace _11_DataStructures
{
    internal class TreeNode
    {
        public int Value { get; set; }  // Value of the node
        public List<TreeNode> Children { get; set; }  // List of child nodes

        // Constructor to initialize the node with a value
        public TreeNode(int value)
        {
            Value = value;
            Children = new List<TreeNode>();
        }

        // Method to add a child node
        public void AddChild(TreeNode child)
        {
            Children.Add(child);
        }

        // Method to display the tree (DFS - Depth First Search)
        public void Display(int level = 0)
        {
            // Print the value of the node, with indentation based on level in the tree
            Console.WriteLine(new string(' ', level * 2) + Value);

            // Recursively print the children
            foreach (var child in Children)
            {
                child.Display(level + 1);
            }
        }
    }
}
