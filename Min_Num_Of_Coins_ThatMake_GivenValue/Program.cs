using System;

namespace Min_Num_Of_Coins_ThatMake_GivenValue
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = { 9, 6, 5, 1 };
            int m = coins.Length;
            int V = 11;
            Console.Write("Minimum coins required is " +
                                 MinCoins(coins, m, V));
        }

        static int MinCoins(int[] coins, int m, int V)
        {

            // base case
            if (V == 0) return 0;

            // Initialize result
            int res = int.MaxValue;

            // Try every coin that has
            // smaller value than V
            for (int i = 0; i < m; i++)
            {
                if (coins[i] <= V)
                {
                    int sub_res = MinCoins(coins, m,
                                      V - coins[i]);

                    // Check for INT_MAX to 
                    // avoid overflow and see 
                    // if result can minimized
                    if (sub_res != int.MaxValue &&
                                sub_res + 1 < res)
                        res = sub_res + 1;
                }
            }
            return res;
        }


        static int MinCoins_DP(int[] coins, int m, int V)
        {
            // table[i] will be storing 
            // the minimum number of coins
            // required for i value. So 
            // table[V] will have result
            int[] table = new int[V + 1];

            // Base case (If given
            // value V is 0)
            table[0] = 0;

            // Initialize all table
            // values as Infinite
            for (int i = 1; i <= V; i++)
                table[i] = int.MaxValue;

            // Compute minimum coins 
            // required for all
            // values from 1 to V
            for (int i = 1; i <= V; i++)
            {
                // Go through all coins
                // smaller than i
                for (int j = 0; j < m; j++)
                    if (coins[j] <= i)
                    {
                        int sub_res = table[i - coins[j]];
                        if (sub_res != int.MaxValue &&
                            sub_res + 1 < table[i])
                            table[i] = sub_res + 1;
                    }
            }
            return table[V];

        }
    }
}
/*
 * https://www.geeksforgeeks.org/find-minimum-number-of-coins-that-make-a-change/
 * 
 * 
    Input: coins[] = {25, 10, 5}, V = 30
    Output: Minimum 2 coins required
    We can use one coin of 25 cents and one of 5 cents 

    Input: coins[] = {9, 6, 5, 1}, V = 11
    Output: Minimum 2 coins required
    We can use one coin of 6 cents and 1 coin of 5 cents

    This problem is a variation of the problem discussed Coin Change Problem. 
    Here instead of finding total number of possible solutions, 
    we need to find the solution with minimum number of coins.


    If V == 0, then 0 coins required.
    If V > 0
        minCoin(coins[0..m-1], V) = min {1 + minCoins(V-coin[i])} 
                               where i varies from 0 to m-1 
                               and coin[i] <= V 
 */
