using System;

namespace Two_Elements_WhoseSum_ClosestTo_Zero
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 60, -10, 70, -80, 85 };

            MinAbsSumPair(arr, 6);
        }

        static void MinAbsSumPair(int[] arr,
                        int arr_size)
        {

            int l, r, min_sum, sum, min_l, min_r;

            /* Array should have at least two elements*/
            if (arr_size < 2)
            {
                Console.Write("Invalid Input");
                return;
            }

            /* Initialization of values */
            min_l = 0;
            min_r = 1;
            min_sum = arr[0] + arr[1];

            for (l = 0; l < arr_size - 1; l++)
            {
                for (r = l + 1; r < arr_size; r++)
                {
                    sum = arr[l] + arr[r];
                    if (Math.Abs(min_sum) > Math.Abs(sum))
                    {
                        min_sum = sum;
                        min_l = l;
                        min_r = r;
                    }
                }
            }

            Console.Write(" The two elements whose " +
                                "sum is minimum are " +
                            arr[min_l] + " and " + arr[min_r]);
        }


        static void MinAbsSumPair_Faster(int[] arr, int n)
        {
            // Variables to keep track 
            // of current sum and minimum sum
            int sum, min_sum = 999999;

            // left and right index variables
            int l = 0, r = n - 1;

            // variable to keep track of the left
            // and right pair for min_sum
            int min_l = l, min_r = n - 1;

            /* Array should have at least two elements*/
            if (n < 2)
            {
                Console.Write("Invalid Input");
                return;
            }

            /* Sort the elements */
            Array.Sort(arr, l, r);

            while (l < r)
            {
                sum = arr[l] + arr[r];

                /*If abs(sum) is less then update the result items*/
                if (Math.Abs(sum) < Math.Abs(min_sum))
                {
                    min_sum = sum;
                    min_l = l;
                    min_r = r;
                }
                if (sum < 0)
                    l++;
                else
                    r--;
            }

            Console.Write(" The two elements whose " +
                                    "sum is minimum are " +
                                arr[min_l] + " and " + arr[min_r]);
        }

    }
}
/*
 * https://www.geeksforgeeks.org/two-elements-whose-sum-is-closest-to-zero/
 * 
 * METHOD 1 (Simple) 
 * For each element, find the sum of it with every other element in the array and compare sums. 
 * Finally, return the minimum sum.
 * Time complexity: O(n^2)
 * 
 * 
 * METHOD 2 (Use Sorting) 
 * Algorithm 
    1) Sort all the elements of the input array.
    2) Use two index variables l and r to traverse from left and right ends respectively. Initialize l as 0 and r as n-1.
    3) sum = a[l] + a[r]
    4) If sum is -ve, then l++  
    5) If sum is +ve, then r–
    6) Keep track of abs min sum.
    7) Repeat steps 3, 4, 5 and 6 while l < r

    Time Complexity: complexity to sort + complexity of finding the optimum pair = O(nlogn) + O(n) = O(nlogn)
 */
