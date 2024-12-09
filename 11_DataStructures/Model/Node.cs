namespace _11_DataStructures.Model
{
    internal class Node
    {
        public int Value;  // The value stored in the node
        public Node Next;  // Reference to the next node

        public Node(int value)
        {
            Value = value;
            Next = null;  // Initially, the next node is null
        }
    }
}
