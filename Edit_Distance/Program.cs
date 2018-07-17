using System;

namespace Edit_Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            String str1 = "sunday";
            String str2 = "saturday";
            Console.WriteLine(EditDist_Recursive(str1, str2, str1.Length,
                                                     str2.Length));
            Console.WriteLine(EditDistDP_DP(str1, str2, str1.Length,
                                                     str2.Length)); 
        }

        static int EditDist_Recursive(String str1, String str2, int m, int n)
        {
            // If first string is empty, the only option is to
            // insert all characters of second string into first
            if (m == 0) return n;

            // If second string is empty, the only option is to
            // remove all characters of first string
            if (n == 0) return m;

            // If last characters of two strings are same, nothing
            // much to do. Ignore last characters and get count for
            // remaining strings.
            if (str1[m - 1] == str2[n - 1])
                return EditDist_Recursive(str1, str2, m - 1, n - 1);

            // If last characters are not same, consider all three
            // operations on last character of first string, recursively
            // compute minimum cost for all three operations and take
            // minimum of three values.
            return 1 + Min(EditDist_Recursive(str1, str2, m, n - 1), // Insert
                            EditDist_Recursive(str1, str2, m - 1, n), // Remove
                            EditDist_Recursive(str1, str2, m - 1, n - 1) // Replace                     
                        );
        }


        static int EditDistDP_DP(String str1, String str2, int m, int n)
        {
            // Create a table to store
            // results of subproblems
            int[,] dp = new int[m + 1, n + 1];

            // Fill d[][] in bottom up manner
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    // If first string is empty, only option is to
                    // isnert all characters of second string
                    if (i == 0)

                        // Min. operations = j
                        dp[i, j] = j;

                    // If second string is empty, only option is to
                    // remove all characters of second string
                    else if (j == 0)

                        // Min. operations = i
                        dp[i, j] = i;

                    // If last characters are same, ignore last char
                    // and recur for remaining string
                    else if (str1[i - 1] == str2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];

                    // If the last character is different, consider all
                    // possibilities and find the minimum
                    else
                        dp[i, j] = 1 + Min(dp[i, j - 1], // Insert
                                        dp[i - 1, j], // Remove
                                        dp[i - 1, j - 1]); // Replace
                }
            }

            return dp[m, n];
        }

        static int Min(int x, int y, int z)
        {
            if (x <= y && x <= z) return x;
            if (y <= x && y <= z) return y;
            else return z;
        }
    }
}

/*
 * https://www.geeksforgeeks.org/dynamic-programming-set-5-edit-distance/
 */
