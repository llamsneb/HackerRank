using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class MinHeap
    {
        public List<int> heap = new List<int>();

        public void Insert(int value)
        {
            // Add the new element to the end of the heap
            heap.Add(value);
            // Get the index of the last element
            int i = heap.Count - 1;
            // Compare the new element with its parent and swap if necessary
            while (i > 0 && heap[(i - 1) / 2] > heap[i])
            {
                int temp = heap[i];
                heap[i] = heap[(i - 1) / 2];
                heap[(i - 1) / 2] = temp;
                // Move up the tree to the parent of the current element
                i = (i - 1) / 2;
            }
        }

        public void Delete(int value)
        {
            int i = heap.IndexOf(value);
            if (i == -1)
            {
                return;
            }
            heap[i] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            Heapify(i);
        }

        public void Heapify(int i)
        {
            int smallest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            // Compare the left child with the current smallest node.
            if (left < heap.Count && heap[left] < heap[smallest])
            {
                smallest = left;
            }
            // Compare the right child with the current smallest node.
            if (right < heap.Count && heap[right] < heap[smallest])
            {
                smallest = right;
            }
            // If the current node is not the smallest, swap it with the smallest child.
            if (smallest != i)
            {
                int temp = heap[i];
                heap[i] = heap[smallest];
                heap[smallest] = temp;
                // Recursively call minHeapify on the affected subtree.
                Heapify(smallest);
            }
        }
    }
}
