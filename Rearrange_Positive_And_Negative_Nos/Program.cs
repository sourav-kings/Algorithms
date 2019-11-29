using System;

namespace Rearrange_Positive_And_Negative_Nos
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { -1, 2, -3, 4, 5, 6, -7, 8, 9 };
            int n = arr.Length;
            Rearrange(arr, n);
            PrintArray(arr, n);
        }

        // The main function that rearranges elements 
        // of given array. It puts positive elements 
        // at even indexes (0, 2, ..) and negative 
        // numbers at odd indexes (1, 3, ..).
        static void Rearrange(int[] arr, int n)
        {
            // The following few lines are similar to partition
            // process of QuickSort. The idea is to consider 0
            // as pivot and divide the array around it.
            int i = -1, temp = 0;
            for (int j = 0; j < n; j++)
            {
                if (arr[j] < 0)
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // Now all positive numbers are at end 
            // and negative numbers at the beginning of 
            // array. Initialize indexes for starting point
            // of positive and negative numbers to be swapped
            int pos = i + 1, neg = 0;

            // Increment the negative index by 2 and
            // positive index by 1, i.e., swap every 
            // alternate negative number with next positive number
            while (pos < n && neg < pos && arr[neg] < 0)
            {
                temp = arr[neg];
                arr[neg] = arr[pos];
                arr[pos] = temp;
                pos++;
                neg += 2;
            }
        }


        // A utility function to print an array
        static void PrintArray(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
        }
    }
}
/*
 * https://www.geeksforgeeks.org/rearrange-positive-and-negative-numbers-publish/
 * 
 * Rearrange positive and negative numbers in O(n) time and O(1) extra space
 * 
 * An array contains both positive and negative numbers in random order. 
 * Rearrange the array elements so that positive and negative numbers are placed alternatively.
 * 
 * For example, if the input array is [-1, 2, -3, 4, 5, 6, -7, 8, 9], 
 * then the output should be [9, -7, 8, -3, 5, -1, 2, 4, 6]
 * 
 * 
 * Time Complexity: O(n) where n is number of elements in given array.
 * Auxiliary Space: O(1)
 * 
 * 
 * The solution is to first separate positive and negative numbers using partition process of QuickSort. 
 * In the partition process, consider 0 as value of pivot element 
 * so that all negative numbers are placed before positive numbers. 
 * Once negative and positive numbers are separated, 
 * we start from the first negative number and first positive number, 
 * and swap every alternate negative number with next positive number.
 */
