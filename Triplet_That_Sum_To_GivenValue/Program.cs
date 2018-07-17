using System;

namespace Triplet_That_Sum_To_GivenValue
{
    class Program
    {
        static int[] A;
        static void Main(string[] args)
        {
            A = new int[] { 1, 4, 45, 6, 10, 8 };
            int sum = 22;
            int arr_size = A.Length;

            Find3Numbers(arr_size, sum);
        }

        // returns true if there is triplet with sum equal
        // to 'sum' present in A[]. Also, prints the triplet
        static bool Find3Numbers(int arr_size, int sum)
        {
            int l, r;

            /* Sort the elements */
            QuickSort(0, arr_size - 1);

            /* Now fix the first element one by one and find the
               other two elements */
            for (int i = 0; i < arr_size - 2; i++)
            {
                // To find the other two elements, start two index variables
                // from two corners of the array and move them toward each
                // other
                l = i + 1; // index of the first element in the remaining elements
                r = arr_size - 1; // index of the last element
                while (l < r)
                {
                    if (A[i] + A[l] + A[r] == sum)
                    {
                        Console.WriteLine("Triplet is " + A[i] + " ," + A[l]
                                + " ," + A[r]);
                        return true;
                    }
                    else if (A[i] + A[l] + A[r] < sum)
                        l++;

                    else // A[i] + A[l] + A[r] > sum
                        r--;
                }
            }

            // If we reach here, then no triplet was found
            return false;
        }

        /* Implementation of Quick Sort
            A[] --> Array to be sorted
            si  --> Starting index
            ei  --> Ending index
             */
        static void QuickSort(int si, int ei)
        {
            int pi;

            /* Partitioning index */
            if (si < ei)
            {
                pi = Partition(si, ei);
                QuickSort(si, pi - 1);
                QuickSort(pi + 1, ei);
            }
        }
        static int Partition(int si, int ei)
        {
            int x = A[ei];
            int i = (si - 1);
            int j;

            for (j = si; j <= ei - 1; j++)
            {
                if (A[j] <= x)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, ei);
            return (i + 1);
        }
        static void Swap(int idx1, int idx2)
        {
            int temp = A[idx1];
            A[idx1] = A[idx2];
            A[idx2] = temp;
        }


    }
}

//https://www.geeksforgeeks.org/find-a-triplet-that-sum-to-a-given-value/
