using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kth_SmallestElement_In_RowColumnWise_Sorted2DArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mat = new int[4,4]{ {10, 20, 30, 40},
                    {15, 25, 35, 45},
                    {25, 29, 37, 48},
                    {32, 33, 39, 50},
                  };
            Console.WriteLine("7th smallest element is " + kthSmallest(mat, 4, 7));
        }

        public int kthSmallest(int[,] matrix, int k)
        {
            int n = matrix.length;
            PriorityQueue<Tuple> pq = new PriorityQueue<Tuple>();
            for (int j = 0; j <= n - 1; j++) pq.offer(new Tuple(0, j, matrix[0][j]));
            for (int i = 0; i < k - 1; i++)
            {
                Tuple t = pq.poll();
                if (t.x == n - 1) continue;
                pq.offer(new Tuple(t.x + 1, t.y, matrix[t.x + 1][t.y]));
            }
            return pq.poll().val;
        }

        // A utility function to swap two HeapNode items.
        static void swap(HeapNode x, HeapNode y)
        {
            HeapNode z = x;
            x = y;
            y = z;
        }

        // A utility function to minheapify the node harr[i] of a heap
        // stored in harr[]
        static void minHeapify(HeapNode[] harr, int i, int heap_size)
        {
            int l = i * 2 + 1;
            int r = i * 2 + 2;
            int smallest = i;
            if (l < heap_size && harr[l].val < harr[i].val)
                smallest = l;
            if (r < heap_size && harr[r].val < harr[smallest].val)
                smallest = r;
            if (smallest != i)
            {
                swap(harr[i], harr[smallest]);
                minHeapify(harr, smallest, heap_size);
            }
        }

        // A utility function to convert harr[] to a max heap
        static void buildHeap(HeapNode[] harr, int n)
        {
            int i = (n - 1) / 2;
            while (i >= 0)
            {
                minHeapify(harr, i, n);
                i--;
            }
        }

        // This function returns kth smallest element in a 2D array mat[][]
        static int kthSmallest(int[,] mat, int n, int k)
        {
            // k must be greater than 0 and smaller than n*n
            if (k <= 0 || k > n * n)
                return int.MaxValue;

            // Create a min heap of elements from first row of 2D array
            HeapNode[,] harr;
            for (int i = 0; i < n; i++)
                harr[i] =  { mat[0,i], 0, i};
            buildHeap(harr, n);

            HeapNode hr;
            for (int i = 0; i < k; i++)
            {
                // Get current heap root
                hr = harr[0];

                // Get next value from column of root's value. If the
                // value stored at root was last value in its column,
                // then assign INFINITE as next value
                int nextval = (hr.r < (n - 1)) ? mat[hr.r + 1,hr.c] : int.MaxValue;

                // Update heap root with next value
                harr[0] =  { nextval, (hr.r) + 1, hr.c};

                // Heapify root
                minHeapify(harr, 0, n);
            }

            // Return the value at last extracted root
            return hr.val;
        }
    }

    // A structure to store an entry of heap.  The entry contains
    // a value from 2D array, row and column numbers of the value
    class HeapNode
    {
        public int val;  // value to be stored
        public int r;    // Row number of value in 2D array
        public int c;    // Column number of value in 2D array
    };
}


//http://www.geeksforgeeks.org/kth-smallest-element-in-a-row-wise-and-column-wise-sorted-2d-array-set-1/