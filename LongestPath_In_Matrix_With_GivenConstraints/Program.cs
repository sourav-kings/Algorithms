using System;

namespace LongestPath_In_Matrix_With_GivenConstraints
{
    class Program
    {
        public static int n = 3;
        public static int[,] dp;
        public static int[,] mat;

        static void Main(string[] args)
        {
            mat = new int[,] { {1, 2, 9},
                         {5, 3, 8},
                         {4, 6, 7} };
            Console.WriteLine("Length of the longest path is " +
                                FinLongestOverAll());
        }


        // Function that returns length of the longest path
        // beginning with any cell
        static int FinLongestOverAll()
        {
            // Initialize result
            int result = 1;

            // Create a lookup table and fill all entries in it as -1
            dp = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    dp[i, j] = -1;

            // Compute longest path beginning from all cells
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dp[i, j] == -1)
                        FindLongestFromACell(i, j);

                    //  Update result if needed
                    result = Math.Max(result, dp[i, j]);
                }
            }

            return result;
        }

        // Function that returns length of the longest path 
        // beginning with mat[i,j]
        // This function mainly uses lookup table dp[n,n]
        static int FindLongestFromACell(int i, int j)
        {
            // Base case
            if (i < 0 || i >= n || j < 0 || j >= n)
                return 0;

            // If this subproblem is already solved
            if (dp[i, j] != -1)
                return dp[i, j];

            // Since all numbers are unique and in range from 1 to n*n,
            // there is atmost one possible direction from any cell
            if (j < n - 1 && ((mat[i, j] + 1) == mat[i, j + 1]))
                return dp[i, j] = 1 + FindLongestFromACell(i, j + 1);

            if (j > 0 && (mat[i, j] + 1 == mat[i, j - 1]))
                return dp[i, j] = 1 + FindLongestFromACell(i, j - 1);

            if (i > 0 && (mat[i, j] + 1 == mat[i - 1, j]))
                return dp[i, j] = 1 + FindLongestFromACell(i - 1, j);

            if (i < n - 1 && (mat[i, j] + 1 == mat[i + 1, j]))
                return dp[i, j] = 1 + FindLongestFromACell(i + 1, j);

            // If none of the adjacent fours is one greater
            return dp[i, j] = 1;
        }


    }
}

/*
 * https://www.geeksforgeeks.org/find-the-longest-path-in-a-matrix-with-given-constraints/
 */
