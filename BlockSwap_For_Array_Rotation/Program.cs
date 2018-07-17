using System;

namespace BlockSwap_For_Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            LeftRotate(arr, 2, 7);
            PrintArray(arr, 7);
            Getchar();
        }
        static void LeftRotate(int[] arr, int d, int n)
        {
            /* Return If number of elements to be rotated is 
              zero or equal to array size */
            if (d == 0 || d == n)
                return;

            /*If number of elements to be rotated is exactly 
              half of array size */
            if (n - d == d)
            {
                Swap(arr, 0, n - d, d);
                return;
            }

            /* If A is shorter*/
            if (d < n - d)
            {
                Swap(arr, 0, n - d, d);
                LeftRotate(arr, d, n - d);
            }
            else /* If B is shorter*/
            {
                Swap(arr, 0, d, n - d);
                LeftRotate(arr + n - d, 2 * d - n, d); /*This is tricky*/
            }
        }

        /*UTILITY FUNCTIONS*/
        /* function to print an array */
        static void PrintArray(int[] arr, int size)
        {
            int i;
            for (i = 0; i < size; i++)
                Console.WriteLine(arr[i]);
            Console.WriteLine("\n ");
        }

        /*This function swaps d elements starting at index fi
          with d elements starting at index si */
        static void Swap(int[] arr, int fi, int si, int d)
        {
            int i, temp;
            for (i = 0; i < d; i++)
            {
                temp = arr[fi + i];
                arr[fi + i] = arr[si + i];
                arr[si + i] = temp;
            }
        }
    }
}

/*
 * https://www.geeksforgeeks.org/block-swap-algorithm-for-array-rotation/
 */
