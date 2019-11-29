using System;

namespace Smallest_And_SecondSmallest_Element_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 12, 13, 1, 10, 34, 1 };
            Print2Smallest(arr);
        }

        /* Function to print first smallest 
            and second smallest elements */
        static void Print2Smallest(int[] arr)
        {
            int first, second, arr_size = arr.Length;

            /* There should be atleast two elements */
            if (arr_size < 2)
            {
                Console.Write(" Invalid Input ");
                return;
            }

            first = second = int.MaxValue;

            for (int i = 0; i < arr_size; i++)
            {
                /* If current element is smaller than first
                then update both first and second */
                if (arr[i] < first)
                {
                    second = first;
                    first = arr[i];
                }

                /* If arr[i] is in between first and second
                then update second */
                else if (arr[i] < second && arr[i] != first)
                    second = arr[i];
            }
            if (second == int.MaxValue)
                Console.Write("There is no second" +
                                "smallest element");
            else
                Console.Write("The smallest element is " +
                                first + " \nsecond Smallest" +
                                " element is " + second + "\n");
        }
    }
}
/*
 * A Simple Solution is to sort the array in increasing order. 
 * The first two elements in sorted array would be two smallest elements. 
 * Time complexity of this solution is O(n Log n).
 * 
 * 
 * A Better Solution is to scan the array twice. 
 * In first traversal find the minimum element. 
 * Let this element be x. In second traversal, 
 * find the smallest element greater than x. 
 * Time complexity of this solution is O(n).
 * 
 * 
 * 
 * An Efficient Solution can find the minimum two elements in one traversal. 
 * The same approach can be used to find the largest and second largest elements in an array.
 * 1) Initialize both first and second smallest as INT_MAX
       first = second = INT_MAX
    2) Loop through all the elements.
       a) If the current element is smaller than first, then update first 
           and second. 
       b) Else if the current element is smaller than second then update 
        second
 */
