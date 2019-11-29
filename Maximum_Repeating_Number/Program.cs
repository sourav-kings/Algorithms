using System;

namespace Maximum_Repeating_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 3, 5, 3, 4, 1, 7, 5, 5 };
            int n = arr.Length;
            int k = 8;

            Console.WriteLine("Maximum repeating "
                              + "element is: "
                      + MaxRepeating(arr, n, k));
        }


        // Returns maximum repeating element 
        // in arr[0..n-1].
        // The array elements are in range 
        // from 0 to k-1
        static int MaxRepeating(int[] arr,
                                 int n, int k)
        {
            // Iterate though input array, for
            // every element arr[i], increment
            // arr[arr[i]%k] by k
            for (int i = 0; i < n; i++)
                arr[(arr[i] % k)] += k;

            // Find index of the maximum 
            // repeating element
            int max = arr[0], result = 0;

            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    result = i;
                }
            }

            // Return index of the 
            // maximum element
            //return result;
            return (max / k > 1) ? result : -1;
        }


    }
}

/*
 * https://www.geeksforgeeks.org/find-the-maximum-repeating-number-in-ok-time/
 * 
 * Find the maximum repeating number in O(n) time and O(1) extra space
 * 
 * Naive approach ----> Time complexity is O(n*n)
 * Better approach (Extra array) ---> Space complexity is O(k)
 * 
 * Desired approach ----> Time and Spacce complexity is O(n) and O(1) resp.
 */
