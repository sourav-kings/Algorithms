using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subarray_With_Given_Sum
{
    class Program
    {
        /*
         * HOW THE OPTIMIZED METHOD WORKS --
         * 
         *  At any given index (i), there's a "current total sum". 
         *  The "diff. value" ss obtained after removing target sum from "current total sum". 
         *  If this "diff. value" exists as a "current total sum" for any previously occured index (x), 
         *  then it implies that a subarray with target sum does exist. 
         *  And the range of this subarray is from (x+1) to i.
         */

        /*
         * Given an unsorted array of nonnegative integers, find a continuos subarray which adds to a given number
         * Input: arr[] = {1, 4, 20, 3, 10, 5}, sum = 33
         * Ouptut: Sum found between indexes 2 and 4
         * There may be more than one subarrays with sum as the given sum. 
         * This solution prints first such subarray. 
         * 
         * Given an unsorted array of integers, find a subarray which adds to a given number. 
         * If there are more than one subarrays with sum as the given number, print any of them.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("\n");
            int[] arr = { 1, 4, 20, 3, 10, 5 };
            int sum = 33;
            subArraySum(arr, arr.Length, sum);


            Console.WriteLine("\n");
            int[] arr2 = {  2, 10, -2, -20, 10 };
            //int sum2 = -10;
            int sum2 = 8;
            subArraySumForNegetive(arr2, arr2.Length, sum2);

            Console.WriteLine("\n");
            int[] arr3 = { -10, 0, 2, -2, -20, 10 };
            int sum3 = 20;
            subArraySumForNegetive(arr3, arr3.Length, sum3);

            Console.WriteLine("\n");
            int[] arr4 = { 1, 4, 20, 3, 10, 5 };
            int sum4 = 33;
            subArraySumForNegetive(arr4, arr4.Length, sum4);

            Console.WriteLine("\n");
            int[] arr5 = { 15, 2, 4, 8, 9, 5, 10, 23 };
            int sum5 = 23;
            subArraySum(arr5, arr5.Length, sum5);

            Console.WriteLine("\n");
            int[] arr6 = { 1, 3, 8, 9 };
            int sum6 = 11;
            subArraySum(arr6, arr6.Length, sum6);

            Console.WriteLine("\n");
            int[] arr7 = { 2, -10, 30, 5 };
            int sum7 = 20;
            subArraySumForNegetive(arr7, arr7.Length, sum7);


            Console.WriteLine("\n");
            int[] arr8 = { 10, 2, -2, -20, 10 };
            int sum8 = -10;
            subArraySumForNegetive(arr8, arr8.Length, sum8);


            Console.WriteLine("\n");
        }

        // Function to print subarray with sum as given sum
        static void subArraySumForNegetive(int[] arr, int n, int sum)
        {
            // create an empty map
            Dictionary<int, int> map = new Dictionary<int, int>();

            // Maintains sum of elements so far
            int curr_sum = 0;

            for (int i = 0; i < n; i++)
            {
                // add current element to curr_sum
                curr_sum = curr_sum + arr[i];

                // if curr_sum is equal to target sum
                // we found a subarray starting from index 0
                // and ending at index i
                if (curr_sum == sum)
                {
                    Console.WriteLine("Sum found between indexes {0} to {1} ", 0, i);
                    return;
                }

                // If curr_sum - sum already exists in map
                // we have found a subarray with target sum
                if (map.ContainsKey(curr_sum - sum))
                {
                    Console.WriteLine("Sum found between indexes {0} to {1}", map[curr_sum - sum] + 1, i);
                    return;
                }

                map[curr_sum] = i;
            }

            // If we reach here, then no subarray exists
            Console.Write("No subarray with given sum exists");
        }

        /* Returns true if the there is a subarray of arr[] with sum equal to 
         * 'sum' otherwise returns false.  Also, prints the result */
        static void subArraySum(int[] arr, int n, int sum)
        {
            int curr_sum=0, start = 0;

            // Pick a starting point
            for (int i = 0; i <= n; i++)
            {
                // Add this element to curr_sum
                curr_sum = curr_sum + arr[i];

                // If curr_sum exceeds the sum, then remove the starting elements
                while (curr_sum > sum && start < i)
                {
                    curr_sum = curr_sum - arr[start];
                    start++;
                }

                // If curr_sum becomes equal to sum, then return true
                if (curr_sum == sum)
                {
                    Console.WriteLine("(Only positives) Sum found between indexes " + start
                            + " and " + i);
                    return;
                }

            }

            Console.WriteLine("No subarray found");
            return;
        }

    }
}

//Handles negetive numbers:-
//http://www.geeksforgeeks.org/find-subarray-with-given-sum-in-array-of-integers/
//Average Difficulty : 3.5/5.0
//Based on 39 vote(s)

/*
 * ALGO::
 * 
 * A simple solution is to consider all subarrays one by one and check if sum of every subarray is equal to given sum or not. 
 * The complexity of this solution would be O(n^2).
 * 
 * An efficient way is to use a map. 
 * The idea is to maintain sum of elements encountered so far in a variable (say curr_sum). 
 * Let the given number is sum. Now for each element, we check if curr_sum – sum exists in the map or not. 
 * If we found it in the map that means, we have a subarray present with given sum, 
 * else we insert curr_sum into the map and proceed to next element. 
 * If all elements of the array are processed and we didn’t find any subarray with given sum, then subarray doesn’t exists.

 */


//Handles positive numbers
//http://www.geeksforgeeks.org/find-subarray-with-given-sum/
//Average Difficulty : 2.8/5.0
//Based on 115 vote(s)
/*
 * Time complexity of method 2 looks more than O(n), but if we take a closer look at the program, 
 * then we can figure out the time complexity is O(n). 
 * We can prove it by counting the number of operations performed on every element of arr[] in worst case. 
 * There are at most 2 operations performed on every element: 
 *          (a) the element is added to the curr_sum (b) the element is subtracted from curr_sum. 
 * So the upper bound on number of operations is 2n which is O(n).
 * 
 * The above solution doesn’t handle negative numbers.

 * ALGO::
 * 
 * 0. 
 * 1. Initialize a variable curr_sum as first element. curr_sum indicates the sum of current subarray.
 * 2. Start from the second element and add all elements one by one to the curr_sum.
 * 3. If curr_sum becomes equal to sum, then print the solution.
 * 4. If curr_sum exceeds the sum, then remove trailing elements while curr_sum is greater than sum.
 */
