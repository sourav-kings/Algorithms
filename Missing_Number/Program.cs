using System;

namespace Missing_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 4, 5, 6 };
            int miss = getMissingNo(a, 5);//getMissingNo_XOR(a, 5);
            Console.Write(miss);
        }


        // Function to ind missing number
        static int getMissingNo(int[] a, int n)
        {
            int total = (n + 1) * (n + 2) / 2;

            for (int i = 0; i < n; i++)
                total -= a[i];

            return total;
        }


        /*
         * XOR method
         *   1) XOR all the array elements, let the result of XOR be X1.
              2) XOR all numbers from 1 to n, let XOR be X2.
              3) XOR of X1 and X2 gives the missing number.
         */

        static int getMissingNo_XOR(int[] a, int n)
        {
            int x1 = a[0];
            int x2 = 1;

            /* For xor of all the elements 
            in array */
            for (int i = 1; i < n; i++)
                x1 = x1 ^ a[i];

            /* For xor of all the elements 
            from 1 to n+1 */
            for (int i = 2; i <= n + 1; i++)
                x2 = x2 ^ i;

            return (x1 ^ x2);
        }

    }
}

/*
 * https://www.geeksforgeeks.org/find-the-missing-number/
 * 
 * You are given a list of n-1 integers and these integers are in the range of 1 to n. 
 * There are no duplicates in list. One of the integers is missing in the list. 
 * Find the missing integer.
 * 
 * 
 * 
 * 
 * XOR

 * The XOR operator outputs a 1 whenever the inputs do not match * 
 * 
 * 
 * 
 * to find 2 or more duplicates --> 
 * BIT SET method
 * https://javarevisited.blogspot.com/2014/11/how-to-find-missing-number-on-integer-array-java.html?source=post_page---------------------------
 */
