using System;

namespace Rearrange_Array_In_Max_Min_Form
{
    class Program
    {
        static int[] arr;

        static void Main(string[] args)
        {
            arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine("Original Array ");
            Array.ForEach(arr, x => Console.Write(x.ToString() + " "));

            Console.WriteLine(" ");
            //Rearrange();
            Rearrange_SpaceOptimized();

            Console.WriteLine("Modified Array ");
            Array.ForEach(arr, x => Console.Write(x.ToString() + " "));
        }


        // Prints max at first position, min at second position
        // second max at third position, second min at fourth
        // position and so on.
        static void Rearrange()
        {
            int n = arr.Length;
            // Auxiliary array to hold modified array
            int[] temp = new int[n];

            // Indexes of smallest and largest elements
            // from remaining array.
            int small = 0, large = n - 1;

            // To indicate whether we need to copy rmaining
            // largest or remaining smallest at next position
            bool flag = true;

            // Store result in temp[]
            for (int i = 0; i < n; i++)
            {
                if (flag)
                    temp[i] = arr[large--];
                else
                    temp[i] = arr[small++];

                flag = !flag;
            }

            // Copy temp[] to arr[]
            Array.Copy(temp, arr, n);
        }


        public static void Rearrange_SpaceOptimized()
        {
            int n = arr.Length;
            int largest = arr[n - 1] + 1;
            int min = 0, max = n - 1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    arr[i] = (arr[max] % largest) * largest + arr[i];
                    max--;
                }
                else
                {
                    arr[i] = (arr[min] % largest) * largest + arr[i];
                    min++;
                }
            }
            for (int i = 0; i < n; i++)
                arr[i] /= largest;
        }

    }
}
/*
 * https://www.geeksforgeeks.org/rearrange-array-maximum-minimum-form/
 */
