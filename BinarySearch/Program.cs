using System;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 4, 10, 40 };
            int n = arr.Length;
            int x = 10;

            int result = BinarySearch(arr, 0, n - 1, x);

            if (result == -1)
                Console.WriteLine("Element not present");
            else
                Console.WriteLine("Element found at index "
                                  + result);
        }

        // Returns index of x if it is present in 
        // arr[l..r], else return -1 
        static int BinarySearch(int[] arr, int l, int r, int x)
        {
            if (r >= l)
            {
                int mid = l + (r - l) / 2;

                // If the element is present at the 
                // middle itself 
                if (arr[mid] == x)
                    return mid;

                // If element is smaller than mid, then 
                // it can only be present in left subarray 
                if (arr[mid] > x)
                    return BinarySearch(arr, l, mid - 1, x);

                // Else the element can only be present 
                // in right subarray 
                return BinarySearch(arr, mid + 1, r, x);
            }

            // We reach here when element is not present 
            // in array 
            return -1;
        }
    }
}



/*
 * https://www.geeksforgeeks.org/binary-search/
 *  
 * 1.5 (250)
 * 
 * 
 * Time Complexity:
The time complexity of Binary Search can be written as

T(n) = T(n/2) + c 
The above recurrence can be solved either using Recurrence T ree method or Master method. 
It falls in case II of Master Method and solution of the recurrence is Theta(Logn).

Auxiliary Space: O(1) in case of iterative implementation. In case of recursive implementation, 
O(Logn) recursion call stack space.
 */
