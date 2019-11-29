using System;

namespace Replace_EveryElement_With_GreatestElement_On_RightSide
{
    class Program
    {
        public static void Main()
        {
            int[] arr = { 16, 17, 4, 3, 5, 2 };
            NextGreatest(arr);
            Console.WriteLine("The modified array:");
            PrintArray(arr);
        }

        /* Function to replace every element with 
            the next greatest element */
        static void NextGreatest(int[] arr)
        {
            int size = arr.Length;

            // Initialize the next greatest element
            int max_from_right = arr[size - 1];

            // The next greatest element for the 
            // rightmost element is always -1
            arr[size - 1] = -1;

            // Replace all other elements with the
            // next greatest
            for (int i = size - 2; i >= 0; i--)
            {
                // Store the current element (needed
                // later for updating the next 
                // greatest element)
                int temp = arr[i];

                // Replace current element with 
                // the next greatest
                arr[i] = max_from_right;

                // Update the greatest element, if 
                // needed
                if (max_from_right < temp)
                    max_from_right = temp;
            }
        }

        /* A utility Function that prints an array */
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
        }
    }
}
/*
 * https://www.geeksforgeeks.org/replace-every-element-with-the-greatest-on-right-side/
 * 
 * A tricky method is to replace all elements using one traversal of the array. 
 * The idea is to start from the rightmost element, move to the left side one by one, 
 * and keep track of the maximum element. Replace every element with the maximum element.
 */
