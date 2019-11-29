using System;

namespace Implement_Two_Stacks_In_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            TwoStacks ts = new TwoStacks(5);
            ts.Push1(5);
            ts.Push2(10);
            ts.Push2(15);
            ts.Push1(11);
            ts.Push2(7);
            Console.WriteLine("Popped element from" +
                               " stack1 is " + ts.Pop1());
            ts.Push2(40);
            Console.WriteLine("Popped element from" +
                             " stack2 is " + ts.Pop2());
        }
    }


    // Java program to implement two stacks in a
    // single array
    class TwoStacks
    {
        int size;
        int top1, top2;
        int[] arr;

        // Constructor
        internal TwoStacks(int n)
        {
            arr = new int[n];
            size = n;
            top1 = -1;
            top2 = size;
        }

        // Method to push an element x to stack1
        internal void Push1(int x)
        {
            // There is at least one empty space for
            // new element
            if (top1 < top2 - 1)
            {
                top1++;
                arr[top1] = x;
            }
            else
            {
                Console.WriteLine("Stack Overflow");
            }
        }

        // Method to push an element x to stack2
        internal void Push2(int x)
        {
            // There is at least one empty space for
            // new element
            if (top1 < top2 - 1)
            {
                top2--;
                arr[top2] = x;
            }
            else
            {
                Console.WriteLine("Stack Overflow");
            }
        }

        // Method to pop an element from first stack
        internal int Pop1()
        {
            if (top1 >= 0)
            {
                int x = arr[top1];
                top1--;
                return x;
            }
            else
            {
                Console.WriteLine("Stack Underflow");
            }
            return 0;
        }

        // Method to pop an element from second stack
        internal int Pop2()
        {
            if (top2 < size)
            {
                int x = arr[top2];
                top2++;
                return x;
            }
            else
            {
                Console.WriteLine("Stack Underflow");

            }
            return 0;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/implement-two-stacks-in-an-array/
 * 
 * Method 1 (Divide the space in two halves)
 * Method 2 (A space efficient implementation)
 *      Time complexity of all 4 operations of twoStack is O(1).
 */
