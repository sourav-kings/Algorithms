using System;
using System.Collections.Generic;
using System.Linq;

namespace Merge_K_SortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Change n at the top to change number of elements
            // in an array
            int[,] arr =  {{2, 6, 12, 34},
                     {1, 9, 20, 1000},
                     {23, 34, 90, 2000}};

            //int n = 3;
            //int k = arr.Length;
            int k = arr.GetLength(0);

            //int output = MergeKArrays(arr, n, k);

            Console.WriteLine("Merged array is ");
            MergeKSortedArrays(arr, k);

            //PrintArray(arr, n)    ;

            //Heap<int> highers = new Heap<int>("min");
        }

        // A utility function to print array elements
        static void PrintArray(int[] arr)
        {
            foreach (int i in arr)
                Console.Write(i + " ");
            Console.WriteLine();
        }

        // This function takes an array of arrays as an argument and
        // All arrays are assumed to be sorted. It merges them together
        // and prints the final sorted output.
        static void MergeKSortedArrays(int[,] arr, int k)
        {
            MinHeapNode[] hArr = new MinHeapNode[k];
            int resultSize = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                MinHeapNode node = new MinHeapNode(arr[i, 0], i, 1);
                hArr[i] = node;
                resultSize += arr.GetLength(1);
            }

            // Create a min heap with k heap nodes.  
            // Every heap node has first element of an array 
            MinHeap mh = new MinHeap(hArr, k);

            int[] result = new int[resultSize];     // To store output array 

            // Now one by one get the minimum element  
            // from min heap and replace it with  
            // next element of its array 
            for (int i = 0; i < resultSize; i++)
            {

                // Get the minimum element and 
                // store it in result 
                MinHeapNode root = mh.GetMin();
                result[i] = root.element;

                // Find the next element that will  
                // replace current root of heap.  
                // The next element belongs to same 
                // array as the current root. 
                if (root.j < arr.GetLength(1))
                    root.element = arr[root.i, root.j++];

                // If root was the last element of its array 
                else
                    root.element = int.MaxValue;

                // Replace root with next element of array  
                mh.ReplaceMin(root);
            }
            PrintArray(result);
        }
    }



    class Heap<T> where T : IComparable<T>
    {
        private List<T> items;
        private bool isMinHeap = false;
        public Heap()
        {
            items = new List<T>();
        }
        public Heap(string value)
        {
            items = new List<T>();
            if (value.ToLower() == "min")
                this.isMinHeap = true;
        }

        public void Insert(T item)
        {
            items.Add(item);
            ShiftUp();
        }
        /*To Insert New Item in MaxHeap*/
        private void ShiftUp()
        {
            int k = items.Count() - 1;

            while (k > 0)
            {
                int parentIndex = (k - 1) / 2;
                T item = items.ElementAt(k);
                T parent = items.ElementAt(parentIndex);

                bool comparisonExpression = isMinHeap ? (item.CompareTo(parent) < 0) : (item.CompareTo(parent) > 0);
                if (comparisonExpression)
                {
                    //swap items
                    items[k] = parent;
                    items[parentIndex] = item;

                    //Move up one level
                    k = parentIndex;
                }
                else
                    break;

            }
        }


        /*To Delete Top Item in MaxHeap*/
        public T Delete()
        {
            //base cases
            if (!items.Any())
                throw new KeyNotFoundException();

            if (items.Count == 1)
            {
                T temp2 = items[0];
                items.RemoveAt(0);
                return temp2;
            }
            T hold = items[0];

            T temp = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            items[0] = temp;

            ShiftDown();

            return hold;
        }

        private void ShiftDown()
        {
            int k = 0;
            int leftChildIndex = 2 * k + 1;
            bool comparisonExpression;

            while (leftChildIndex < items.Count)
            {
                int max = leftChildIndex;
                int rightChildIndex = leftChildIndex + 1;
                if (rightChildIndex < items.Count()) // if right child exists
                {
                    comparisonExpression = isMinHeap ? (items[rightChildIndex].CompareTo(items[leftChildIndex]) < 0) : (items[rightChildIndex].CompareTo(items[leftChildIndex]) > 0);
                    if (comparisonExpression)
                        max++;
                }

                comparisonExpression = isMinHeap ? (items[k].CompareTo(items[max]) > 0) : (items[k].CompareTo(items[max]) < 0);
                if (comparisonExpression)
                {
                    //switch
                    //max = rightChildIndex;
                    T temp = items[k];
                    items[k] = items[max];
                    items[max] = temp;
                    k = max;
                    leftChildIndex = 2 * k + 1;

                }
                else
                    break;
            }
        }

        public bool Any()
        {
            return (items.Any());
        }

        public int Count()
        {
            if (items == null)
                return 0;

            return (items.Count());
        }

        public T Peek()
        {
            //base cases
            if (!items.Any())
                throw new KeyNotFoundException();

            return items[0];
        }

        public void DisplayItems()
        {
            Console.Write("[ ");

            foreach (object o in items)
                Console.Write(o.ToString() + " ");

            Console.Write("]");

            Console.WriteLine();
            for (int i = 0; i < items.Count; i++)
            {
                if (2 * i + 1 < items.Count || 2 * i + 2 < items.Count)
                {
                    Console.Write(" PARENT : " + items[i]);
                    if (2 * i + 1 < items.Count)
                        Console.Write(" LEFT CHILD : " + items[2 * i + 1]);
                    if (2 * i + 2 < items.Count)
                        Console.Write(" RIGHT CHILD : " + items[2 * i + 2]);
                }


                Console.WriteLine();
            }
        }
    }

    class MinHeapNode : IComparable<MinHeapNode>
    {
        public int element; // The element to be stored
        public int i; // index of the array from which the element is taken
        public int j; // index of the next element to be picked from array


        public MinHeapNode(int element, int i, int j)
        {
            this.element = element;
            this.i = i;
            this.j = j;
        }

        public int CompareTo(MinHeapNode other)
        {
            return other.element - this.element;
        }
    }

    // A class for Min Heap 
    class MinHeap
    {
        MinHeapNode[] harr; // Array of elements in heap 
        int heap_size; // Current number of elements in min heap 

        // Constructor: Builds a heap from  
        // a given array a[] of given size 
        public MinHeap(MinHeapNode[] a, int size)
        {
            heap_size = size;
            harr = a;
            int i = (heap_size - 1) / 2;
            while (i >= 0)
            {
                MinHeapify(i);
                i--;
            }
        }

        // A recursive method to heapify a subtree  
        // with the root at given index This method 
        // assumes that the subtrees are already heapified 
        void MinHeapify(int i)
        {
            int l = Left(i);
            int r = Right(i);
            int smallest = i;
            if (l < heap_size &&
                harr[l].element < harr[i].element)
                smallest = l;
            if (r < heap_size &&
                harr[r].element < harr[smallest].element)
                smallest = r;
            if (smallest != i)
            {
                Swap(harr, i, smallest);
                MinHeapify(smallest);
            }
        }

        // to get index of left child of node at index i 
        int Left(int i) { return (2 * i + 1); }

        // to get index of right child of node at index i 
        int Right(int i) { return (2 * i + 2); }

        // to get the root 
        internal MinHeapNode GetMin()
        {
            if (heap_size <= 0)
            {
                Console.WriteLine("Heap underflow");
                return null;
            }
            return harr[0];
        }

        // to replace root with new node  
        // "root" and heapify() new root 
        internal void ReplaceMin(MinHeapNode root)
        {
            harr[0] = root;
            MinHeapify(0);
        }

        // A utility function to swap two min heap nodes 
        void Swap(MinHeapNode[] arr, int i, int j)
        {
            MinHeapNode temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }

}


//Complexity would be O(NKlogK)
//https://www.geeksforgeeks.org/merge-k-sorted-arrays/

/*
 * additional resources:
 * https://www.hackerearth.com/practice/notes/heaps-and-priority-queues/
 * https://leetcode.com/problems/merge-k-sorted-lists/discuss/?currentPage=1&orderBy=most_votes&query=
 * https://www.programcreek.com/2014/05/merge-k-sorted-arrays-in-java/
 * https://medium.com/outco/how-to-merge-k-sorted-arrays-c35d87aa298e
 * https://algorithmsandme.com/merge-k-sorted-arrays/
 */
