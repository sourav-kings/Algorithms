using System;

namespace Union_Intersection_Of_Two_SortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr1 = { 1, 2, 2, 2, 3 };
            //int[] arr2 = { 2, 3, 4, 5 };

            //UnionArray(arr1, arr2);


            int[] arr1 = { 1, 2, 4, 5, 6 };
            int[] arr2 = { 2, 3, 5, 7 };
            int m = arr1.Length;
            int n = arr2.Length;

            PrintIntersection(arr1, arr2, m, n);
        }


        static void UnionArray(int[] arr1,
                       int[] arr2)
        {
            int m = arr1[arr1.Length - 1];
            int n = arr2[arr2.Length - 1];

            int ans = 0;

            if (m > n)
                ans = m;
            else
                ans = n;

            int[] newtable = new int[ans + 1];

            Console.Write(arr1[0] + " ");

            ++newtable[arr1[0]];

            for (int i = 1; i < arr1.Length; i++)
            {
                if (arr1[i] != arr1[i - 1])
                {
                    Console.Write(arr1[i] + " ");
                    ++newtable[arr1[i]];
                }
            }

            for (int j = 0; j < arr2.Length; j++)
            {
                if (newtable[arr2[j]] == 0)
                {
                    Console.Write(arr2[j] + " ");
                    ++newtable[arr2[j]];
                }
            }
        }



        static void PrintIntersection(int[] arr1,
                        int[] arr2, int m, int n)
        {
            int i = 0, j = 0;

            while (i < m && j < n)
            {
                if (arr1[i] < arr2[j])
                    i++;
                else if (arr2[j] < arr1[i])
                    j++;
                else
                {
                    Console.Write(arr2[j++] + " ");
                    i++;
                }
            }
        }
    }
}
/*
 * https://www.geeksforgeeks.org/union-and-intersection-of-two-sorted-arrays-2/
 * 
 * Time Complexity : O(m + n)
 */
