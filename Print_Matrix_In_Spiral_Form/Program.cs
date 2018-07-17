using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Matrix_In_Spiral_Form
{
    public class Program
    {
        
        public static void Main()
        {
            const int R = 3, C = 6;
            int[,] a = new int[R, C]
            { 
                {1,  2,  3,  4,  5,  6},
                {7,  8,  9,  10, 11, 12},
                {13, 14, 15, 16, 17, 18}
            };

            SpiralPrint(a, R, C);
        }

        static void SpiralPrint(int[,] a, int rowCount, int columnCount)
        {
            int i, r = 0, c = 0;

            /*  r           - starting row index
                rowCount    - ending row index
                c           - starting column index
                columnCount - ending column index
                i           - iterator
            */

            while (r < rowCount && c < columnCount)
            {
                /* Print the first row from the remaining rows */
                for (i = c; i < columnCount; ++i)
                    Console.Write(" " + a[r, i]);

                r++;

                /* Print the last column from the remaining columns */
                for (i = r; i < rowCount; ++i)
                    Console.Write(" " + a[i, columnCount - 1]);
                columnCount--;

                /* Print the last row from the remaining rows */
                if (r < rowCount)
                {
                    for (i = columnCount - 1; i >= c; --i)
                        Console.Write(" " + a[rowCount - 1, i]);
                    rowCount--;
                }

                /* Print the first column from the remaining columns */
                if (c < columnCount)
                {
                    for (i = rowCount - 1; i >= r; --i)
                        Console.Write(" " + a[i, c]);
                    c++;
                }
            }
        }
    }


    //http://www.geeksforgeeks.org/print-a-given-matrix-in-spiral-form/
}

//Average Difficulty : 2.9/5.0
//Based on 92 vote(s)
