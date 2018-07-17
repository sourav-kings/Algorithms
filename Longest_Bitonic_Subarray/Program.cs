using System;

namespace Longest_Bitonic_Subarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 12, 4, 78, 90, 45, 23 };
            int n = arr.Length;
            Console.Write("Length of max length Bitnoic Subarray is "
                          + Bitonic(arr, n));
        }

        static int Bitonic(int[] arr, int n)
        {
            // Length of increasing subarray ending 
            // at all indexes
            int[] inc = new int[n];

            // Length of decreasing subarray starting
            // at all indexes
            int[] dec = new int[n];

            int max;

            // Length of increasing sequence 
            // ending at first index is 1
            inc[0] = 1;

            // Length of increasing sequence 
            // starting at first index is 1
            dec[n - 1] = 1;

            // Step 1) Construct increasing sequence array
            for (int i = 1; i < n; i++)
                inc[i] = (arr[i] >= arr[i - 1]) ?
                         inc[i - 1] + 1 : 1;

            // Step 2) Construct decreasing sequence array
            for (int i = n - 2; i >= 0; i--)
                dec[i] = (arr[i] >= arr[i + 1]) ?
                         dec[i + 1] + 1 : 1;

            // Step 3) Find the length of maximum 
            // length bitonic sequence
            max = inc[0] + dec[0] - 1;
            for (int i = 1; i < n; i++)
                if (inc[i] + dec[i] - 1 > max)
                    max = inc[i] + dec[i] - 1;

            return max;
        }
    }
}
/*
 * Maximum Length Bitonic Subarray | Set 1 (O(n) tine and O(n) space)
 * 
 * https://www.geeksforgeeks.org/maximum-length-bitonic-subarray/
 * 
 * Time Complexity : O(n)
 * Auxiliary Space : O(n)
 */
