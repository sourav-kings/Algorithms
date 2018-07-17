using System;

namespace Kth_Element_Of_Two_Sorted_Arrays
{
    class Program
    {
        static int[] arr1;
        static int[] arr2;
        static void Main(string[] args)
        {
            arr1 = new int[5] { 2, 3, 6, 7, 9 };
            arr2 = new int[4] { 1, 4, 8, 10 };

            int k = 5;
            Console.WriteLine(Kth(0, 0, arr1.Length-1, arr2.Length - 1, k));
            Console.WriteLine(Kth_2(arr1.Length - 1, arr2.Length - 1, k));
        }


        /*
         * Divide And Conquer Approach 1
         */
        static int Kth(int start1, int start2, int end1, int end2, int k)
        {
            if (start1 == end1)
                return arr2[k];
            if (start2 == end2)
                return arr1[k];
            int mid1 = (end1 - start1) / 2;
            int mid2 = (end2 - start2) / 2;
            if (mid1 + mid2 < k)
            {
                if (arr1[mid1] > arr2[mid2])
                    return Kth(start1, start2 + mid2 + 1, end1, end2,
                        k - mid2 - 1);
                else
                    return Kth(start1 + mid1 + 1, start2, end1, end2,
                        k - mid1 - 1);
            }
            else
            {
                if (arr1[mid1] > arr2[mid2])
                    return Kth(start1, start2, start1 + mid1, end2, k);
                else
                    return Kth(start1, start2, end1, start2 + mid2, k);
            }
        }




        /*
         * Divide And Conquer Approach 2
         */
        static int Kth_2(int m, int n, int k,
                           int st1 = 0, int st2 = 0)
        {
            // In case we have reached end of array 1
            if (st1 == m)
                return arr2[st2 + k - 1];

            // In case we have reached end of array 2
            if (st2 == n)
                return arr1[st1 + k - 1];

            // k should never reach 0 or exceed sizes
            // of arrays
            if (k == 0 || k > (m - st1) + (n - st2))
                return -1;

            // Compare first elements of arrays and return
            if (k == 1)
                return (arr1[st1] < arr2[st2]) ?
                    arr1[st1] : arr2[st2];
            int curr = k / 2;

            // Size of array 1 is less than k / 2
            if (curr - 1 >= m - st1)
            {
                // Last element of array 1 is not kth
                // We can directly return the (k - m)th
                // element in array 2
                if (arr1[m - 1] < arr2[st2 + curr - 1])
                    return arr2[st2 + (k - (m - st1) - 1)];
                else
                    return Kth_2(m, n, k - curr,
                        st1, st2 + curr);
            }

            // Size of array 2 is less than k / 2
            if (curr - 1 >= n - st2)
            {
                if (arr2[n - 1] < arr1[st1 + curr - 1])
                    return arr1[st1 + (k - (n - st2) - 1)];
                else
                    return Kth_2(m, n, k - curr,
                        st1 + curr, st2);
            }
            else
            {
                // Normal comparison, move starting index
                // of one array k / 2 to the right
                if (arr1[curr + st1 - 1] < arr2[curr + st2 - 1])
                    return Kth_2(m, n, k - curr,
                        st1 + curr, st2);
                else
                    return Kth_2(m, n, k - curr,
                        st1, st2 + curr);
            }
        }
    }
}
//https://www.geeksforgeeks.org/k-th-element-two-sorted-arrays/