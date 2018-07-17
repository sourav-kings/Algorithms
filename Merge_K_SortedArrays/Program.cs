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
            int [,] arr =  {{2, 6, 12, 34},
                     {1, 9, 20, 1000},
                     {23, 34, 90, 2000}};

            int n = 3;
            int k = arr.Length;

            int output = MergeKArrays(arr, n, k);

            Console.WriteLine("Merged array is ");
            PrintArray(arr, n)    ;

            //Heap<int> highers = new Heap<int>("min");
        }

        // A utility function to print array elements
        static void PrintArray(int[] arr, int size)
        {
            for (int i = 0; i < size; i++)
                Console.WriteLine(arr[i] + " ");
        }

        // This function takes an array of arrays as an argument and
        // All arrays are assumed to be sorted. It merges them together
        // and prints the final sorted output.
        static int MergeKArrays(int[,] arr, int n, int k)
        {
            int len = n * k;
            int[] output = new int[len];  // To store output array

            // Create a min heap with k heap nodes.  Every heap node
            // has first element of an array
            MinHeapNode[] harr = new MinHeapNode[k];
            //MinHeapNode* harr = new MinHeapNode[k];

            Heap<MinHeapNode> hp = new Heap<MinHeapNode>("min");
            for (int i = 0; i < k; i++)
            {
                harr[i].element = arr[i,0]; // Store the first element
                harr[i].i = i;  // index of array
                harr[i].j = 1;  // Index of next element to be stored from array

                hp.Insert(harr[i]);
            }



            //MinHeap hp(harr, k); // Create the heap


            // Now one by one get the minimum element from min
            // heap and replace it with next element of its array
            for (int count = 0; count < n * k; count++)
            {
                // Get the minimum element and store it in output
                MinHeapNode root = hp.
                output[count] = root.element;

                // Find the next elelement that will replace current
                // root of heap. The next element belongs to same
                // array as the current root.
                if (root.j < n)
                {
                    root.element = arr[root.i][root.j];
                    root.j += 1;
                }
                // If root was the last element of its array
                else root.element = INT_MAX; //INT_MAX is for infinite

                // Replace root with next element of array
                hp.replaceMin(root);
            }

            return output;
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


        MinHeapNode(int element, int i, int j)
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
}


//Complexity would be O(NKlogK)
