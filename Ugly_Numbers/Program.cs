using System;

namespace Ugly_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //int no = GetNthUglyNo(150);

            int no = GetNthUglyNo_DP(150);

            Console.WriteLine("150th ugly"
                      + " no. is " + no);
        }

        /* Function to get the nth ugly
number*/
        static int GetNthUglyNo(int n)
        {
            int i = 1;

            // ugly number count 
            int count = 1;

            // check for all integers
            // until count becomes n 
            while (n > count)
            {
                i++;
                if (IsUgly(i) == 1)
                    count++;
            }
            return i;
        }


        /* Function to check if a number 
        is ugly or not */
        static int IsUgly(int no)
        {
            no = MaxDivide(no, 2);
            no = MaxDivide(no, 3);
            no = MaxDivide(no, 5);

            return (no == 1) ? 1 : 0;
        }

        /*This function divides a by 
greatest divisible power of b*/
        static int MaxDivide(int a, int b)
        {
            while (a % b == 0)
                a = a / b;
            return a;
        }



        /* Function to get the nth ugly number*/
        static int GetNthUglyNo_DP(int n)
        {
            int[] ugly = new int[n];  // To store ugly numbers
            int i2 = 0, i3 = 0, i5 = 0;
            int next_multiple_of_2 = 2;
            int next_multiple_of_3 = 3;
            int next_multiple_of_5 = 5;
            int next_ugly_no = 1;

            ugly[0] = 1;

            for (int i = 1; i < n; i++)
            {
                next_ugly_no = Math.Min(next_multiple_of_2,
                                      Math.Min(next_multiple_of_3,
                                            next_multiple_of_5));

                ugly[i] = next_ugly_no;
                if (next_ugly_no == next_multiple_of_2)
                {
                    i2 = i2 + 1;
                    next_multiple_of_2 = ugly[i2] * 2;
                }
                if (next_ugly_no == next_multiple_of_3)
                {
                    i3 = i3 + 1;
                    next_multiple_of_3 = ugly[i3] * 3;
                }
                if (next_ugly_no == next_multiple_of_5)
                {
                    i5 = i5 + 1;
                    next_multiple_of_5 = ugly[i5] * 5;
                }
            } /*End of for loop (i=1; i<n; i++) */
            return next_ugly_no;
        }

    }
}

/*
 * Ugly numbers are numbers whose only prime factors are 2, 3 or 5. 
 * The sequence 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, … shows the first 11 ugly numbers. 
 * By convention, 1 is included.
 * Given a number n, the task is to find n’th Ugly number.
 * 
 * 
 * To check if a number is ugly, 
 * divide the number by greatest divisible powers of 2, 3 and 5, 
 * if the number becomes 1 then it is an ugly number otherwise not.
 * https://www.geeksforgeeks.org/ugly-numbers/
 */
