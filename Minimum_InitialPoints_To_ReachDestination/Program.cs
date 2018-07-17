using System;

namespace Minimum_InitialPoints_To_ReachDestination
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] points = { {-2,-3,3},
            //          {-5,-10,1},
            //          {10,30,-5}
            //        };
            //int R = 3, C = 3;



            int[,] points = { 
                {-10,1},
                {30,-5} };
            int R = 2, C = 2;


            Console.WriteLine("Minimum Initial Points Required: " + MinInitialPoints(points, R, C));
            //Minimum Initial Points Required: 7
        }

        static int MinInitialPoints(int[,] points, int R, int C)
        {
            // dp[i][j] represents the minimum initial points player
            // should have so that when starts with cell(i, j) successfully
            // reaches the destination cell(m-1, n-1)
            int[,] dp = new int[R, C];
            int m = R, n = C;

            // Base case
            dp[m - 1, n - 1] = points[m - 1, n - 1] > 0 ? 1 :
                           Math.Abs(points[m - 1, n - 1]) + 1;

            // Fill last row and last column as base to fill entire table
            for (int i = m - 2; i >= 0; i--)
                dp[i, n - 1] = Math.Max(dp[i + 1, n - 1] - points[i, n - 1], 1);
            for (int j = n - 2; j >= 0; j--)
                dp[m - 1, j] = Math.Max(dp[m - 1, j + 1] - points[m - 1, j], 1);

            // Fill the table in bottom-up fashion
            for (int i = m - 2; i >= 0; i--)
            {
                for (int j = n - 2; j >= 0; j--)
                {
                    int min_points_on_exit = Math.Min(dp[i + 1, j], dp[i, j + 1]);
                    dp[i, j] = Math.Max(min_points_on_exit - points[i, j], 1);
                }
            }

            return dp[0, 0];
        }
    }
}



/*
 * May 2018
 * 
 * https://www.geeksforgeeks.org/minimum-positive-points-to-reach-destination/
 * 
 * 4.5 /150
 * 
 * https://leetcode.com/problems/dungeon-game/description/
 * 
 * See this problem as this:-
 * 
 * MINIMUM amount of extra money one needs to keep in hand to reach from a source cell to a target cell with a postive balance ?
 * **Note** cant move out of one cell until balance is made postive.
 *              ex. --> {{-10, 1}, {30, 5}}
 */
