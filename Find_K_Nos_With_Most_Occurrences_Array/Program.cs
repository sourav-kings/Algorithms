using System;
using System.Collections.Generic;

namespace Find_K_Nos_With_Most_Occurrences_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 1, 4, 4, 5, 2, 6, 1 };
            int n = arr.Length;
            int k = 2;
            Print_N_mostFrequentNumber(arr, n, k);
        }

        private static void Print_N_mostFrequentNumber(int[] arr, int n, int k)
        {
            // unordered_map 'um' implemented as frequency hash table
            Dictionary<int, int> um = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
                um[arr[i]]++;

            // store the elements of 'um' in the vector 'freq_arr'    
            List<Tuple<int, int>> freq_arr(um.begin(), um.end());

            // sort the vector 'freq_arr' on the basis of the
            // 'compare' function
            sort(freq_arr.begin(), freq_arr.end(), compare);

            // display the the top k numbers
            Console.WriteLine(" numbers with most occurrences are:\n");
            for (int i = 0; i < k; i++)
                Console.Write(freq_arr[i].first + " ");
        }
    }
}
/*
 * https://www.geeksforgeeks.org/find-k-numbers-occurrences-given-array/
 */
