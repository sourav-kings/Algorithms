using System;

namespace Check_If_Elements_Are_Consecutive_Array
{
    class Program
    {
        //Check if array elements are consecutive in O(n) time and O(1) space 
        //(Handles Both Positive and negative numbers)
        // Driver code
        public static void Main()
        {
            int[] arr = { 2, 1, 0, -3, -1, -2 };
            int n = arr.Length;

            bool result = AreConsecutives(arr, n);
            if (result == true)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

        }


        // Function to check if elements  
        // are consecutive
        static bool AreConsecutives(int[] arr,
                                    int n)
        {

            // Find minimum element in array
            int first_term = int.MaxValue;

            for (int j = 0; j < n; j++)
            {
                if (arr[j] < first_term)
                    first_term = arr[j];
            }

            // Calculate AP sum
            int ap_sum = (n * (2 * first_term +
                         (n - 1) * 1)) / 2;

            // Calculate given array sum
            int arr_sum = 0;
            for (int i = 0; i < n; i++)
                arr_sum += arr[i];

            // Compare both sums and return
            return ap_sum == arr_sum;
        }

    }
}

/*
 * https://www.geeksforgeeks.org/check-array-elements-consecutive-time-o1-space-handles-positive-negative-numbers/
 * 
 * Average Difficulty : 2.9/5.0
    Based on 12 vote(s)


 * Input : arr[] = {5, 4, 2, 1, 3}
    Output : Yes

    Input : arr[] = {2, 1, 0, -3, -1, -2}
    Output : Yes


    Find the sum of the array.
    If given array elements are consecutive that means they are in AP. So, find min element i.e. first term of AP then calculate ap_sum = n/2 * [2a +(n-1)*d] where d = 1. So, ap_sum = n/2 * [2a +(n-1)]
    Compare both sums. Print Yes if equal, else No.


 */
