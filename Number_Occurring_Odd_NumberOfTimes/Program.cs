using System;
using System.Collections.Generic;

namespace Number_Occurring_Odd_NumberOfTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 5, 4, 5, 2, 4, 3, 5, 2, 4, 4, 2 };
            int n = arr.Length;
            Console.WriteLine(GetOddOccurrence(arr, n));
            Console.WriteLine(GetOddOccurrence_Better(arr, n));
            Console.WriteLine(GetOddOccurrence_Best(arr, n)); 
        }

        // Funtion to find the element 
        // occurring odd number of times
        static int GetOddOccurrence(int[] arr, int arr_size)
        {
            for (int i = 0; i < arr_size; i++)
            {
                int count = 0;

                for (int j = 0; j < arr_size; j++)
                {
                    if (arr[i] == arr[j])
                        count++;
                }
                if (count % 2 != 0)
                    return arr[i];
            }
            return -1;
        }
        //Hashing - Time complexity of this solution is O(n). 
        //But it requires extra space for hashing.
        static int GetOddOccurrence_Better(int[] arr, int n)
        {
            Dictionary<int, int> hmap = new Dictionary<int, int>();

            // Putting all elements into the HashMap
            for (int i = 0; i < n; i++)
            {
                if (hmap.ContainsKey(arr[i]))
                {
                    int val = hmap[arr[i]];

                    // If array element is already present then
                    // increase the count of that element.
                    hmap[arr[i]] = val + 1;
                }
                else

                    // if array element is not present then put
                    // element into the HashMap and initialize 
                    // the count to one.
                    hmap[arr[i]] = 1;
            }

            // Checking for odd occurrence of each element present
            // in the HashMap 
            foreach (int a in hmap.Keys)
            {
                if (hmap[a] % 2 != 0)
                    return a;
            }
            return -1;
        }

        //Bitwise operation
        //XOR of two same nos. is 0, and 
        //XOR of a num x with 0 is x.
        static int GetOddOccurrence_Best(int[] arr, int arr_size)
        {
            int res = 0;
            for (int i = 0; i < arr_size; i++)
                res = res ^ arr[i];
            return res;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/find-the-number-occurring-odd-number-of-times/
 * 
 * Given an array of positive integers. 
 * All numbers occur even number of times except one number which occurs odd number of times. 
 * Find the number in O(n) time & constant space.
 */
