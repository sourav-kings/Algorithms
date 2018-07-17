using System;
using System.Collections.Generic;

namespace Stock_Span_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] price = { 10, 4, 5, 90, 120, 80 };
            int n = price.Length;
            int[] S = new int[n];

            // Fill the span values in array S[]
            CalculateSpan(price, n, S);
            CalculateSpan_Faster(price, n, S);


            // print the calculated span values
            PrintArray(S);
        }

        //  method to calculate stock span values
        static void CalculateSpan(int[] price, int n, int[] S)
        {
            // Span value of first day is always 1
            S[0] = 1;

            // Calculate span value of remaining days by linearly checking
            // previous days
            for (int i = 1; i < n; i++)
            {
                S[i] = 1; // Initialize span value

                // Traverse left while the next element on left is smaller
                // than price[i]
                for (int j = i - 1; (j >= 0) && (price[i] >= price[j]); j--)
                    S[i]++;
            }
        }

        // A utility function to print elements of array
        static void PrintArray(int[] arr)
        {
           Array.ForEach(arr, x => Console.Write(x + " "));
        }


        // a linear time solution for stock span problem
        // A stack based efficient method to calculate stock span values
        static void CalculateSpan_Faster(int[] price, int n, int[] S)
        {
            // Create a stack and push index of first element to it
            Stack<int> st = new Stack<int>();
            st.Push(0);

            // Span value of first element is always 1
            S[0] = 1;

            // Calculate span values for rest of the elements
            for (int i = 1; i < n; i++)
            {
                // Pop elements from stack while stack is not empty and top of
                // stack is smaller than price[i]
                while (st.Count != 0 && price[st.Peek()] <= price[i])
                    st.Pop();

                // If stack becomes empty, then price[i] is greater than all elements
                // on left of it, i.e., price[0], price[1],..price[i-1]. Else price[i]
                // is greater than elements after top of stack
                S[i] = (st.Count == 0) ? (i + 1) : (i - st.Peek());

                // Push this element to stack
                st.Push(i);
            }
        }
    }
}
/*
 * https://www.geeksforgeeks.org/the-stock-span-problem/
 */
