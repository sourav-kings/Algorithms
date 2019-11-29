using System;

namespace Equilibrium_Index_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { -7, 1, 5, 2, -4, 3, 0 };
            int arr_size = arr.Length;

            Console.Write(equilibrium(arr, arr_size))
        }


        static int equilibrium(int[] arr, int n)
        {
            int i, j;
            int leftsum, rightsum;

            /* Check for indexes one by 
             one until an equilibrium
            index is found */
            for (i = 0; i < n; ++i)
            {

                // initialize left sum
                // for current index i
                leftsum = 0;

                // initialize right sum
                // for current index i
                rightsum = 0;

                /* get left sum */
                for (j = 0; j < i; j++)
                    leftsum += arr[j];

                /* get right sum */
                for (j = i + 1; j < n; j++)
                    rightsum += arr[j];

                /* if leftsum and rightsum are
                 same, then we are done */
                if (leftsum == rightsum)
                    return i;
            }

            /* return -1 if no equilibrium 
             index is found */
            return -1;
        }



        static int equilibrium_faster(int[] arr, int n)
        {
            // initialize sum of whole array
            int sum = 0;

            // initialize leftsum
            int leftsum = 0;

            /* Find sum of the whole array */
            for (int i = 0; i < n; ++i)
                sum += arr[i];

            for (int i = 0; i < n; ++i)
            {

                // sum is now right sum
                // for index i
                sum -= arr[i];

                if (leftsum == sum)
                    return i;

                leftsum += arr[i];
            }

            /* If no equilibrium index found, 
            then return 0 */
            return -1;
        }
    }
}
