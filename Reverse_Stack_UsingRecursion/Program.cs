using System;
using System.Collections.Generic;

namespace Reverse_Stack_UsingRecursion
{
    class Program
    {

        // using Stack class for
        // stack implementation
        static Stack<char> st = new Stack<char>();

        static void Main(string[] args)
        {
            // push elements into
            // the stack
            st.Push('1');
            st.Push('2');
            st.Push('3');
            st.Push('4');

            Console.WriteLine("Original Stack");

            Console.WriteLine(st);

            // function to reverse 
            // the stack
            Reverse();

            Console.WriteLine("Reversed Stack");

            Console.WriteLine(st);
        }


        // Below is a recursive function 
        // that inserts an element
        // at the bottom of a stack.
        static void Insert_at_bottom(char x)
        {

            if (st.Count == 0)
                st.Push(x);

            else
            {

                // All items are held in Function
                // Call Stack until we reach end
                // of the stack. When the stack becomes
                // empty, the st.size() becomes 0, the
                // above if part is executed and 
                // the item is inserted at the bottom
                char a = st.Peek();
                st.Pop();
                Insert_at_bottom(x);

                // push allthe items held 
                // in Function Call Stack
                // once the item is inserted 
                // at the bottom
                st.Push(a);
            }
        }

        // Below is the function that 
        // reverses the given stack using
        // insert_at_bottom()
        static void Reverse()
        {
            if (st.Count > 0)
            {

                // Hold all items in Function
                // Call Stack until we
                // reach end of the stack 
                char x = st.Peek();
                st.Pop();
                Reverse();

                // Insert all the items held 
                // in Function Call Stack
                // one by one from the bottom
                // to top. Every item is
                // inserted at the bottom 
                Insert_at_bottom(x);
            }
        }
    }
}


/*
 * https://www.geeksforgeeks.org/reverse-a-stack-using-recursion/
 */
