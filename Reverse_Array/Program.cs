using System;

namespace Reverse_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6 };

            PrintArray(arr, 6);
            ReveseArray_Iterative(arr, 0, 5);

            Console.WriteLine("Reversed array is ");
            PrintArray(arr, 6);
        }


        /* Function to reverse arr[] 
from start to end*/
        static void ReveseArray_Recursive(int[] arr, int start,
                                            int end)
        {
            int temp;
            if (start >= end)
                return;

            temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;

            ReveseArray_Recursive(arr, start + 1, end - 1);
        }


        static void ReveseArray_Iterative(int[] arr,
                   int start, int end)
        {
            int temp;

            while (start < end)
            {
                temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }

        /* Utility that prints out an 
        array on a line */
        static void PrintArray(int[] arr, int size)
        {
            for (int i = 0; i < size; i++)
                Console.Write(arr[i] + " ");

            Console.WriteLine("");
        }
    }
}
/*
 * 
 */