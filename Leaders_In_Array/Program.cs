using System;

namespace Leaders_In_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 16, 17, 4, 3, 5, 2 };
            int n = arr.Length;
            //PrintLeaders(arr, n);
            PrintLeaders_Faster(arr, n);
        }

        static void PrintLeaders(int[] arr, int size)
        {
            for (int i = 0; i < size; i++)
            {
                int j;
                for (j = i + 1; j < size; j++)
                {
                    if (arr[i] <= arr[j])
                        break;
                }
                if (j == size) // the loop didn't break
                    Console.Write(arr[i] + " ");
            }
        }

        static void PrintLeaders_Faster(int[] arr, int size)
        {
            int max_from_right = arr[size - 1];

            /* Rightmost element is always leader */
            Console.Write(max_from_right + " ");

            for (int i = size - 2; i >= 0; i--)
            {
                if (max_from_right < arr[i])
                {
                    max_from_right = arr[i];
                    Console.Write(max_from_right + " ");
                }
            }
        }
    }
}

/*
 * https://www.geeksforgeeks.org/?p=3511
 */
