using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_In_Rowcolumn_Wise_SortedMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mat = new int[4,4]{ {10, 20, 30, 40},
                    {15, 25, 35, 45},
                    {27, 29, 37, 48},
                    {32, 33, 39, 50},
                  };
            search(mat, 4, 29);
        }

        /* Searches the element x in mat[][]. If the element is found, 
    then prints its position and returns true, otherwise prints 
    "not found" and returns false */
        static int search(int[,] mat, int n, int x)
        {
            int i = 0, j = n - 1;  //set indexes for top right element
            while (i < n && j >= 0)
            {
                if (mat[i,j] == x)
                {
                    Console.WriteLine("Found at " + i + ", " + j);
                    return 1;
                }
                if (mat[i,j] > x)
                    j--;
                else //  if mat[i][j] < x
                    i++;
            }

            Console.WriteLine("Element not found");
            return 0;  // if ( i==n || j== -1 )
        }
    }
}


/*
 http://www.geeksforgeeks.org/search-in-row-wise-and-column-wise-sorted-matrix/

     Average Difficulty : 2.6/5.0
Based on 90 vote(s)
     */
