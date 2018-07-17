// A C# program to find if there
// is a zero sum subarray
using System;
using System.Collections.Generic;

class GFG
{
    // Returns true if arr[] has
    // a subarray with sero sum
    static Boolean subArrayExists(int[] arr)
    {
        // Creates an empty hashMap hM
        Dictionary<int,
                   int> hM = new Dictionary<int,
                                            int>();
        // Initialize sum of elements
        int sum = 0;

        // Traverse through the given array
        for (int i = 0; i < arr.Length; i++)
        {
            // Add current element to sum
            sum += arr[i];

            // Return true in following cases
            // a) Current element is 0
            // b) sum of elements from 0 to i is 0
            // c) sum is already present in hash map
            if (arr[i] == 0 || sum == 0)
                return true;

            // Add sum to hash map
            hM[i] = sum;
        }

        // We reach here only when there is
        // no subarray with 0 sum
        return false;
    }

    // Driver Code
    public static void Main()
    {
        int[] arr = { -3, 2, 3, 1, 6 };
        if (subArrayExists(arr))
            Console.WriteLine("Found a subarray " +
                                     "with 0 sum");
        else
            Console.WriteLine("No Such Sub " +
                             "Array Exists!");
    }
}



/*
 * https://www.geeksforgeeks.org/find-if-there-is-a-subarray-with-0-sum/
 * 
 * Find if there is a subarray with 0 sum
 * 
 * 
 * We can also use hashing. The idea is to iterate through the array and for every element arr[i], 
 * calculate sum of elements form 0 to i (this can simply be done as sum += arr[i]). 
 * If the current sum has been seen before, then there is a zero sum array. 
 * Hashing is used to store the sum values, 
 * so that we can quickly store sum and find out whether the current sum is seen before or not.
 */
