using System;
using System.Collections.Generic;

namespace Sort_Stack_UsingRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> s = new Stack<int>();
            s.Push(30);
            s.Push(-5);
            s.Push(18);
            s.Push(14);
            s.Push(-3);

            Console.WriteLine("Stack elements before sorting: ");
            PrintStack(s);

            SortStack(s);

            Console.WriteLine(" \n\nStack elements after sorting:");
            PrintStack(s)
        }

        // Recursive Method to insert an item x in sorted way
        static void SortedInsert(Stack<int> s, int x)
        {
            // Base case: Either stack is empty or newly inserted
            // item is greater than top (more than all existing)
            if (s.Count == 0 || x > s.Peek())
            {
                s.Push(x);
                return;
            }

            // If top is greater, remove the top item and recur
            int temp = s.Pop();
            sortedInsert(s, x);

            // Put back the top item removed earlier
            s.Push(temp);
        }

        // Method to sort stack
        static void SortStack(Stack<int> s)
        {
            // If stack is not empty
            if (s.Count != 0)
            {
                // Remove the top item
                int x = s.Pop();

                // Sort remaining stack
                SortStack(s);

                // Push the top item back in sorted stack
                SortedInsert(s, x);
            }
        }

        // Utility Method to print contents of stack
        static void PrintStack(Stack<int> s)
        {
            for(int i = s.Count; i >=0; i--)
                Console.Write(s[i] + " ");
            //IEnumerator<int> lt = s.GetEnumerator();

            //// forwarding
            //while (lt.MoveNext()) ;

            //// printing from top to bottom
            //while (lt...HasPrevious())
            //    Console.Write(lt.previous() + " ");
        }
    }
}


/*
 * https://www.geeksforgeeks.org/sort-a-stack-using-recursion/
 */
