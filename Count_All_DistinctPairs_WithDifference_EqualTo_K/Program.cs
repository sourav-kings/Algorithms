using System;
using System.Collections.Generic;

namespace Count_All_DistinctPairs_WithDifference_EqualTo_K
{
    class Program
    {
        const int MAX = 100000;
        static void Main(string[] args)
        {
            int[] arr = { 1, 5, 3, 4, 2 };
            int n = arr.Length;
            int k = 3;

            Console.WriteLine("Count of pairs with "
                                 + " given diff is "
                   + CountPairsWithDiffK_Naive(arr, n, k));

            Console.WriteLine("Count of pairs with "
                                    + " given diff is "
                    + CountPairsWithDiffK_Fast(arr, n, k));


            Console.WriteLine("Count of pairs with "
                         + " given diff is "
                    + CountPairsWithDiffK_Faster_ExtraSpace(arr, n, k));

        }

        //Naive - O(n * n)
        static int CountPairsWithDiffK_Naive(int[] arr,
                            int n, int k)
        {
            int count = 0;

            // Pick all elements one by one
            for (int i = 0; i < n; i++)
            {

                // See if there is a pair
                // of this picked element
                for (int j = i + 1; j < n; j++)
                    if (arr[i] - arr[j] == k ||
                          arr[j] - arr[i] == k)
                        count++;
            }

            return count;
        }


        /* Returns count of pairs with
        difference k in arr[] of size n. */
        static int CountPairsWithDiffK_Fast(int[] arr,
                                    int n, int k)
        {
            int count = 0;

            // Sort array elements
            Array.Sort(arr);

            int l = 0;
            int r = 0;
            while (r < n)
            {
                if (arr[r] - arr[l] == k)
                {
                    count++;
                    l++;
                    r++;
                }
                else if (arr[r] - arr[l] > k)
                    l++;
                else // arr[r] - arr[l] < sum
                    r++;
            }
            return count;
        }

        static int CountPairsWithDiffK_Faster_ExtraSpace(int[] arr, int n, int k)
        {
            int count = 0;  // Initialize count

            // Initialize empty hashmap.
            Dictionary<int, bool> hashmap = new Dictionary<int, bool>();

            // Insert array elements to hashmap
            for (int i = 0; i < n; i++)
                hashmap[arr[i]] = true;

            for (int i = 0; i < n; i++)
            {
                int x = arr[i];
                if (x - k >= 0 && (hashmap.ContainsKey(x - k) && hashmap[x - k]))
                    count++;
                if (x + k < MAX && (hashmap.ContainsKey(x + k) && hashmap[x + k]))
                    count++;
                hashmap[x] = false;
            }
            return count;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/count-pairs-difference-equal-k/
 */
