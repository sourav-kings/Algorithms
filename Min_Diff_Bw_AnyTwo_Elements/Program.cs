using System;

namespace Min_Diff_Bw_AnyTwo_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 5, 3, 19, 18, 25 };
            Console.WriteLine("Minimum difference is " +
                               FindMinDiff(arr, arr.Length));
        }

        // Returns minimum difference 
        // between any pair
        static int FindMinDiff(int[] arr,
                               int n)
        {
            // Sort array in 
            // non-decreasing order
            Array.Sort(arr);

            // Initialize difference
            // as infinite
            int diff = int.MaxValue;

            // Find the min diff by 
            // comparing adjacent pairs
            // in sorted array
            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i + 1] - arr[i] < diff)
                    diff = arr[i + 1] - arr[i];
            }

            // Return min diff
            return diff;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/find-minimum-difference-pair/
 * 
 * 
 * Method 1 (Simple: O(n2)
 * A simple solution is to use two loops.
 * 
 * Method 2 (Efficient: O(n Log n)
 */
