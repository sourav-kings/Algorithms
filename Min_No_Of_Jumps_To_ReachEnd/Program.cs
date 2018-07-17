
using System;

namespace Min_No_Of_Jumps_To_ReachEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 6, 3, 2, 3, 6, 8, 9, 5 };
            int n = arr.Length;
            Console.WriteLine("Minimum number of jumps to reach end is "
                          + GFG.MinJumps(arr, 0, n - 1));
        }
    }
    class GFG
    {
        // Returns minimum number of 
        // jumps to reach arr[h] from arr[l]
        internal static int MinJumps(int[] arr, int l, int h)
        {
            // Base case: when source 
            // and destination are same
            if (h == l)
                return 0;

            // When nothing is reachable 
            // from the given source
            if (arr[l] == 0)
                return int.MaxValue;

            // Traverse through all the points 
            // reachable from arr[l]. Recursively
            // get the minimum number of jumps 
            // needed to reach arr[h] from these
            // reachable points.
            int min = int.MaxValue;
            for (int i = l + 1; i <= h && i <= l + arr[l]; i++)
            {
                int jumps = MinJumps(arr, i, h);
                if (jumps != int.MaxValue &&
                jumps + 1 < min)
                    min = jumps + 1;

            }
            return min;

        }



        internal static int MinJumps_DP(int[] arr, int n)
        {
            // jumps[n-1] will hold the 
            // result
            int[] jumps = new int[n];

            // if first element is 0,
            if (n == 0 || arr[0] == 0)

                // end cannot be reached
                return int.MaxValue;


            jumps[0] = 0;

            // Find the minimum number of 
            // jumps to reach arr[i]
            // from arr[0], and assign 
            // this value to jumps[i]
            for (int i = 1; i < n; i++)
            {
                jumps[i] = int.MaxValue;
                for (int j = 0; j < i; j++)
                {
                    if (i <= j + arr[j] && jumps[j] != int.MaxValue)
                    {
                        jumps[i] = Math.Min(jumps[i], jumps[j] + 1);
                        break;
                    }
                }
            }
            return jumps[n - 1];
        }
    }
}

/*
 * https://www.geeksforgeeks.org/minimum-number-of-jumps-to-reach-end-of-a-given-array/
 * 
 * NAIVE METHOD
 * 
 * Method 1 (Naive Recursive Approach)
        Start from the first element and recursively call for all the elements reachable from first element. 
        Min no. of jumps to reach end from first 
            can be calculated using 
        min no. of jumps needed to reach end from the elements reachable from first.

    This problem has both properties (optimal substructure and overlapping subproblems) 
    of Dynamic Programming.
 */
