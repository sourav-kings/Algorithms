using System;

namespace Minimum_Element_In_SortedRotated_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 5, 6, 1, 2, 3, 4 };
            int n1 = arr1.Length;
            Console.WriteLine("The minimum element is " +
                               Minimum.FindMin(arr1, 0, n1 - 1));

            int[] arr2 = { 1, 2, 3, 4 };
            int n2 = arr2.Length;
            Console.WriteLine("The minimum element is " +
                               Minimum.FindMin(arr2, 0, n2 - 1));

            int[] arr3 = { 1 };
            int n3 = arr3.Length;
            Console.WriteLine("The minimum element is " +
                               Minimum.FindMin(arr3, 0, n3 - 1));

            int[] arr4 = { 1, 2 };
            int n4 = arr4.Length;
            Console.WriteLine("The minimum element is " +
                               Minimum.FindMin(arr4, 0, n4 - 1));

            int[] arr5 = { 2, 1 };
            int n5 = arr5.Length;
            Console.WriteLine("The minimum element is " +
                               Minimum.FindMin(arr5, 0, n5 - 1));

            int[] arr6 = { 5, 6, 7, 1, 2, 3, 4 };
            int n6 = arr6.Length;
            Console.WriteLine("The minimum element is " +
                               Minimum.FindMin(arr6, 0, n1 - 1));

            int[] arr7 = { 1, 2, 3, 4, 5, 6, 7 };
            int n7 = arr7.Length;
            Console.WriteLine("The minimum element is " +
                               Minimum.FindMin(arr7, 0, n7 - 1));

            int[] arr8 = { 2, 3, 4, 5, 6, 7, 8, 1 };
            int n8 = arr8.Length;
            Console.WriteLine("The minimum element is " +
                               Minimum.FindMin(arr8, 0, n8 - 1));

            int[] arr9 = { 3, 4, 5, 1, 2 };
            int n9 = arr9.Length;
            Console.WriteLine("The minimum element is " +
                               Minimum.FindMin(arr9, 0, n9 - 1));
        }
    }

    class Minimum
    {
        internal static int FindMin(int[] arr, int low, int high)
        {
            // This condition is needed to handle 
            // the case when array
            // is not rotated at all
            if (high < low)
                return arr[0];

            // If there is only one element left
            if (high == low)
                return arr[low];

            // Find mid
            // (low + high)/2
            int mid = low + (high - low) / 2;

            // Check if element (mid+1) is minimum element. Consider
            // the cases like {3, 4, 5, 1, 2}
            if (mid < high && arr[mid + 1] < arr[mid])
                return arr[mid + 1];

            // Check if mid itself is minimum element
            if (mid > low && arr[mid] < arr[mid - 1])
                return arr[mid];

            // Decide whether we need to go to
            // left half or right half
            if (arr[high] > arr[mid])
                return Minimum.FindMin(arr, low, mid - 1);


            return Minimum.FindMin(arr, mid + 1, high);
        }
    }
}
/*
 * https://www.geeksforgeeks.org/find-minimum-element-in-a-sorted-and-rotated-array/
 * 
 * A simple solution is to traverse the complete array and find minimum. 
 * This solution requires Θ(n) time.
 * 
 * We can do it in O(Logn) using Binary Search.
 * 
 * Problem with repetition can be solved in O(n) worst case.
 * The special cases that cause problems are like {2, 2, 2, 2, 2, 2, 2, 2, 0, 1, 1, 2} 
 *      and {2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2}.
 */
