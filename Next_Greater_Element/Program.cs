using System;
using System.Collections;
using System.Collections.Generic;

namespace Next_Greater_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 11, 13, 21, 3 };
            int[] arr = { 13, 7, 6, 12 };
            int n = arr.Length;

            //printNGE(arr, n);
            printNGE_Faster(arr, n);
        }

        /* prints element and NGE pair for 
all elements of arr[] of size n */
        static void printNGE(int[] arr, int n)
        {
            int next, i, j;
            for (i = 0; i < n; i++)
            {
                next = -1;
                for (j = i + 1; j < n; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        next = arr[j];
                        break;
                    }
                }
                Console.WriteLine(arr[i] + " -- " + next);
            }
        }



        /* prints element and NGE pair for 
       all elements of arr[] of size n */
        static void printNGE_Faster(int[] arr, int n)
        {
            int i = 0;
            Stack<int> s = new Stack<int>();
            //s.Push(1);
            int element, next;

            /* push the first element to stack */
            s.Push(arr[0]);

            // iterate for rest of the elements
            for (i = 1; i < n; i++)
            {
                next = arr[i];

                if (s.Count != 0)
                {

                    // if stack is not empty, then 
                    // pop an element from stack
                    element = s.Pop();

                    /* If the popped element is smaller than 
                       next, then a) print the pair b) keep 
                       popping while elements are smaller and 
                       stack is not empty */
                    while (element < next)
                    {
                        Console.WriteLine(element + " --> " + next);
                        if (s.Count == 0)
                            break;
                        element = s.Pop();
                    }

                    /* If element is greater than next, then 
                       push the element back */
                    if (element > next)
                        s.Push(element);
                }

                /* push next to stack so that we can find next
                   greater for it */
                s.Push(next);
            }

            /* After iterating over the loop, the remaining 
               elements in stack do not have the next greater 
               element, so print -1 for them */
            while (s.Count != 0)
            {
                element = s.Pop();
                next = -1;
                Console.WriteLine(element + " -- " + next);
            }
        }
    }
}

/*
 * https://www.geeksforgeeks.org/next-greater-element/
 * 
 * Methods:- Recursive and Stack 
 */

