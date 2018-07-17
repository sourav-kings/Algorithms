using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Sort_Elements_By_Frequency
{
    class Program
    {
        // Map m2 keeps track of indexes of elements in array
        static Dictionary<int, int> m2 = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            int[] arr = { 2, 5, 2, 6, -1, 9999999, 5, 8, 8, 8 };
            int n = arr.Length;

            //SortByFrequency(arr, n);

            //for (int i = 0; i < n; i++)
            //    Console.Write(arr[i] + " ");

            SortByFrequency_Hashing(arr, n);
        }

        private static void SortByFrequency_Hashing(int[] arr, int n)
        {
            Dictionary<int, int> m = new Dictionary<int, int>();
            List<Tuple<int, int>> v = new List<Tuple<int, int>>();

            for (int i = 0; i < n; i++)
            {

                // Map m is used to keep track of count 
                // of elements in array                
                m[arr[i]] = m.ContainsKey(arr[i]) ? m[arr[i]]+1 : 1;

                // Update the value of map m2 only once
                if (!m2.ContainsKey(arr[i]))
                    m2[arr[i]] = i;
            }

            // Copy map to vector
            foreach(var dict in m)
                v.Add(new Tuple<int, int>(dict.Key, dict.Value));

            // Sort the element of array by frequency
            //sort(v.begin(), v.end(), sortByVal);
            v.Sort(new MyComparator3());

            for (int i = 0; i < v.Count; ++i)
                for (int j = 0; j < v[i].Item2; ++j)
                    Console.Write(v[i].Item1 + " ");
        }

        static void SortByFrequency(int[] arr, int n)
        {
            Element[] element = new Element[n];
            for (int i = 0; i < n; i++)
            {
                element[i].index = i;    /* Fill Indexes */
                element[i].count = 0;    /* Initialize counts as 0 */
                element[i].val = arr[i]; /* Fill values in structure
                                     elements */
            }

            /* Sort the structure elements according to value,
               we used stable sort so relative order is maintained. */
            Array.Sort(element, new MyComparator1());

            /* initialize count of first element as 1 */
            element[0].count = 1;

            /* Count occurrences of remaining elements */
            for (int i = 1; i < n; i++)
            {
                if (element[i].val == element[i - 1].val)
                {
                    /* Increment count if it has duplicate and we do 
                       not need the duplicate now */
                    element[i].count += element[i - 1].count + 1;

                    /* Set count of previous element as -1 , we are
                       doing this because we'll again sort on the
                       basis of counts (if counts are equal than on
                       the basis of index)*/
                    element[i - 1].count = -1;

                    /* Retain the first index (Remember first index
                       is always present in the first duplicate we
                       used stable sort. */
                    element[i].index = element[i - 1].index;
                }

                /* Else If previous element is not equal to current
                  so set the count to 1 */
                else element[i].count = 1;
            }

            /* Now we have counts and first index for each element so now
               sort on the basis of count and in case of tie use index
               to sort.*/
            Array.Sort(element, new MyComparator2());


            for (int i = n - 1, index = 0; i >= 0; i--)
                if (element[i].count != -1)
                    for (int j = 0; j < element[i].count; j++)
                        arr[index++] = element[i].val;
        }

        class MyComparator1 : IComparer<Element>
        {
            public int Compare(Element x, Element y)
            {
                return (y.val > x.val) ? -1 : 1;
            }
        }

        class MyComparator2 : IComparer<Element>
        {
            public int Compare(Element x, Element y)
            {
                if (x.count != y.count)
                    return (y.count > x.count) ? -1 : 1;
                else
                    return (x.index > y.index) ? -1 : 1;
            }
        }

        class MyComparator3 : IComparer<Tuple<int, int>>
        {
            public int Compare(Tuple<int, int> a, Tuple<int, int> b)
            {
                // If frequency is same then sort by index
                if (a.Item2 == b.Item2)
                    return (m2[a.Item1] > m2[b.Item1]) ? 1 : -1;

                return (a.Item2 < b.Item2) ? 1 : -1;
            }
        }
    }

    struct Element
    {
        public int count, index, val;
    }


}

/*
 * https://www.geeksforgeeks.org/sort-elements-by-frequency/
 * O(n Log n) time where n is total number of elements.

 * //https://ideone.com/IN1LKm
 * Time = O(nlogn) Space = O(n)
 * 
 * //https://ideone.com/eVJ6C7
 * 
 * 
 * 
 * https://www.geeksforgeeks.org/sort-elements-frequency-set-4-efficient-approach-using-hash/
 *  O(n + m Log m) time where n is total number of elements and m is total number of distinct elements.
 */
