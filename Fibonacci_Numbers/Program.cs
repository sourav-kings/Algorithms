using System;

namespace Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1;
            Console.WriteLine(Fib(n));
            Console.WriteLine(Fib_DP(n));
            Console.WriteLine(Fib_DP_SpaceOptimized(n));
            Console.WriteLine(Fib_Faster(n)); 
        }

        static int Fib(int n)
        {
            if (n <= 1)
                return n;
            else
                return Fib(n - 1) + Fib(n - 2); 
        }

        static int Fib_DP(int n)
        {
            int[] f = new int[n + 2];
            int i;

            f[0] = 0;
            f[1] = 1;

            for (i = 2; i <= n; i++)
            {
                f[i] = f[i - 1] + f[i - 2];
            }

            return f[n];
        }

        static int Fib_DP_SpaceOptimized(int n)
        {
            int prev1 = 0, prev2 = 1, result = 0;

            // To return the first Fibonacci number 
            if (n == 0) return prev1;
            if (n == 1) return prev2;

            for (int i = 2; i <= n; i++)
            {
                result = prev1 + prev2;
                prev1 = prev2;
                prev2 = result;
            }

            return result;
        }



        static int Fib_Faster(int n)
        {
            int[,] F = new int[,] { { 1, 1 }, { 1, 0 } };
            if (n == 0)
                return 0;
            Power(F, n - 1);

            return F[0, 0];
        }
        static void Power(int[,] F, int n)
        {
            if (n == 0 || n == 1)
                return;
            int[,] M = new int[,] { { 1, 1 }, { 1, 0 } };

            Power(F, n / 2);
            Multiply(F, F);

            if (n % 2 != 0)
                Multiply(F, M);
        }
        static void Multiply(int[,] F, int[,] M)
        {
            int x = F[0, 0] * M[0, 0] + F[0, 1] * M[1, 0];
            int y = F[0, 0] * M[0, 1] + F[0, 1] * M[1, 1];
            int z = F[1, 0] * M[0, 0] + F[1, 1] * M[1, 0];
            int w = F[1, 0] * M[0, 1] + F[1, 1] * M[1, 1];

            F[0, 0] = x;
            F[0, 1] = y;
            F[1, 0] = z;
            F[1, 1] = w;
        }


    }

}
/*
 * Given a number n, print n-th Fibonacci Number.

    Input  : n = 2
    Output : 1

    Input  : n = 9
    Output : 34


    Method 1 ( Use recursion ) 
            Time complexity : O(2^n).
    Method 2 ( Use Dynamic Programming )
            Time complexity : O(n).
    Method 3 ( Space Optimized Method 2 )
            We can optimize the space used in method 2 by storing the previous two numbers 
            only because that is all we need to get the next Fibonacci number in series.
    Method 4 (Binets Method) or (Fibonacci Formula)
             Time complexity : O(logN).
             


 */
