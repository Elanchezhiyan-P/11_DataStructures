using _11_DataStructures.Model;

namespace _11_DataStructures.Algo
{
    internal class Trie
    {
        private TrieNode root;

        public Trie()
        {
            root = new TrieNode();  // Create a root node
        }

        // Method to insert a word into the Trie
        public void Insert(string word)
        {
            TrieNode current = root;

            foreach (char c in word)
            {
                if (!current.Children.ContainsKey(c))
                {
                    current.Children[c] = new TrieNode();  // Create a new node if the character is not found
                }
                current = current.Children[c];  // Move to the next node
            }
            current.IsEndOfWord = true;  // Mark the end of the word
        }

        // Method to search for a word in the Trie
        public bool Search(string word)
        {
            TrieNode current = root;

            foreach (char c in word)
            {
                if (!current.Children.ContainsKey(c))
                {
                    return false;  // Word not found
                }
                current = current.Children[c];  // Move to the next node
            }
            return current.IsEndOfWord;  // Return true if the word is found and ends at a valid word node
        }

        // Method to check if there is any word that starts with the given prefix
        public bool StartsWith(string prefix)
        {
            TrieNode current = root;

            foreach (char c in prefix)
            {
                if (!current.Children.ContainsKey(c))
                {
                    return false;  // No word starts with this prefix
                }
                current = current.Children[c];  // Move to the next node
            }
            return true;  // Prefix exists
        }
    }
}
