using System;

namespace _11_DataStructures.Algo
{
    internal class MaxHeap
    {
        private int[] heap;
        private int size;
        private const int Capacity = 10;

        public MaxHeap()
        {
            heap = new int[Capacity];
            size = 0;
        }

        // Helper method to swap two elements in the heap
        private void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        // Insert a new element into the heap
        public void Insert(int value)
        {
            if (size >= Capacity)
            {
                Console.WriteLine("Heap is full");
                return;
            }

            // Insert the new value at the end of the heap
            heap[size] = value;
            int current = size;

            // "Bubble up" the new value to restore the max heap property
            while (current > 0 && heap[current] > heap[(current - 1) / 2])
            {
                Swap(current, (current - 1) / 2);
                current = (current - 1) / 2;
            }

            size++;
        }

        // Extract the maximum (root) element from the heap
        public int ExtractMax()
        {
            if (size == 0)
            {
                Console.WriteLine("Heap is empty");
                return -1;
            }

            int max = heap[0];

            // Move the last element to the root
            heap[0] = heap[size - 1];
            size--;

            // "Bubble down" the root element to restore the max heap property
            MaxHeapify(0);

            return max;
        }

        // Ensure the max heap property is maintained at index i
        private void MaxHeapify(int i)
        {
            int leftChild = 2 * i + 1;
            int rightChild = 2 * i + 2;
            int largest = i;

            // Find the largest among the root, left child, and right child
            if (leftChild < size && heap[leftChild] > heap[largest])
            {
                largest = leftChild;
            }

            if (rightChild < size && heap[rightChild] > heap[largest])
            {
                largest = rightChild;
            }

            // If the largest is not the root, swap and recursively heapify the affected subtree
            if (largest != i)
            {
                Swap(i, largest);
                MaxHeapify(largest);
            }
        }

        // Peek the maximum element without removing it
        public int PeekMax()
        {
            if (size == 0)
            {
                Console.WriteLine("Heap is empty");
                return -1;
            }
            return heap[0];
        }

        // Get the number of elements in the heap
        public int GetSize()
        {
            return size;
        }
    }
}
