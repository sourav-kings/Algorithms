using System;

namespace Kth_Largest_Element_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ropes = { 4, 3, 2, 6, 13, 9 };

            PrintArray(ropes);
            MaxHeap(ropes);
            Console.Write(GetKthLargestelement(ropes, 5));
            PrintArray(ropes);
        }


        private static void MaxHeap(int[] arr)
        {

            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }
        }


        private static int GetKthLargestelement(int[] arr, int k)
        {

            for (int j = 0, i = arr.Length - 1; i >= 0 && j < k; i--, j++)
            {
                Swap(arr, i, 0);
                Heapify(arr, i, 0);
            }
            return arr[arr.Length - k];
        }


        private static void Heapify(int[] arr, int n, int i)
        {

            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;

            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }
            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }
            if (largest != i)
            {
                Swap(arr, largest, i);
                Heapify(arr, n, largest);
            }
        }

        private static void Swap(int[] arr, int largest, int i)
        {

            int temp = arr[i];
            arr[i] = arr[largest];
            arr[largest] = temp;
        }

        private static void PrintArray(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}

//http://ideone.com/CjpDwZ

//http://www.geeksforgeeks.org/k-largestor-smallest-elements-in-an-array/

    /*
     MIN-HEAP method used. tough but have to understand this pattenrn, which is also used to 
     find the Kth "Smallest" element in 2D-array which is row and column wise sorted. 
     */