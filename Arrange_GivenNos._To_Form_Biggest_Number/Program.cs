using System;
using System.Collections.Generic;

namespace Arrange_GivenNos._To_Form_Biggest_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> arr;
            arr = new List<String>();

            //output should be 6054854654
            arr.Add("54");
            arr.Add("546");
            arr.Add("548");
            arr.Add("60");
            GFG.PrintLargest(arr);

            // output should be 777776
            /* arr.add("7");
            arr.add("776");
            arr.add("7");
            arr.add("7");
            */

            //output should be 998764543431
            /*arr.add("1");
            arr.add("34");
            arr.add("3");
            arr.add("98");
            arr.add("9");
            arr.add("76");
            arr.add("45");
            arr.add("4");
            */
        }
    }

    class GFG
    {

        // The main function that prints the 
        // arrangement with the largest value.
        // The function accepts a vector of strings    
        internal static void PrintLargest(List<String> arr)
        {
            arr.Sort((X, Y) =>
            {
                // first append Y at the end of X
                String XY = X + Y;

                // then append X at the end of Y
                String YX = Y + X;

                // Now see which of the two formed numbers 
                // is greater
                return XY.CompareTo(YX) > 0 ? -1 : 1;
            });

            arr.ForEach(x => Console.Write(x));
        }
    }
}
/*
 * https://www.geeksforgeeks.org/given-an-array-of-numbers-arrange-the-numbers-to-form-the-biggest-number/
 * 
 * 
 * A simple solution that comes to our mind is to sort all numbers in descending order, 
 * but simply sorting doesn’t work. For example, 548 is greater than 60, 
 * but in output 60 comes before 548. As a second example, 98 is greater than 9, 
 * but 9 comes before 98 in output.

    So how do we go about it? The idea is to use any comparison based sorting algorithm. 
    In the used sorting algorithm, instead of using the default comparison, 
    write a comparison function myCompare() and use it to sort numbers. 
    Given two numbers X and Y, how should myCompare() decide which number to put first – 
    we compare two numbers XY (Y appended at the end of X) and YX (X appended at the end of Y). 
    If XY is larger, then X should come before Y in output, else Y should come before. 
    For example, let X and Y be 542 and 60. To compare X and Y, we compare 54260 and 60542. 
    Since 60542 is greater than 54260, we put Y first.
 */
