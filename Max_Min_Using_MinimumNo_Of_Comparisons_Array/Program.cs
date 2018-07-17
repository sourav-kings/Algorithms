using System;

namespace Max_Min_Using_MinimumNo_Of_Comparisons_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1000, 11, 445, 1, 330, 3000 };
            int arr_size = 6;
            Pair minmax = GetMinMax(arr, arr_size);
            Console.WriteLine("nMinimum element is " + minmax.min);
            Console.WriteLine("nMaximum element is " + minmax.max);
        }

        static Pair GetMinMax(int[] arr, int n)
        {
            Pair minmax;
            int i;

            /*If there is only one element then return it as min and max both*/
            if (n == 1)
            {
                minmax.max = arr[0];
                minmax.min = arr[0];
                return minmax;
            }

            /* If there are more than one elements, then initialize min 
                and max*/
            if (arr[0] > arr[1])
            {
                minmax.max = arr[0];
                minmax.min = arr[1];
            }
            else
            {
                minmax.max = arr[1];
                minmax.min = arr[0];
            }

            for (i = 2; i < n; i++)
            {
                if (arr[i] > minmax.max)
                    minmax.max = arr[i];

                else if (arr[i] < minmax.min)
                    minmax.min = arr[i];
            }

            return minmax;
        }
    }



    struct Pair
    {
        internal int min;
        internal int max;
    }
}
/*
 * 2.5 / 150
 * https://www.geeksforgeeks.org/maximum-and-minimum-in-an-array/
 * 
 * METHOD 1 (Simple Linear Search)
 * Time Complexity: O(n)
 *      Worst case occurs when elements are sorted in descending order, and 
 *      Best case occurs when elements are sorted in ascending order.
 */
