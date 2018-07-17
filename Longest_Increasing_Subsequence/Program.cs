using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Increasing_Subsequence
{
    class Program
    {
        static int[] arr;
        static void Main(string[] args)
        {
            //arr = new int[]{ 10, 22, 9, 33, 21, 50, 41, 60 };
            //arr = new int[] { 10, 22, 9, 33 };
            //arr = new int[] { 0 };
            //arr = new int[] { };
            //arr = new int[] { 0, 8, 4, 12, 2 , 10, 6, 14 , 1, 9, 5, 13, 3, 11, 7, 15 };//test cases fail here
            arr = new int[] {  5, 13, 3, 11 };//test cases fail here
            int n = arr.Length;
            Console.WriteLine("Length of lis is " + lis(n) + "\n");
            Console.WriteLine("Length of lis is " + lis_DP(n) + "\n");
            Console.WriteLine("Length of lis is " + lis_test_Notworking(n) + "\n");
            Console.WriteLine("Length of lis is - SK TEST " + lis_DP_test_lis_test_Notworking(n) + "\n"); 
        }

       





        static int lis(int n)
        {
            if (n == 0) return 0;

            if (n == 1)
                return 1;

            int max = 1;

            for (int i = 1; i < n; i++)
                if (arr[n - 1] > arr[i - 1])
                    max = Math.Max(max, lis(i) + 1);

            return max;
        }

        static int lis_DP(int n)
        {
            int[] lis = new int[n];
            int max = 0;

            for (int i = 0; i < n; i++)
            {
                /* Initialize LIS values for all indexes */
                lis[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] > arr[j])
                        lis[i] = Math.Max(lis[i], lis[j] + 1);
                }
                max = Math.Max(max, lis[i]);
            }

            return max;
        }








        static int lis_test_Notworking(int n)
        {
            if (n == 0) return 0;

            if (n == 1)
                return 1;

            if (arr[n - 2] < arr[n - 1])
                return lis_test_Notworking(n - 1) + 1;
            else
                return lis_test_Notworking(n - 1);
        }

        static int lis_DP_test_lis_test_Notworking(int n)
        {
            if (n == 0) return 0;

            int[] lis = new int[n];
            lis[0] = 1;
            int max = 1;

            for (int i = 1; i < n; i++)
            {
                if (arr[i - 1] < arr[i])
                    lis[i] = lis[i - 1] + 1;
                else
                    lis[i] = lis[i - 1];

                max = Math.Max(max, lis[i]);
            }

            return max;
        }





    }
}


//https://www.geeksforgeeks.org/longest-increasing-subsequence/