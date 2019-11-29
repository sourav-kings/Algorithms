using System;

namespace Pair_With_GivenDifference_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 8, 30, 40, 100 };
            int n = 60;

            findPair(arr, n);
        }

        // The function assumes that the array is sorted
        static bool findPair(int[] arr, int n)
        {
            int size = arr.Length;

            // Initialize positions of two elements
            int i = 0, j = 1;

            // Search for a pair
            while (i < size && j < size)
            {
                if (i != j && arr[j] - arr[i] == n)
                {
                    Console.Write("Pair Found: "
                    + "( " + arr[i] + ", " + arr[j] + " )");

                    return true;
                }
                else if (arr[j] - arr[i] < n)
                    j++;
                else
                    i++;
            }

            Console.Write("No such pair");

            return false;
        }
    }
}


/*
 * https://www.geeksforgeeks.org/find-a-pair-with-the-given-difference/
 * 
 * Find a pair with the given difference
Given an unsorted array and a number n, 
find if there exists a pair of elements in the array whose difference is n.
 */
