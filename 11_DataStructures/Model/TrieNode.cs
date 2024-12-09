using System.Collections.Generic;

namespace _11_DataStructures.Model
{
    internal class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; }  // Children of the current node
        public bool IsEndOfWord { get; set; }  // Flag to mark the end of a word

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            IsEndOfWord = false;
        }
    }
}
