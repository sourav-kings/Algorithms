using System;
using System.Collections.Generic;

namespace Check_If_Array_Is_Subset_Another_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 11, 1, 13, 21, 3, 7 };
            int[] arr2 = { 11, 3, 7, 1 };

            int m = arr1.Length;
            int n = arr2.Length;

            if (isSubset_Fast(arr1, arr2, m, n))
                Console.Write("arr2 is a subset of arr1");
            else
                Console.Write("arr2 is not a subset of arr1");
            
        }


        /* Return true if arr2[] is a 
        subset of arr1[] */
        static bool IsSubset(int[] arr1,
                   int[] arr2, int m, int n)
        {
            int i = 0;
            int j = 0;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                    if (arr2[i] == arr1[j])
                        break;

                /* If the above inner loop 
                was not broken at all then
                arr2[i] is not present in
                arr1[] */
                if (j == m)
                    return false;
            }

            /* If we reach here then all
            elements of arr2[] are present
            in arr1[] */
            return true;
        }



        static bool isSubset_Fast(int[] arr1,
                      int[] arr2,
                      int m,
                      int n)
        {
            int i = 0, j = 0;

            if (m < n)
                return false;

            //sorts arr1
            Array.Sort(arr1);

            // sorts arr2
            Array.Sort(arr2);

            while (i < n && j < m)
            {
                if (arr1[j] < arr2[i])
                    j++;
                else if (arr1[j] == arr2[i])
                {
                    j++;
                    i++;
                }
                else if (arr1[j] > arr2[i])
                    return false;
            }

            if (i < n)
                return false;
            else
                return true;
        }


        static bool isSubset(int[] arr1, int[] arr2, int m,
                                             int n)
        {
            HashSet<int> hset = new HashSet<>();

            // hset stores all the values of arr1
            for (int i = 0; i < m; i++)
            {
                if (!hset.Contains(arr1[i]))
                    hset.Add(arr1[i]);
            }

            // loop to check if all elements of arr2 also
            // lies in arr1
            for (int i = 0; i < n; i++)
            {
                if (!hset.Contains(arr2[i]))
                    return false;
            }
            return true;
        }
    }
}
