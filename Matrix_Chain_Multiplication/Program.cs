using System;

namespace Matrix_Chain_Multiplication
{
    class Program
    {
        static int[] arr;
        static void Main(string[] args)
        {
            arr = new int[] { 1, 2, 3, 4, 3 };
            int n = arr.Length;

            Console.WriteLine("Minimum number of multiplications is "
                              + MatrixChainOrder(1, n - 1));

            Console.WriteLine("Minimum number of multiplications is "
                  + MatrixChainOrderDP(n));
        }

        // Matrix Ai has dimension p[i-1] x p[i]
        // for i = 1..n
        static int MatrixChainOrder(int s, int e)
        {

            if (s == e)
                return 0;

            int min = int.MaxValue;

            // place parenthesis at different places 
            // between first and last matrix, recursively 
            // calculate count of multiplications for each
            // parenthesis placement and return the 
            // minimum count
            for (int i = s; i < e; i++)
            {
                int count = MatrixChainOrder(s, i) +
                MatrixChainOrder(i + 1, e) + arr[s - 1]
                                           * arr[i] * arr[e];

                if (count < min)
                    min = count;
            }

            // Return minimum count
            return min;
        }



        // Matrix Ai has dimension p[i-1] x p[i] 
        // for i = 1..n
        static int MatrixChainOrderDP(int n)
        {

            /* For simplicity of the program, one 
            extra row and one extra column are 
            allocated in m[][]. 0th row and 0th
            column of m[][] are not used */
            int[,] m = new int[n, n];

            int i, j, k, L, q;

            /* m[i,j] = Minimum number of scalar 
            multiplications needed
            to compute the matrix A[i]A[i+1]...A[j]
            = A[i..j] where dimension of A[i] is 
            p[i-1] x p[i] */

            // cost is zero when multiplying 
            // one matrix.
            for (i = 1; i < n; i++)
                m[i, i] = 0;

            // L is chain length.
            for (L = 2; L < n; L++)
            {
                for (i = 1; i < n - L + 1; i++)
                {
                    j = i + L - 1;
                    if (j == n) continue;
                    m[i, j] = int.MaxValue;
                    for (k = i; k <= j - 1; k++)
                    {
                        // q = cost/scalar multiplications
                        q = m[i, k] + m[k + 1, j] +
                                         arr[i - 1] * arr[k] * arr[j];
                        if (q < m[i, j])
                            m[i, j] = q;
                    }
                }
            }

            return m[1, n - 1];
        }
    }
}


/*
 * https://www.geeksforgeeks.org/?p=15553
 * Recursive n DP
 * 
 * Matrix multiplication is NOT commutative.
 * i.e. AB ≠ BA
 * 
 * It can have the same result (such as when one matrix is the Identity Matrix) but not usually.
 * https://www.mathsisfun.com/algebra/matrix-multiplying.html
 */
