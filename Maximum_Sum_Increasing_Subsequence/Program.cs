using System;

namespace Maximum_Sum_Increasing_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 101, 2, 3, 100, 4, 5 };
            int n = arr.Length;
            Console.WriteLine("Sum of maximum sum increasing " +
                                            " subsequence is " +
            MaxSumIS(arr, n));
        }

        // maxSumIS() returns the 
        // maximum sum of increasing
        // subsequence in arr[] of size n 
        static int MaxSumIS(int[] arr, int n)
        {
            int i, j, max = 0;
            int[] msis = new int[n];

            /* Initialize msis values
               for all indexes */
            for (i = 0; i < n; i++)
                msis[i] = arr[i];

            /* Compute maximum sum values
               in bottom up manner */
            for (i = 1; i < n; i++)
                for (j = 0; j < i; j++)
                    if (arr[i] > arr[j] &&
                        msis[i] < msis[j] + arr[i])
                        msis[i] = msis[j] + arr[i];

            /* Pick maximum of all 
               msis values */
            for (i = 0; i < n; i++)
                if (max < msis[i])
                    max = msis[i];

            return max;
        }
    }
}

/*
 * https://www.geeksforgeeks.org/dynamic-programming-set-14-maximum-sum-increasing-subsequence/
 * 
 * Dynamic Programming | Set 14 (Maximum Sum Increasing Subsequence)
 * This problem is a variation of standard Longest Increasing Subsequence (LIS) problem. 
 * All we need to change is to use sum as a criteria instead of length of increasing subsequence.
 */
