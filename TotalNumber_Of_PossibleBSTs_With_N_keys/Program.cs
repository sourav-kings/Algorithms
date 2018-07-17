using System;

namespace TotalNumber_Of_PossibleBSTs_With_N_keys
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4; //2--> 2; 3 --> 5; 4 --> 14; 5  --> 42
            Console.WriteLine(countBsts(n));
            Console.WriteLine(countBsts_Test_Working(n)); 
        }

        static int countBsts(int n)
        {

            int[] count = new int[n+1];
            count[0] = 1;
            for (int i = 1; i <= n; i++)
                count[i] = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    count[i] += (count[i - j] * count[j - 1]);
                }
            }
            return count[n];
        }

        static int countBsts_Test_Working(int n)
        {
            int[] T = new int[n+1];
            T[0] = T[1] = 1;

            for(int i=2; i<=n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    T[i] = T[i] + (T[j - 1] * T[i - j]);
                }
            }

            return T[n];
        }
    }
}
// http://www.geeksforgeeks.org/total-number-of-possible-binary-search-trees-with-n-keys/


//http://code.geeksforgeeks.org/0hMPHL


//http://www.geeksforgeeks.org/g-fact-18/

//Average Difficulty : 3.3/5.0
//Based on 55 vote(s)

/*
 * Let’s say node i is chosen to be the root. 
 * Then there are i – 1 nodes smaller than i and n – i nodes bigger than i. 
 * For each of these two sets of nodes, there is a certain number of possible subtrees.
 * 
 * Let t(n) be the total number of BSTs with n nodes.
 * The total number of BSTs with i at the root is t(i – 1) * t(n – i). 
 * Two terms multiplied together as arrangements in left & right subtrees are independent.
 * 
 * Summing over 'i' gives the total number of BSTs with n nodes.
 * 
 * For 'i' = 1 to N
 * t(N) = t(i - 1) * t(N - i) 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * ******************************************************************************
 * IGNORE - NO USE
 * (below is only good if rote learning is done. So ignore this algo.)
 * ALGO::
 * 
 * 0. 
 * 1. Call function with required number N.
 * 2. Create a new Count array. Set first value as 1.
 * 3. Set all other values as 0.
 * 4. FOR loop i from 1 to N.
 * 5.       FOR loop j from 1 to i.
 * 6.           Get Count[i - j] * Count[j - 1]
 * 7.           Set Count's current index as Count's current index + previous step value.
 * 8. Return the count[n] value.
 */
