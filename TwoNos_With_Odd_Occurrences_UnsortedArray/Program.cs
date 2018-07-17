using System;

namespace TwoNos_With_Odd_Occurrences_UnsortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 2, 4, 5, 2, 3, 3, 1 };
            int arr_size = arr.Length;
            PrintTwoOdd(arr, arr_size);
        }

        // Prints two numbers that occur
        // odd number of times. Function
        // assumes that array size is at
        // least 2 and there are exactly
        // two numbers occurring odd number
        // of times.
        static void PrintTwoOdd(int[] arr, int size)
        {

            // Will hold XOR of two odd
            //occurring elements   
            int xor2 = arr[0];

            // Will have only single set
            // bit of xor2
            int set_bit_no;
            int i;

            //int n = size - 2;
            int x = 0, y = 0;

            // Get the xor of all the elements
            // in arr[].The xor will basically 
            // be xor of two odd occurring
            // elements
            for (i = 1; i < size; i++)
                xor2 = xor2 ^ arr[i];

            // Get one set bit in the xor2.
            // We get rightmost set bit in
            // the following line as it is
            // to get.
            set_bit_no = xor2 & ~(xor2 - 1);

            // divide elements in two sets: 
            // 1) The elements having the 
            // corresponding bit as 1. 
            // 2) The elements having the 
            // corresponding bit as 0.
            for (i = 0; i < size; i++)
            {
                // XOR of first set is finally 
                // going to hold one odd 
                // occurring number x
                if ((arr[i] & set_bit_no) > 0)
                    x = x ^ arr[i];

                // XOR of second set is finally
                // going to hold the other 
                // odd occurring number y
                else
                    y = y ^ arr[i];
            }

            Console.WriteLine("The two ODD elements are " +
                                              x + " & " + y);
        }
    }
}

/*
 * https://www.geeksforgeeks.org/find-the-two-numbers-with-odd-occurences-in-an-unsorted-array/
 * 
 * Find the two numbers with odd occurrences in an unsorted array
    Given an unsorted array that contains even number of occurrences for all numbers except two numbers. 
    Find the two numbers which have odd occurrences in O(n) time complexity and O(1) extra space.

    Examples:

    Input: {12, 23, 34, 12, 12, 23, 12, 45}
    Output: 34 and 45

    Input: {4, 4, 100, 5000, 4, 4, 4, 4, 100, 100}
    Output: 100 and 5000

    Input: {10, 20}
    Output: 10 and 20


    OPTIONS:-

    1. O(N * N)     --> Naive two loops
    2. O(N * logN)  --> Sorting using Merge
    3. O(N) time and O(N) space -->     Hashing
    4. O(N) time and O(1) space -->     Bitwise XOR
 */
