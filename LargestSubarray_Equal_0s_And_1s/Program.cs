using System;
using System.Collections.Generic;

namespace LargestSubarray_Equal_0s_And_1s
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 0, 0, 1, 0, 1, 1 };
            int size = arr.Length;
            FindSubArray(arr, size);
            FindSubArray_Faster(arr, size);//O(n) time and O(1) space. 
        }

        private static int FindSubArray_Faster(int[] arr, int n)
        {
            // Creates an empty hashMap hM

            Dictionary<int, int> hM = new Dictionary<int, int>();

            int sum = 0;     // Initialize sum of elements
            int max_len = 0; // Initialize result
            int ending_index = -1;
            int start_index = 0;

            for (int i = 0; i < n; i++)
            {
                arr[i] = (arr[i] == 0) ? -1 : 1;
            }

            // Traverse through the given array

            for (int i = 0; i < n; i++)
            {
                // Add current element to sum

                sum += arr[i];

                // To handle sum=0 at last index

                if (sum == 0)
                {
                    max_len = i + 1;
                    ending_index = i;
                }

                // If this sum is seen before, then update max_len
                // if required

                if (hM.ContainsKey(sum))
                {
                    if (max_len < i - hM[sum + n])
                    {
                        max_len = i - hM[sum + n];
                        ending_index = i;
                    }
                }
                else // Else put this sum in hash table
                    hM[sum + n] =  i;
            }

            for (int i = 0; i < n; i++)
            {
                arr[i] = (arr[i] == -1) ? 0 : 1;
            }

            int end = ending_index - max_len + 1;
            Console.WriteLine(end + " to " + ending_index);

            return max_len;
        }


        // This function Prints the starting and ending
        // indexes of the largest subarray with equal 
        // number of 0s and 1s. Also returns the size 
        // of such subarray.

        static int FindSubArray(int[] arr, int n)
        {
            int sum = 0;
            int maxsize = -1, startindex = 0;
            int endindex = 0;

            // Pick a starting point as i
            for (int i = 0; i < n - 1; i++)
            {
                sum = (arr[i] == 0) ? -1 : 1;

                // Consider all subarrays starting from i

                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] == 0)
                        sum += -1;
                    else
                        sum += 1;

                    // If this is a 0 sum subarray, then 
                    // compare it with maximum size subarray
                    // calculated so far

                    if (sum == 0 && maxsize < j - i + 1)
                    {
                        maxsize = j - i + 1;
                        startindex = i;
                    }
                }
            }
            endindex = startindex + maxsize - 1;
            if (maxsize == -1)
                Console.WriteLine("No such subarray");
            else
                Console.WriteLine(startindex + " to " + endindex);

            return maxsize;
        }
    }
}


///https://www.geeksforgeeks.org/largest-subarray-with-equal-number-of-0s-and-1s/
