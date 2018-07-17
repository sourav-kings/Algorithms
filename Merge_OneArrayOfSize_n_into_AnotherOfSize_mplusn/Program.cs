using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_OneArrayOfSize_n_into_AnotherOfSize_mplusn
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Initialize arrays */
            int[] mPlusN = { 2, 8, -1, -1, -1, 13, -1, 15, 20 };
            int[] N = { 5, 7, 9, 25 };
            int n = N.Length;
            int m = mPlusN.Length - n;

            /*Move the m elements at the end of mPlusN*/
            moveToEnd(mPlusN, m + n);

            /*Merge N[] into mPlusN[] */
            merge(mPlusN, N, m, n);

            /* Print the resultant mPlusN */
            printArray(mPlusN, m + n);
        }

        /* Function to move m elements at the end of array mPlusN[] */
        static void moveToEnd(int[] mPlusN, int size)
        {
            int i, j = size - 1;
            for (i = size - 1; i >= 0; i--)
            {
                if (mPlusN[i] != -1)
                {
                    mPlusN[j] = mPlusN[i];
                    j--;
                }
            }
        }

        /* Merges array N[] of size n into array mPlusN[]
           of size m+n*/
        static void merge(int[] mPlusN, int[] N, int m, int n)
        {
            int i = n;

            /* Current index of i/p part of mPlusN[]*/
            int k = 0;

            /* Current index of N[]*/
            int j = 0;

            /* Current index of of output mPlusN[]*/
            while (k < (m + n))
            {
                /* Take an element from mPlusN[] if
                a) value of the picked element is smaller and we have
                    not reached end of it
                b) We have reached end of N[] */
                if ((i < (m + n) && mPlusN[i] <= N[j]) || (j == n))
                {
                    mPlusN[k] = mPlusN[i];
                    k++;
                    i++;
                }
                else // Otherwise take element from N[]
                {
                    mPlusN[k] = N[j];
                    k++;
                    j++;
                }
            }
        }

        /* Utility that prints out an array on a line */
        static void printArray(int[] arr, int size)
        {
            int i;
            for (i = 0; i < size; i++)
                Console.Write(arr[i] + " ");

            Console.WriteLine("");
        }
    }
}

//http://www.geeksforgeeks.org/merge-one-array-of-size-n-into-another-one-of-size-mn/

//Average Difficulty : 2.4/5.0
//Based on 144 vote(s)
