using System;

namespace Partition_Problem
{
    class Program
    {
        static int[] arr;
        static void Main(string[] args)
        {
            //            int[] arr = { 3, 1, 5, 9, 12 };
            arr = new int[]{ 3, 1, 2 };
            int n = arr.Length;
            if (FindPartition_DP(arr, n) == true)
                Console.WriteLine("Can be divided into two " +
                              "subsets of equal sum");
            else
                Console.WriteLine("Can not be divided into " +
                              "two subsets of equal sum");
        }


        // Returns true if arr[] can be partitioned in two
        // subsets of equal sum, otherwise false
        static bool FindPartition(int[] arr, int n)
        {
            // Calculate sum of the elements in array
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += arr[i];

            // If sum is odd, there cannot be two subsets
            // with equal sum
            if (sum % 2 != 0)
                return false;

            // Find if there is subset with sum equal to half
            // of total sum
            return IsSubsetSum(n, sum / 2);
        }


        // A utility function that returns true if there is a
        // subset of arr[] with sun equal to given sum
        static bool IsSubsetSum(int n, int sum)
        {
            // Base Cases
            if (sum == 0)
                return true;
            if (n == 0 && sum != 0)
                return false;

            // If last element is greater than sum, then ignore it
            if (arr[n - 1] > sum)
                return IsSubsetSum(n - 1, sum);

            /* else, check if sum can be obtained by any of
            the following
            (a) including the last element
            (b) excluding the last element
            */
            return IsSubsetSum(n - 1, sum) ||
                   IsSubsetSum(n - 1, sum - arr[n - 1]);
        }


        // Returns true if arr[] can be partitioned 
        // in two subsets of equal sum, otherwise 
        // false
        static bool FindPartition_DP(int[] arr, int n)
        {

            int sum = 0;
            int i, j;

            // Caculcate sun of all elements
            for (i = 0; i < n; i++)
                sum += arr[i];

            if (sum % 2 != 0)
                return false;

            bool[,] part = new bool[sum / 2 + 1, n + 1];

            // initialize top row as true
            for (i = 0; i <= n; i++)
                part[0, i] = true;

            // initialize leftmost column, except 
            // part[0][0], as 0
            for (i = 1; i <= sum / 2; i++)
                part[i, 0] = false;

            // Fill the partition table in botton 
            // up manner
            for (i = 1; i <= sum / 2; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    part[i, j] = part[i, j - 1];
                    if (i >= arr[j - 1])
                        part[i, j] = part[i, j] ||
                        part[i - arr[j - 1], j - 1];
                }
            }

            /* // uncomment this part to print table
            for (i = 0; i <= sum/2; i++)
            {
                for (j = 0; j <= n; j++)
                    printf ("%4d", part[i][j]);
                printf("\n");
            } */

            return part[sum / 2, n];
        }
    }
}

/*
 * https://www.geeksforgeeks.org/dynamic-programming-set-18-partition-problem/
 * 
 * 3.5 / 200
 */
