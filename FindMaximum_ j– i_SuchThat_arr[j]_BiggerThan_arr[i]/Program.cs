using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMaximum__j__i_SuchThat_arr_j__BiggerThan_arr_i_
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 9, 2, 3, 4, 5, 6, 7, 8, 18, 0 };
            //int[] arr = { 34, 8, 10, 3, 2, 80, 30, 33, 1 };
            //int[] arr = { 34, 8, 10, 3 };
            int[] arr = { 34, 8, 10, 3, 9 };
            int n = arr.Length;
            
            Console.WriteLine(maxIndexDiff(arr, n));

            Console.WriteLine(maxIndexDiffFaster(arr, n)); 
        }

        /* For a given array arr[], returns the maximum j-i such that
       arr[j] > arr[i] 
       Time Complexity - O(n*n)*/
        static int maxIndexDiff(int[] arr, int n)
        {
            int maxDiff = -1;
            
            for (int i = 0; i <= n; i++)
            {
                for (int j = n - 1; j >= i; j--)
                {
                    if (arr[j] > arr[i])
                        maxDiff = Math.Max(maxDiff, (j - i));                        
                }
            }

            return maxDiff;
        }





        /* Utility Functions to get max and minimum of two integers */
        static int max(int x, int y)
        {
            return x > y ? x : y;
        }

        static int min(int x, int y)
        {
            return x < y ? x : y;
        }

        /* For a given array arr[], returns the maximum j-i such that
           arr[j] > arr[i] 
           Time Complexity - O(n)*/
        static int maxIndexDiffFaster(int[] arr, int n)
        {
            int maxDiff;
            int i, j;

            int[] RMax = new int[n];
            int[] LMin = new int[n];

            /* Construct LMin[] such that LMin[i] stores the minimum value
               from (arr[0], arr[1], ... arr[i]) */
            LMin[0] = arr[0];
            for (i = 1; i <= n-1; i++)
                LMin[i] = min(arr[i], LMin[i - 1]);

            /* Construct RMax[] such that RMax[j] stores the maximum value
               from (arr[j], arr[j+1], ..arr[n-1]) */
            RMax[n - 1] = arr[n - 1];
            for (j = n - 2; j >= 0; j--)
                RMax[j] = max(arr[j], RMax[j + 1]);

            /* Traverse both arrays from left to right to find optimum j - i
               This process is similar to merge() of MergeSort */
            i = 0; j = 0; maxDiff = -1;
            while (j < n && i < n)
            {
                if (RMax[j] > LMin[i])
                {
                    maxDiff = max(maxDiff, j - i);
                    j++;
                }
                else
                    i++;
            }

            return maxDiff;
        }
    }
}


//http://www.geeksforgeeks.org/given-an-array-arr-find-the-maximum-j-i-such-that-arrj-arri/

//Average Difficulty : 3.8/5.0
//Based on 155 vote(s)