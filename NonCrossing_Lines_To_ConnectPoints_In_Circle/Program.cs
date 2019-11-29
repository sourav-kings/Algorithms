using System;

namespace NonCrossing_Lines_To_ConnectPoints_In_Circle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountWays(6) + " ");
        }

        static int CountWays(int n)
        {
            // Throw error if n is odd
            if (n < 1)
            {
                Console.WriteLine("Invalid");
                return 0;
            }

            // Else return n/2'th 
            // Catalan number
            return CatalanDP(n / 2);
        }

        static int CatalanDP(int n)
        {
            // Table to store 
            // results of subproblems
            int[] catalan = new int[n + 1];

            // Initialize first
            // two values in table
            catalan[0] = catalan[1] = 1;

            // Fill entries in catalan[] 
            // using recursive formula
            for (int i = 2; i <= n; i++)
            {
                catalan[i] = 0;
                for (int j = 0; j < i; j++)
                    catalan[i] += catalan[j] *
                                  catalan[i - j - 1];
            }

            // Return last entry
            return catalan[n];
        }
    }
}
/*
 * https://www.geeksforgeeks.org/non-crossing-lines-connect-points-circle/
 */
