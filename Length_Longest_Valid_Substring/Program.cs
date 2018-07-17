using System;
using System.Collections.Generic;

namespace Length_Longest_Valid_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            String str = "((()()";
            Console.WriteLine(FindMaxLen(str));

            str = "()(()))))";
            Console.WriteLine(FindMaxLen(str));
        }


        // method to get length of the longest valid
        static int FindMaxLen(String str)
        {
            int n = str.Length;

            // Create a stack and push -1 as initial index to it.
            Stack<int> stk = new Stack<int>();
            stk.Push(-1);

            // Initialize result
            int result = 0;

            // Traverse all characters of given string
            for (int i = 0; i < n; i++)
            {
                // If opening bracket, push index of it
                if (str[i] == '(')
                    stk.Push(i);

                else // If closing bracket, i.e.,str[i] = ')'
                {
                    // Pop the previous opening bracket's index
                    stk.Pop();

                    // Check if this length formed with base of
                    // current valid substring is more than max 
                    // so far
                    if (stk.Count != 0)
                        result = Math.Max(result, i - stk.Peek());

                    // If stack is empty. push current index as 
                    // base for next valid substring (if any)
                    else stk.Push(i);
                }
            }

            return result;
        }
    }
}
