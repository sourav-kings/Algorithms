using System;

namespace Two_Repeating_Elements_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 2, 4, 5, 2, 3, 1 };
            int arr_size = arr.Length;

            PrintRepeating_Faster(arr, arr_size);
            PrintRepeating_Faster_SpaceOptimized(arr, arr_size);
        }


        static void PrintRepeating_Faster(int[] arr,
                                int size)
        {
            int[] count = new int[size];
            int i;

            Console.Write("Repeated elements are: ");
            for (i = 0; i < size; i++)
            {
                if (count[arr[i]] == 1)
                    Console.Write(arr[i] + " ");
                else
                    count[arr[i]]++;
            }
        }


        static void PrintRepeating_Faster_SpaceOptimized(int[] arr, int size)
        {
            /* S is for sum of elements in arr[] */
            int S = 0;

            /* P is for product of elements in arr[] */
            int P = 1;

            /* x and y are two repeating elements */
            int x, y;

            /* D is for difference of x and y, i.e., x-y*/
            int D;

            int n = size - 2, i;

            /* Calculate Sum and Product 
             of all elements in arr[] */
            for (i = 0; i < size; i++)
            {
                S = S + arr[i];
                P = P * arr[i];
            }

            /* S is x + y now */
            S = S - n * (n + 1) / 2;

            /* P is x*y now */
            P = P / Fact(n);

            /* D is x - y now */
            D = (int)Math.Sqrt(S * S - 4 * P);


            x = (D + S) / 2;
            y = (S - D) / 2;

            Console.WriteLine("The two" +
                    " repeating elements are :");
            Console.Write(x + " " + y);
        }

        static int Fact(int n)
        {
            return (n == 0) ? 1 : n * Fact(n - 1);
        }
    }
}
/*
 * https://www.geeksforgeeks.org/find-the-two-repeating-elements-in-a-given-array/
 * 
 * Three Methods
 * 
 * 1. Naive 
 *      Time Complexity - O(n*n)
 *      Space Complexity - O(n)
 *      
 *      
 * 2. Count Array 
 *      Time Complexity - O(n)
 *      Space Complexity - O(n)
 *      
 *      
 * 3. Make Two Equations
 *      Time Complexity - O(n)
 *      Space Complexity - O(1)
 *      Analysis:-
 *          sum of integers from 1 to n is n(n+1)/2 and product is n!. 
 *          Those values when calculated upon Sum and Product of array resp., 
 *              we get both nos.
 *          
 */
