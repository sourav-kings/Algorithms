using System;

namespace Maximum_SumPath_In_Two_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ar1 = { 2, 3, 7, 10, 12, 15, 30, 34 };
            int[] ar2 = { 1, 5, 7, 8, 10, 15, 16, 19 };
            int m = ar1.Length;
            int n = ar2.Length;
            Console.Write("Maximum sum path is :" +
                         MaxPathSum(ar1, ar2, m, n));
        }

        // This function returns the sum of
        // elements on maximum path from
        // beginning to end
        static int MaxPathSum(int[] ar1, int[] ar2,
                                      int m, int n)
        {
            // initialize indexes for ar1[]
            // and ar2[]
            int i = 0, j = 0;

            // Initialize result and current 
            // sum through ar1[] and ar2[].
            int result = 0, sum1 = 0, sum2 = 0;

            // Below 3 loops are similar to
            // merge in merge sort
            while (i < m && j < n)
            {
                // Add elements of ar1[] to sum1
                if (ar1[i] < ar2[j])
                    sum1 += ar1[i++];

                // Add elements of ar2[] to sum2
                else if (ar1[i] > ar2[j])
                    sum2 += ar2[j++];

                // we reached a common point
                else
                {

                    // Take the maximum of two 
                    // sums and add to result
                    result += Math.Max(sum1, sum2);

                    // Update sum1 and sum2 for
                    // elements after this
                    // intersection point
                    sum1 = 0;
                    sum2 = 0;

                    // Keep updating result while 
                    // there are more common
                    // elements
                    while (i < m && j < n &&
                                ar1[i] == ar2[j])
                    {
                        result = result + ar1[i++];
                        j++;
                    }
                }
            }

            // Add remaining elements of ar1[]
            while (i < m)
                sum1 += ar1[i++];

            // Add remaining elements of ar2[]
            while (j < n)
                sum2 += ar2[j++];

            // Add maximum of two sums of
            // remaining elements
            result += Math.Max(sum1, sum2);

            return result;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/maximum-sum-path-across-two-arrays/
 * 
 * Expected time complexity is O(m+n) 
 * 
 * In every iteration of while loops, we process an element from either of the two arrays. 
 * There are total m + n elements. Therefore, time complexity is O(m+n).
 */
