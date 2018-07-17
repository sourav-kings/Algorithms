using System;

namespace Dutch_NationalFlag_Algorithm_SortArrayOf0s1s2s
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1 };
            int arr_size = arr.Length;
            Sort012(arr, arr_size);

            Console.Write("Array after seggregation ");

            PrintArray(arr, arr_size);
        }


        // Sort the input array, the array is assumed to
        // have values in {0, 1, 2}
        static void Sort012(int[] a, int arr_size)
        {
            int lo = 0;
            int hi = arr_size - 1;
            int mid = 0, temp = 0;

            while (mid <= hi)
            {
                switch (a[mid])
                {
                    case 0:
                        {
                            temp = a[lo];
                            a[lo] = a[mid];
                            a[mid] = temp;
                            lo++;
                            mid++;
                            break;
                        }
                    case 1:
                        mid++;
                        break;
                    case 2:
                        {
                            temp = a[mid];
                            a[mid] = a[hi];
                            a[hi] = temp;
                            hi--;
                            break;
                        }
                }
            }
        }

        /* Utility function to print array arr[] */
        static void PrintArray(int[] arr, int arr_size)
        {
            int i;

            for (i = 0; i < arr_size; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine("");
        }
    }
}
/*
 * Average Difficulty : 2.7/5.0
 * Based on 226 vote(s)
 * 
 * https://www.geeksforgeeks.org/sort-an-array-of-0s-1s-and-2s/
 * 
 * http://users.monash.edu/~lloyd/tildeAlgDS/Sort/Flag/
 * 
 * Time complexity is O(n).
 * Space complexity is O(1).
 */
