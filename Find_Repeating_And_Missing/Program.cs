using System;

namespace Find_Repeating_And_Missing
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 7, 3, 4, 5, 5, 6, 2 };
            int n = arr.Length;
            printTwoElements(arr, n);
        }
    }
}
/*
 * https://www.geeksforgeeks.org/find-a-repeating-and-a-missing-number/
 * 
 * Average Difficulty : 3/5.0
    Based on 118 vote(s)
 * 
 * STEPS for O(n) Time Complexity
 * 
 * Method 3 (Use elements as Index and mark the visited places)
    
    Traverse the array, and use absolute value of each element as index and 
    make the value at this index as negative to mark it visited. 
    If something is already marked negative then this is the repeating element. 
    To find missing, traverse the array again and look for a positive value.
 */
