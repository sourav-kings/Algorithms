using System;

namespace Segregate_0s_And_1s_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 0, 1, 0, 1, 1, 1 };
            int n = arr.Length;

            //Segregate0and1(arr, n);
            Segregate0and1_Faster(arr, n);
            Print(arr, n);
        }

        static void Segregate0and1(int[] arr, int n)
        {
            // counts the no of zeros in arr
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] == 0)
                    count++;
            }

            // loop fills the arr with 0 until count
            for (int i = 0; i < count; i++)
                arr[i] = 0;

            // loop fills remaining arr space with 1
            for (int i = count; i < n; i++)
                arr[i] = 1;
        }


        /*Function to put all 0s on
            left and all 1s on right*/
        static void Segregate0and1_Faster(int[] arr, int size)
        {
            /* Initialize left and right indexes */
            int left = 0, right = size - 1;

            while (left < right)
            {
                /* Increment left index while
                   we see 0 at left */
                while (arr[left] == 0 && left < right)
                    left++;

                /* Decrement right index while 
                   we see 1 at right */
                while (arr[right] == 1 && left < right)
                    right--;

                /* If left is smaller than right then
                   there is a 1 at left and a 0 at right. 
                   Exchange arr[left] and arr[right]*/
                if (left < right)
                {
                    arr[left] = 0;
                    arr[right] = 1;
                    left++;
                    right--;
                }
            }
        }




        // function to print segregated array
        static void Print(int[] arr, int n)
        {
            Console.WriteLine("Array after segregation is ");
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
        }
    }
}
/*
 * https://www.geeksforgeeks.org/segregate-0s-and-1s-in-an-array-by-traversing-array-once/
 * 
 */
