using System;

namespace FixedPoint_Or_ValueEqualToIndex_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { -10, -1, 0, 3, 10, 11, 30, 50, 100 };
            int n = arr.Length;
            Console.WriteLine("Fixed Point is " + linearSearch(arr, n));
            Console.WriteLine("Fixed Point is " + binarySearch(arr, 0, n - 1));
        }

        static int linearSearch(int[] arr, int n)
        {
            int i;
            for (i = 0; i < n; i++)
            {
                if (arr[i] == i)
                    return i;
            }

            /* If no fixed point present 
            then return -1 */
            return -1;
        }


        static int binarySearch(int[] arr, int low, int high)
        {
            if (high >= low)
            {
                // low + (high - low)/2; 
                int mid = (low + high) / 2;

                if (mid == arr[mid])
                    return mid;
                if (mid > arr[mid])
                    return binarySearch(arr, (mid + 1), high);
                else
                    return binarySearch(arr, low, (mid - 1));
            }

            /* Return -1 if there is 
            no Fixed Point */
            return -1;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/find-a-fixed-point-in-a-given-array/
 * 
 * Method 1 (Linear Search) 
 * Time Complexity: O(n)
 * 
 * 
 * Method 2 (Binary Search)
 * Time Complexity: O(Logn)
 * 
 */
