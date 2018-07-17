using System;

namespace Minimum_Distance_Between_Two_Nos
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {3, 5, 4, 2, 6,
              5, 6, 6, 5, 4, 8, 3};
            int n = arr.Length;
            int x = 3;
            int y = 6;

            Console.WriteLine("Minimum "
                   + "distance between "
             + x + " and " + y + " is "
               + MinDist_Faster(arr, n, x, y));
        }

        static int MinDist(int[] arr, int n,
                               int x, int y)
        {
            int i, j;
            int min_dist = int.MaxValue;
            for (i = 0; i < n; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    if ((x == arr[i] &&
                         y == arr[j] ||
                         y == arr[i] &&
                           x == arr[j])
                        && min_dist >
                       Math.Abs(i - j))

                        min_dist =
                        Math.Abs(i - j);
                }
            }
            return min_dist;
        }



        static int MinDist_Faster(int[] arr, int n,
                       int x, int y)
        {
            int i = 0;
            int min_dist = int.MaxValue;
            int prev = 0;

            // Find the first occurence of any
            // of the two numbers (x or y)
            // and store the index of this
            // occurence in prev
            for (i = 0; i < n; i++)
            {
                if (arr[i] == x || arr[i] == y)
                {
                    prev = i;
                    break;
                }
            }

            // Traverse after the 
            // first occurence
            for (; i < n; i++)
            {
                if (arr[i] == x || arr[i] == y)
                {
                    // If the current element matches 
                    // with any of the two then
                    // check if current element and 
                    // prev element are different
                    // Also check if this value is 
                    // smaller than minimum distance 
                    // so far
                    if (arr[prev] != arr[i] &&
                        (i - prev) < min_dist)
                    {
                        min_dist = i - prev;
                        prev = i;
                    }
                    else
                        prev = i;
                }
            }

            return min_dist;
        }
    }
}


/*
 * https://www.geeksforgeeks.org/find-the-minimum-distance-between-two-numbers/
 */
