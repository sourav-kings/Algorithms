using System;

namespace Convert_Array_Into_ZigZag_Fashion
{
    class Program
    {
        static int[] arr = new int[] { 4, 3, 7, 8, 6, 2, 1 };

        static void Main(string[] args)
        {
            ZigZag();
            Array.ForEach(arr, x => Console.Write(x + " "));
        }

        // Method for zig-zag conversion of array
        static void ZigZag()
        {
            // Flag true indicates relation "<" is expected,
            // else ">" is expected.  The first expected relation
            // is "<"
            bool flag = true;

            int temp = 0;

            for (int i = 0; i <= arr.Length - 2; i++)
            {
                if (flag)  /* "<" relation expected */
                {
                    /* If we have a situation like A > B > C,
                       we get A > B < C by swapping B and C */
                    if (arr[i] > arr[i + 1])
                        Swap(i, i + 1);
                }
                else /* ">" relation expected */
                {
                    /* If we have a situation like A < B < C,
                       we get A < C > B by swapping B and C */
                    if (arr[i] < arr[i + 1])
                        Swap(i, i + 1);
                }
                flag = !flag; /* flip flag */
            }
        }

        static void Swap(int x, int y)
        {
            int temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
    }
}

/*
 * https://www.geeksforgeeks.org/convert-array-into-zig-zag-fashion/
 * 
 *  Time complexity: O(n)
    Auxiliary Space: O(1)

    We can convert in O(n) time using an Efficient Approach. 
    The idea is to use modified one pass of bubble sort. 
    Maintain a flag for representing which order(i.e. < or >) currently we need. 
    If the current two elements are not in that order then swap those elements otherwise not.
 */
