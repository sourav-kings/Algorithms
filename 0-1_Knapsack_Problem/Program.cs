using System;

namespace _0_1_Knapsack_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] val = new int[] { 60, 100, 120 };
            int[] wt = new int[] { 10, 20, 30 };
            int W = 50;
            int n = val.Length;

            Console.WriteLine(KnapSack(W, wt, val, n));
            Console.WriteLine(KnapSack_DP(W, wt, val, n));
        }

        // Returns the maximum value that can 
        // be put in a knapsack of capacity W
        static int KnapSack(int W, int[] wt,
                            int[] val, int n)
        {

            // Base Case
            if (n == 0 || W == 0)
                return 0;

            // If weight of the nth item is 
            // more than Knapsack capacity W,
            // then this item cannot be 
            // included in the optimal solution
            if (wt[n - 1] > W)
                return KnapSack(W, wt, val, n - 1);

            // Return the maximum of two cases: 
            // (1) nth item included 
            // (2) not included
            else return Math.Max(val[n - 1] +
                KnapSack(W - wt[n - 1], wt, val, n - 1),
                       KnapSack(W, wt, val, n - 1));
        }


        // Returns the maximum value that
        // can be put in a knapsack of 
        // capacity W
        static int KnapSack_DP(int W, int[] wt,
                             int[] val, int n)
        {
            int i, w;
            int[,] K = new int[n + 1, W + 1];

            // Build table K[][] in bottom 
            // up manner
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (wt[i - 1] <= w)
                        K[i, w] = Math.Max(val[i - 1]
                               + K[i - 1, w - wt[i - 1]],
                                        K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[n, W];
        }
    }
}

/*
 * Dynamic Programming | Set 10 ( 0-1 Knapsack Problem)
 * 
 * https://www.geeksforgeeks.org/knapsack-problem/
 */
