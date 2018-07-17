using System;

namespace Partition_Set_Into_Two_SuchThat_Difference_SubsetSums_Min
{
    class Program
    {
        static int[] arr;
        static void Main(string[] args)
        {
            arr = new int[] { 3, 1, 4, 2, 2, 1 };
            int n = arr.Length;
            Console.WriteLine("The minimum difference" +
                            " between two sets is " +
                             FindMin(arr, n));
        }

        // Returns minimum possible difference between
        // sums of two subsets
        public static int FindMin(int[] arr, int n)
        {
            // Compute total sum of elements
            int sumTotal = 0;
            for (int i = 0; i < n; i++)
                sumTotal += arr[i];

            // Compute result using recursive function
            return FindMinRec(arr, n, 0, sumTotal);
        }


        // Function to find the minimum sum
        public static int FindMinRec(int[] arr, int i,
                                    int sumCalculated,
                                     int sumTotal)
        {
            // If we have reached last element.
            // Sum of one subset is sumCalculated,
            // sum of other subset is sumTotal-
            // sumCalculated.  Return absolute 
            // difference of two sums.
            if (i == 0)
                return Math.Abs((sumTotal - sumCalculated) -
                                       sumCalculated);


            // For every item arr[i], we have two choices
            // (1) We do not include it first set
            // (2) We include it in first set
            // We return minimum of two choices
            return Math.Min(FindMinRec(arr, i - 1, sumCalculated
                                       + arr[i - 1], sumTotal),
                                     FindMinRec(arr, i - 1,
                                      sumCalculated, sumTotal));
        }


        // Returns the minimum value of 
        //the difference of the two sets.
        private static int FindMin_DP(int[] arr, int n)
        {
            // Calculate sum of all elements
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += arr[i];

            // Create an array to store 
            // results of subproblems
            bool[,] dp = new bool[n + 1, sum + 1];

            // Initialize first column as true. 
            // 0 sum is possible  with all elements.
            for (int i = 0; i <= n; i++)
                dp[i, 0] = true;

            // Initialize top row, except dp[0,0], 
            // as false. With 0 elements, no other 
            // sum except 0 is possible
            for (int i = 1; i <= sum; i++)
                dp[0, i] = false;

            // Fill the partition table 
            // in bottom up manner
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    // If i'th element is excluded
                    dp[i, j] = dp[i - 1, j];

                    // If i'th element is included
                    if (arr[i - 1] <= j)
                        dp[i, j] |= dp[i - 1, j - arr[i - 1]];
                }
            }

            // Initialize difference of two sums. 
            int diff = int.MaxValue;

            // Find the largest j such that dp[n,j]
            // is true where j loops from sum/2 t0 0
            for (int j = sum / 2; j >= 0; j--)
            {
                // Find the 
                if (dp[n, j] == true)
                {
                    diff = sum - 2 * j;
                    break;
                }
            }
            return diff;
        }
    }
}
