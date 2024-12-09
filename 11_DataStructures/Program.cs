using _11_DataStructures.Algo;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _11_DataStructures
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var credential = new DefaultAzureCredential();

                // Get the token for the given resource (Azure AD)
                var token = await credential.GetTokenAsync(new Azure.Core.TokenRequestContext(new[] { "https://graph.microsoft.com/.default" }));

                // The Tenant ID can be extracted from the JWT token claims
                var tenantId = token.Token.Split('.')[1];
                var json = System.Text.Json.JsonDocument.Parse(Base64UrlDecode(tenantId));
                var tenantIdClaim = json.RootElement.GetProperty("tid").GetString();

                Console.WriteLine($"Tenant ID: {tenantIdClaim}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                var client = new SecretClient(new Uri("https://scn-dc-test-vault.vault.azure.net/"), new DefaultAzureCredential());

                KeyVaultSecret secret = client.GetSecret("FromMailId");
                Console.WriteLine(secret.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<string> names = new List<string>(); 
            names.Add("Alice");

            List<string> anotherList = names;  

            names.Add("Bob");
            Console.WriteLine(anotherList.Count);

            #region Array

            int[] listOfData = new int[6];

            listOfData[0] = 48;
            listOfData[1] = 2;
            listOfData[2] = 79;
            listOfData[3] = 100;
            listOfData[4] = 88;
            listOfData[5] = 77;

            Console.WriteLine("Array values are about to print: ");

            foreach (int i in listOfData)
            {
                Console.WriteLine(i);
            }

            #endregion

            #region 2D Array

            Console.WriteLine();

            int[,] array = new int[3, 2];

            array[0, 0] = 1;
            array[0, 1] = 2;
            array[1, 0] = 3;
            array[1, 1] = 4;
            array[2, 0] = 5;
            array[2, 1] = 6;

            Console.WriteLine("2D Array values are about to print: ");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            #endregion

            #region Queue

            Console.WriteLine();

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(100);
            queue.Enqueue(200);
            queue.Enqueue(300);
            queue.Enqueue(400);

            Console.WriteLine("Queue values are about to print: ");

            for (int i = 0; i < queue.Count; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }

            #endregion

            #region Stack

            Console.WriteLine();

            Stack<int> stack = new Stack<int>();

            stack.Push(100);
            stack.Push(200);
            stack.Push(300);
            stack.Push(400);

            Console.WriteLine("Stack values are about to print: ");

            for (int i = 0; i < stack.Count; i++)
            {
                Console.WriteLine(stack.Pop());
            }

            #endregion

            #region Graph

            Console.WriteLine();

            Graph graph = new Graph();

            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");

            // Add edges (friendship connections)
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "C");

            Console.WriteLine("Graph values are about to print: ");

            graph.DisplayGraph();

            //Practical Example:

            Console.WriteLine();

            GraphPrac cityGraph = new GraphPrac();

            // Add roads between intersections (nodes)
            cityGraph.AddEdge("Agra", "Bangalore", 1800);
            cityGraph.AddEdge("Agra", "Coimbatore", 2100);
            cityGraph.AddEdge("Bangalore", "Coimbatore", 370);
            cityGraph.AddEdge("Bangalore", "Delhi", 2100);
            cityGraph.AddEdge("Coimbatore", "Delhi", 2300);
            cityGraph.AddEdge("Delhi", "Kerala", 2700);
            cityGraph.AddEdge("Coimbatore", "Kerala", 200);

            // Find the shortest paths from node A
            var shortestPaths = cityGraph.Dijkstra("Agra");

            // Print out the shortest distances from A to all other nodes
            Console.WriteLine("Shortest distances from Agra:");
            foreach (var node in shortestPaths)
            {
                Console.WriteLine($"{node.Key}: {node.Value}");
            }

            #endregion

            #region Tree

            Console.WriteLine();

            TreeNode root = new TreeNode(1);

            // Create child nodes
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);

            // Add child nodes to root
            root.AddChild(node2);
            root.AddChild(node3);

            // Add child nodes to node 2
            node2.AddChild(node4);
            node2.AddChild(node5);

            // Display the tree structure
            Console.WriteLine("Tree Structure:");
            root.Display();

            #endregion

            #region Linked List

            Console.WriteLine();

            LinkedList list = new LinkedList();

            // Adding nodes to the linked list
            list.Add(10);
            list.Add(20);
            list.Add(30);

            // Display the linked list
            Console.WriteLine("Linked List:");
            list.Display();

            #endregion

            #region Trie

            Console.WriteLine();

            Trie trie = new Trie();

            // Insert words into the trie
            trie.Insert("apple");
            trie.Insert("app");
            trie.Insert("banana");

            // Search for words
            Console.WriteLine("Search 'apple': " + trie.Search("apple"));  // True
            Console.WriteLine("Search 'app': " + trie.Search("app"));  // True
            Console.WriteLine("Search 'appl': " + trie.Search("appl"));  // False
            Console.WriteLine("Search 'banana': " + trie.Search("banana"));  // True
            Console.WriteLine("Search 'ban': " + trie.Search("ban"));  // False

            // Check for prefixes
            Console.WriteLine("StartsWith 'app': " + trie.StartsWith("app"));  // True
            Console.WriteLine("StartsWith 'ban': " + trie.StartsWith("ban"));  // True
            Console.WriteLine("StartsWith 'bat': " + trie.StartsWith("bat"));  // False

            #endregion

            #region Hash Map

            Console.WriteLine();

            Dictionary<string, int> map = new Dictionary<string, int>();

            // Adding key-value pairs to the map
            map["apple"] = 10;
            map["banana"] = 20;
            map["cherry"] = 30;

            // Retrieving a value using a key
            Console.WriteLine("apple: " + map["apple"]);  // Output: 10

            // Checking if a key exists
            if (map.ContainsKey("banana"))
            {
                Console.WriteLine("banana exists with value: " + map["banana"]);  // Output: 20
            }

            // Removing a key-value pair
            map.Remove("cherry");

            // Attempting to retrieve a value after removal
            if (!map.ContainsKey("cherry"))
            {
                Console.WriteLine("cherry has been removed.");
            }

            // Iterating over the keys and values in the HashMap
            Console.WriteLine("All items in the HashMap:");
            foreach (var item in map)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            // Checking the number of key-value pairs in the dictionary
            Console.WriteLine("Number of elements in the map: " + map.Count);

            #endregion

            #region Hash Map 1

            Console.WriteLine();

            HashMap map1 = new HashMap();

            // Insert some key-value pairs
            map1.Insert("apple", 10);
            map1.Insert("banana", 20);
            map1.Insert("cherry", 30);

            // Retrieve a value
            Console.WriteLine("apple: " + map1.Get("apple"));  // Output: 10
            Console.WriteLine("banana: " + map1.Get("banana"));  // Output: 20
            Console.WriteLine("grape: " + map1.Get("grape"));  // Output: null

            // Remove a key-value pair
            map.Remove("banana");

            // Try to get the value again after removal
            Console.WriteLine("banana after removal: " + map1.Get("banana"));

            #endregion

            #region HashSet

            Console.WriteLine();

            HashSet<int> numbers = new HashSet<int>
            {
                10,
                20,
                30,
                10
            };

            // Checking if an element is in the HashSet
            Console.WriteLine("Contains 20: " + numbers.Contains(20));  // Output: True
            Console.WriteLine("Contains 40: " + numbers.Contains(40));  // Output: False

            // Removing an element from the HashSet
            numbers.Remove(20);
            Console.WriteLine("Contains 20 after removal: " + numbers.Contains(20));  // Output: False

            // Displaying all elements in the HashSet
            Console.WriteLine("All elements in the HashSet:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);  // Output: 10, 30 (unordered)
            }

            // Getting the count of elements
            Console.WriteLine("Count of elements in HashSet: " + numbers.Count);

            #endregion

            #region Max heap

            Console.WriteLine();

            MaxHeap maxHeap = new MaxHeap();

            // Insert elements into the heap
            maxHeap.Insert(10);
            maxHeap.Insert(20);
            maxHeap.Insert(30);
            maxHeap.Insert(40);
            maxHeap.Insert(50);

            // Peek the maximum element (root of the heap)
            Console.WriteLine("Max Element: " + maxHeap.PeekMax());  // Output: 50

            // Extract the maximum element
            Console.WriteLine("Extracted Max: " + maxHeap.ExtractMax());  // Output: 50

            // Peek again after extraction
            Console.WriteLine("Max Element after extraction: " + maxHeap.PeekMax());  // Output: 40

            // Insert more elements
            maxHeap.Insert(60);
            maxHeap.Insert(25);

            // Extract elements from the heap
            Console.WriteLine("Extracted Max: " + maxHeap.ExtractMax());  // Output: 60
            Console.WriteLine("Extracted Max: " + maxHeap.ExtractMax());  // Output: 40

            #endregion

            Console.Read();
        }

        public static string Base64UrlDecode(string input)
        {
            string output = input.Replace('-', '+').Replace('_', '/');
            switch (output.Length % 4) // Pad with = if needed
            {
                case 2: output += "=="; break;
                case 3: output += "="; break;
            }
            byte[] bytes = Convert.FromBase64String(output);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
    }
}
