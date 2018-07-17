using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Overlapping_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            Interval[] arr = new Interval[] 
            //{ new Interval(6,8), new Interval(1, 9), new Interval(2, 4), new Interval(4, 7) };
            //{ new Interval(1,3), new Interval(2,4), new Interval(5,7), new Interval(6,8) };
            //{ new Interval(1,20), new Interval(4,6), new Interval(5, 7) , new Interval(29,41) };
            {new Interval(9, 11), new Interval(3, 7), new Interval(2, 4), new Interval(5, 7), new Interval(8, 10) };
            //{ new Interval(9, 11), new Interval(3, 12) };
            //{ new Interval(9, 11), new Interval(3, 7) };
            //{ new Interval(3, 7), new Interval(9, 11) };


            int n = arr.Length;
            Console.WriteLine("\n \n \n ........The Stack Method Solution.............\n ");
            mergeIntervals(arr, n);

            Console.WriteLine("\n \n \n ........The Naive Method Solution.............\n ");
            Interval[] arr2 = arr;
            mergeIntervals_WithoutStack(arr2, n); // Does not work for last test case.


        }



        // The main function that takes a set of intervals, merges
        // overlapping intervals and prints the result
        static void mergeIntervals(Interval[] arr, int n)
        {
            // Test if the given set has at least one interval
            if (n <= 0)
                return;
           
            // Create an empty stack of intervals
            Stack<Interval> s = new Stack<Interval>();

            // sort the intervals in increasing order of their start time
            //sort(arr, arr + n, compareInterval);
            arr = arr.OrderBy(x => x.start).ToArray();

            // push the first interval to stack
            s.Push(arr[0]);

            // Start from the next interval and merge if necessary
            for (int i = 1; i < n; i++)
            {
                // get interval from stack top
                Interval top = s.First();

                // if current interval is not overlapping with stack top,
                // push it to the stack
                if (top.end < arr[i].start)
                    s.Push(arr[i]);

                // Otherwise update the ending time of top if ending of current
                // interval is more
                else
                {
                    top.end = Math.Max(top.end, arr[i].end);
                    s.Pop();
                    s.Push(top);
                }
            }

            // Print contents of stack
            Console.Write("\n The Merged Intervals are: \n");
            while (s.Any())
            {
                Interval t = s.First();
                Console.Write("[" + t.start + "," + t.end + "] ");
                s.Pop();
            }
            return;
        }


        /*
         *  Start from the first interval and compare it with all other intervals for overlapping, 
         *  if it overlaps with any other interval, then remove the other interval from list and merge the other into the first interval. 
         *  Repeat the same steps for remaining intervals after first. This approach cannot be implemented in better than O(n^2) time.
         */
        private static void mergeIntervals_WithoutStack(Interval[] arr, int n)
        {
            arr = arr.OrderBy(x => x.start).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (
                    i + 1 < arr.Length
                    && arr[i] != null && arr[i + 1] != null
                    && arr[i + 1].start <= arr[i].end 
                    )
                {
                    arr[i + 1].start = arr[i].start;

                    arr[i + 1].end = Math.Max(arr[i].end, arr[i + 1].end);

                    arr[i] = null;
                }
            }

            foreach (Interval interval in arr)
            {
                if (interval != null)
                {
                    Console.WriteLine(string.Format("[ {0} , {1} ]",
                    interval.start, interval.end));
                }
            }
        }

        // Compares two intervals according to their staring time.
        // This is needed for sorting the intervals using library
        // function std::sort(). See http://goo.gl/iGspV
        //static bool compareInterval(Interval i1, Interval i2)
        //{
        //    return (i1.start < i2.start);
        //}
    }

    // An interval has start time and end time
    class Interval
    {
        public int start, end;

        public Interval(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    };
}

//http://www.geeksforgeeks.org/merging-intervals/

//http://code.geeksforgeeks.org/jDuJlW

//Average Difficulty : 3.3/5.0
//Based on 74 vote(s)


/*
 WHAT I HAVE UNDERSTOOD TILL NOW
 30.06.2017

    Understood the naive method. Looks like the naive method mentioned here has a time complexity of O(n) rahter than O(n*n).
    In naive we are updating next item if any overlap. 
    In stack, we are updating current item in stack if any overlap is there.
    Stack method also in the same line of the naive mentioned here.

 Stack Method--
 1. Sort all intervals based on their start.
 2. Push first item to a stack.
 3. Iterate through all starting from second.
 4. get top of stack and store in a temp.
 5. compare the current item with temp to check if overlap is there.
 6. If yes, set temp's end as the max of current and temp end. 
        Pop the current top in stack and push this updated temp in stack.
 7. If no, push the current item into the stack.
 8. Repeat. 
 */
