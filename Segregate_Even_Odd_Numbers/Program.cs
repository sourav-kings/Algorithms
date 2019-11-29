using System;

namespace Segregate_Even_Odd_Numbers_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 12, 34, 45, 9, 8, 90, 3 };

            segregateEvenOdd(arr);

            Console.Write("Array after segregation ");
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
        }


        static void segregateEvenOdd(int[] arr)
        {
            /* Initialize left and right indexes */
            int left = 0, right = arr.Length - 1;
            while (left < right)
            {
                /* Increment left index while we see 0 at left */
                while (arr[left] % 2 == 0 && left < right)
                    left++;

                /* Decrement right index while we see 1 at right */
                while (arr[right] % 2 == 1 && left < right)
                    right--;

                if (left < right)
                {
                    /* Swap arr[left] and arr[right]*/
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    left++;
                    right--;
                }
            }
        }
    }
}

/*
 * https://www.geeksforgeeks.org/segregate-even-and-odd-numbers/
 */
