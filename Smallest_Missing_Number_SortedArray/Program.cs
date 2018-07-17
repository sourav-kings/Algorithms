using System;

namespace Smallest_Missing_Number_SortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 10 };
            int n = arr.Length;

            Console.Write("smallest Missing element is : "
                        + GFG.FindFirstMissing(arr, 0, n - 1));
        }
    }

    class GFG
    {
        internal static int FindFirstMissing(int[] array,
                                int start, int end)
        {
            if (start > end)
                return end + 1;

            if (start != array[start])
                return start;

            int mid = (start + end) / 2;

            // Left half has all elements from 0 to mid
            if (array[mid] == mid)
                return FindFirstMissing(array, mid + 1, end);

            return FindFirstMissing(array, start, mid);
        }
    }
}
/*
 * https://www.geeksforgeeks.org/find-the-first-missing-number/
 */
