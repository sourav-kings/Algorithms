using System;

namespace Product_Array_Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 3, 5, 6, 2 };
            int n = arr.Length;
            Console.WriteLine("The product array is : ");

            ProductArray(arr, n);
        }

        /* Function to print product array
    for a given array arr[] of size n */
        static void ProductArray(int[] arr, int n)
        {

            // Initialize memory to all arrays
            int[] left = new int[n];
            int[] right = new int[n];
            int[] prod = new int[n];

            int i, j;

            /* Left most element of left array 
            is always 1 */
            left[0] = 1;

            /* Rightmost most element of right
            array is always 1 */
            right[n - 1] = 1;

            /* Construct the left array */
            for (i = 1; i < n; i++)
                left[i] = arr[i - 1] * left[i - 1];

            /* Construct the right array */
            for (j = n - 2; j >= 0; j--)
                right[j] = arr[j + 1] * right[j + 1];

            /* Construct the product array using
            left[] and right[] */
            for (i = 0; i < n; i++)
                prod[i] = left[i] * right[i];

            /* print the constructed prod array */
            for (i = 0; i < n; i++)
                Console.Write(prod[i] + " ");

            return;
        }

        static void ProductArray_OptimizedSpace(int[] arr, int n)
        {
            int i, temp = 1;

            /* Allocate memory for the product
            array */
            int[] prod = new int[n];

            /* Initialize the product array as 1 */
            for (int j = 0; j < n; j++)
                prod[j] = 1;

            /* In this loop, temp variable contains
            product of elements on left side
            excluding arr[i] */
            for (i = 0; i < n; i++)
            {
                prod[i] = temp;
                temp *= arr[i];
            }

            /* Initialize temp to 1 for product on 
            right side */
            temp = 1;

            /* In this loop, temp variable contains
            product of elements on right side 
            excluding arr[i] */
            for (i = n - 1; i >= 0; i--)
            {
                prod[i] *= temp;
                temp *= arr[i];
            }

            /* print the constructed prod array */
            for (i = 0; i < n; i++)
                Console.Write(prod[i] + " ");

            return;
        }
    }
}
