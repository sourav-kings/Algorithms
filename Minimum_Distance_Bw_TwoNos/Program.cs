using System;

namespace Minimum_Distance_Bw_TwoNos
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {3, 5, 4, 2, 6, 3,
                     0, 0, 5, 4, 8, 3};
            int n = arr.Length;
            int x = 3;
            int y = 6;
            Console.WriteLine("Minimum distance between " + x + " and " + y
                                           + " is " + MinimumDistance.MinDist(arr, n, x, y));
        }
    }

    class MinimumDistance
    {

        internal static int MinDist(int[] arr, int n,
                           int x, int y)
        {
            int i = 0;
            int min_dist = int.MaxValue;
            int prev = 0;

            // Find the first occurence of any
            // of the two numbers (x or y)
            // and store the index of this
            // occurence in prev
            for (i = 0; i < n; i++)
            {
                if (arr[i] == x || arr[i] == y)
                {
                    prev = i;
                    break;
                }
            }

            // Traverse after the 
            // first occurence
            for (; i < n; i++)
            {
                if (arr[i] == x || arr[i] == y)
                {
                    // If the current element matches 
                    // with any of the two then
                    // check if current element and 
                    // prev element are different
                    // Also check if this value is 
                    // smaller than minimum distance 
                    // so far
                    if (arr[prev] != arr[i] &&
                        (i - prev) < min_dist)
                    {
                        min_dist = i - prev;
                        prev = i;
                    }
                    else
                        prev = i;
                }
            }

            return min_dist;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/find-the-minimum-distance-between-two-numbers/
 * 
 * Average Difficulty : 2.4/5.0
 * Based on 143 vote(s)
 * 
 * Method 2 (Tricky)
 *      1) Traverse array from left side and stop if either x or y is found. 
 *      Store index of this first occurrence in a variable say prev
 *      2) Now traverse arr[] after the index prev. 
 *      If the element at current index i matches with either x or y 
 *      then check if it is different from arr[prev].
 *      If it is different then update the minimum distance if needed. 
 *      If it is same then update prev i.e., make prev = i.
 */
