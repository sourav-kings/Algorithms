using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSize_SquareSubMatrix_With_All_1s
{
    class Program
    {
        const int R = 6;
        const int C = 5;
        static void Main(string[] args)
        {
            int[,] M = new int[R, C]{
                {0, 1, 1, 0, 1},
                {1, 1, 0, 1, 0},
                {0, 1, 1, 1, 0},
                {1, 1, 1, 1, 0},
                {1, 1, 1, 1, 0},
                {0, 0, 0, 0, 0}
            };


            PrintMaxSubSquare(M);
        }

        static void PrintMaxSubSquare(int[,] M)
        {
            int i, j;
            int[,] S = new int[R, C];
            int max_of_s, max_i, max_j;

            /* Set first column of S[,]*/
            for (i = 0; i < R; i++)
                S[i, 0] = M[i, 0];

            /* Set first row of S[,]*/
            for (j = 0; j < C; j++)
                S[0, j] = M[0, j];

            /* Construct other entries of S[,]*/
            for (i = 1; i < R; i++)
            {
                for (j = 1; j < C; j++)
                {
                    if (M[i, j] == 1)
                        S[i, j] = Min(S[i, j - 1], (S[i - 1, j]), S[i - 1, j - 1]) + 1;
                    else
                        S[i, j] = 0;
                }
            }

            /* Find the maximum entry, and indexes of maximum entry 
               in S[,] */
            max_of_s = S[0, 0]; max_i = 0; max_j = 0;
            for (i = 0; i < R; i++)
            {
                for (j = 0; j < C; j++)
                {
                    if (max_of_s < S[i, j])
                    {
                        max_of_s = S[i, j];
                        max_i = i;
                        max_j = j;
                    }
                }
            }


            Console.Write("\n Maximum size sub-matrix is: \n");
            for (i = max_i; i > max_i - max_of_s; i--)
            {
                for (j = max_j; j > max_j - max_of_s; j--)
                {
                    Console.Write(M[i, j]);
                }
                Console.Write("\n");
            }
        }
        /* UTILITY FUNCTIONS */
        /* Function to get minimum of three values */
        static int Min(int a, int b, int c)
        {
            int m = a;
            if (m > b)
                m = b;
            if (m > c)
                m = c;
            return m;
        }
    }
}

//http://www.geeksforgeeks.org/maximum-size-sub-matrix-with-all-1s-in-a-binary-matrix/

//Average Difficulty : 3.2/5.0
//Based on 126 vote(s)