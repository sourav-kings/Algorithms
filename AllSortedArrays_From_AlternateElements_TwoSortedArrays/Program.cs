using System;

namespace AllSortedArrays_From_AlternateElements_TwoSortedArrays
{
    class Program
    {
        static int[] A, B, C;
        static int m, n;
        static void Main(string[] args)
        {
            A = new int[]{ 10, 15, 25 };
            B = new int[]{ 5, 20, 30 };
            
            n = A.Length;
            m = B.Length;
            Generate();
        }

        /* Wrapper function */
        static void Generate()
        {
            /* output array */
            C = new int[m + n];
            GenerateUtil(0, 0, 0, true);
        }


        /* Function to generates and prints all sorted arrays from alternate
           elements of 'A[i..m-1]' and 'B[j..n-1]'
           If 'flag' is true, then current element is to be included from A 
           otherwise from B.
           'len' is the index in output array C[]. We print output array  
           each time before including a character from A only if length of 
           output array is greater than 0. We try than all possible 
           combinations 
        */
        static void GenerateUtil(int pointerA, int pointerB, int len, bool flag)
        {
            if (flag) // Include valid element from A
            {
                // Print output if there is at least one 'B' in output array 'C'
                if (len != 0)
                    PrintArr(C, len + 1);

                // Recur for all elements of A after current index
                for (int i = pointerA; i < m; i++)
                {
                    /* this block only for first element in output */
                    if (len == 0)
                    {
                        C[len] = A[i];
                        GenerateUtil(i + 1, pointerB, len, !flag);   // don't increment len as its the 1st ever element
                    }

                    /* include valid element from A and recur */
                    else if (A[i] > C[len])
                    {
                        C[len + 1] = A[i];
                        GenerateUtil(i + 1, pointerB, len + 1, !flag);
                    }
                }
            }

            /* Include valid element from B and recur */
            else
            {
                for (int j = pointerB; j < n; j++)
                {
                    if (B[j] > C[len])
                    {
                        C[len + 1] = B[j];
                        GenerateUtil(pointerA, j + 1, len + 1, !flag);
                    }
                }
            }
        }


        // A utility function to print an array
        static void PrintArr(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine("");
        }
    }
}

/*
 * https://www.geeksforgeeks.org/generate-all-possible-sorted-arrays-from-alternate-elements-of-two-given-arrays/
 * 
 * 4 / 100
 * 
 * 
 * Commented in G4G:-
 * exponential complexity...!?

Yes.. but function calls occur equal to total possible valid combinations..Its efficient.. 
It doesn't construct all the possible array combination and than check for its validity. At each step / function call, 
we construct a unique valid combination.
 * 
 */
