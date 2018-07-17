using System;

namespace Peak_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 1, 3, 20, 4, 1, 0 };
            int[] arr = { 10, 20, 15, 2, 23, 90, 67 };
            int n = arr.Length;
            Console.WriteLine("Index of a peak point is " +
                                FindPeak(arr, n));
        }

        // A binary search based function that returns index of a peak
        // element
        static int FindPeakUtil(int[] arr, int low, int high, int n)
        {
            // Find index of middle element
            int mid = low + (high - low) / 2;  /* (low + high)/2 */

            // Compare middle element with its neighbours (if neighbours
            // exist)
            if ((mid == 0 || arr[mid - 1] <= arr[mid]) && (mid == n - 1 ||
                 arr[mid + 1] <= arr[mid]))
                return mid;

            // If middle element is not peak and its left neighbor is
            // greater than it,then left half must have a peak element
            else if (mid > 0 && arr[mid - 1] > arr[mid])
                return FindPeakUtil(arr, low, (mid - 1), n);

            // If middle element is not peak and its right neighbor
            // is greater than it, then right half must have a peak
            // element
            else return FindPeakUtil(arr, (mid + 1), high, n);
        }

        // A wrapper over recursive function findPeakUtil()
        static int FindPeak(int[] arr, int n)
        {
            return FindPeakUtil(arr, 0, n - 1, n);
        }
    }
}
/*
 * https://www.geeksforgeeks.org/find-a-peak-in-a-given-array/
 * 
 * In an array, find a peak element which is NOT smaller than its neighbors.
 * use Divide and Conquer to find a peak in O(Logn) time
 * 
 * Use Binary Search, and compare middle element (M) with its neighbors.
 * 
 *      1. If M is NOT smaller than neighbors, then we return it.
 *      2. Else, there's Always a peak element Either on right OR on left
 *          (if right or left neghbour is smaller resp.)
 */
