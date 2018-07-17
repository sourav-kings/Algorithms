using System;
using System.Collections.Generic;

namespace MajorityElement
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] a = { 1, 3, 3, 1, 2 };
            int[] a = { 2, 2, 2, 2, 5, 5, 2, 3, 3 };
            int size = a.Length;
            //GFG.PrintMajority(a, size);
            GFG.PrintMajority_HashMap(a);
        }
    }

    class GFG
    {
        /* Function to print Majority Element */
        internal static void PrintMajority(int[] a, int size)
        {
            /* Find the candidate for Majority*/
            int cand = FindCandidate(a, size);

            /* Print the candidate if it is Majority*/
            if (IsMajority(a, size, cand))
                Console.Write(" " + cand + " ");
            else
                Console.Write("No Majority Element");
        }

        /* Function to find the candidate for Majority */
        static int FindCandidate(int[] a, int size)
        {
            int maj_index = 0, count = 1;
            int i;
            for (i = 1; i < size; i++)
            {
                if (a[maj_index] == a[i])
                    count++;
                else
                    count--;

                if (count == 0)
                {
                    maj_index = i;
                    count = 1;
                }
            }
            return a[maj_index];
        }

        // Function to check if the candidate 
        // occurs more than n/2 times
        static bool IsMajority(int[] a, int size, int cand)
        {
            int i, count = 0;
            for (i = 0; i < size; i++)
            {
                if (a[i] == cand)
                    count++;
            }
            if (count > size / 2)
                return true;
            else
                return false;
        }

        internal static void PrintMajority_HashMap(int[] arr)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (map.ContainsKey(arr[i]))
                {
                    int count = map[arr[i]] + 1;
                    if (count > arr.Length / 2)
                    {
                        Console.WriteLine("Majority found :- " + arr[i]);
                        return;
                    }
                    else
                        map[arr[i]] = count;

                }
                else
                    map[arr[i]] = 1;
            }
            Console.WriteLine(" No Majority element");
        }
    }
}
