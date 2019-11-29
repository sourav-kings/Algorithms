using System;

namespace Search__Insert_Delete_In_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 6, 7, 8, 9, 10 };
            int n, key, capacity;
            n = arr.Length;
            key = 10;
            capacity = arr.Length;

            Console.WriteLine("Index: " +
                binarySearch(arr, 0, n, key));



            Console.Write("\nBefore Insertion: ");
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");

            // Inserting key
            n = insertSorted(arr, n, key, capacity);

            Console.Write("\nAfter Insertion: ");
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
        }

        // function to implement
        // binary search
        static int binarySearch(int[] arr, int low, int high, int key)
        {
            if (high < low)
                return -1;

            /*low + (high - low)/2;*/
            int mid = (low + high) / 2;
            if (key == arr[mid])
                return mid;
            if (key > arr[mid])
                return binarySearch(arr, (mid + 1), high, key);
            return binarySearch(arr, low, (mid - 1), key);
        }




        // Inserts a key in arr[] of given 
        // capacity.  n is current size of arr[]. 
        // This function returns n+1 if insertion
        // is successful, else n.
        static int insertSorted(int[] arr, int n, int key, int capacity)
        {
            // Cannot insert more elements if n is already
            // more than or equal to capcity
            if (n >= capacity)
                return n;

            int i;
            for (i = n - 1; (i >= 0 && arr[i] > key); i--)
                arr[i + 1] = arr[i];

            arr[i + 1] = key;

            return (n + 1);
        }



        /* Function to delete an element */
        static int deleteElement(int[] arr, int n, int key)
        {
            // Find position of element to be deleted
            int pos = binarySearch(arr, 0, n - 1, key);

            if (pos == -1)
            {
                Console.WriteLine("Element not found");
                return n;
            }

            // Deleting element
            int i;
            for (i = pos; i < n - 1; i++)
                arr[i] = arr[i + 1];

            return n - 1;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/search-insert-and-delete-in-a-sorted-array/
 */
