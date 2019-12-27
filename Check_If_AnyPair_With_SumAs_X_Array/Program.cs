using System;
using System.Collections.Generic;

namespace Check_If_AnyPair_With_SumAs_X_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 1, 4, 45, 6, 10, -8 };
            int n = 16;
            int arr_size = 6;

            if (HasArrayTwoCandidates(A, arr_size, n))
                Console.Write("Array has two elements" +
                            " with given sum");
            else
                Console.Write("Array doesn't have " +
                           "two elements with given sum");
        }
        static bool HasArrayTwoCandidates(int[] A, int arr_size, int sum)
        {
            int l, r;

            /* Sort the elements */
            Sort(A, 0, arr_size - 1);

            /* Now look for the two candidates 
            in the sorted array*/
            l = 0;
            r = arr_size - 1;
            while (l < r)
            {
                if (A[l] + A[r] == sum)
                    return true;
                else if (A[l] + A[r] < sum)
                    l++;
                else // A[i] + A[j] > sum
                    r--;
            }
            return false;
        }

        /* Below functions are only to sort the 
        array using QuickSort */

        /* This function takes last element as pivot,
        places the pivot element at its correct
        position in sorted array, and places all
        smaller (smaller than pivot) to left of
        pivot and all greater elements to right
        of pivot */
        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];

            // index of smaller element
            int i = (low - 1);
            for (int j = low; j <= high - 1; j++)
            {
                // If current element is smaller
                // than or equal to pivot
                if (arr[j] <= pivot)
                {
                    i++;

                    // swap arr[i] and arr[j]
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // swap arr[i+1] and arr[high] (or pivot)
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }

        /* The main function that 
        implements QuickSort()
        arr[] --> Array to be sorted,
        low --> Starting index,
        high --> Ending index */
        static void Sort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                /* pi is partitioning index, arr[pi] 
                is now at right place */
                int pi = Partition(arr, low, high);

                // Recursively sort elements before
                // partition and after partition
                Sort(arr, low, pi - 1);
                Sort(arr, pi + 1, high);
            }
        }


        /*
         * How is this solution better than previous one? It would require less comparisons. 
         * Only N to iterate through array and insert values in a Set 
         * because add() and contains() both O(1) operation in hash table. 
         * So total complexity of solution would be O(N).
         * 
         * Read more: https://javarevisited.blogspot.com/2014/08/how-to-find-all-pairs-in-array-of-integers-whose-sum-equal-given-number-java.html#ixzz67XeqkSKJ
         */
        static void Printpairs(int[] arr, int sum)
        {
            HashSet<int> s = new HashSet<int>();
            for (int i = 0; i < arr.Length; ++i)
            {
                int temp = sum - arr[i];

                // checking for condition
                if (temp >= 0 && s.Contains(temp))
                {
                    Console.WriteLine("Pair with given sum " +
                                        sum + " is (" + arr[i] +
                                        ", " + temp + ")");
                }
                s.Add(arr[i]);
            }
        }

    }
}

/*
 * https://www.geeksforgeeks.org/write-a-c-program-that-given-a-set-a-of-n-numbers-and-another-number-x-determines-whether-or-not-there-exist-two-elements-in-s-whose-sum-is-exactly-x/
 * 
 * METHOD 1 (Use Sorting)
 * Time Complexity: Depends on what sorting algorithm we use. 
 * If we use Merge Sort or Heap Sort then (-)(nlogn) in worst case. 
 * If we use Quick Sort then O(n^2) in worst case.
 * Auxiliary Space : Again, depends on sorting algorithm. 
 * For example auxiliary space is O(n) for merge sort and O(1) for Heap Sort.
 * 
 * 
 * METHOD 2 (Use Hashing)
 * This method works in O(n) time.
 * Auxiliary Space: O(n) where n is size of array.
 * 
 * 
 * Method 3 
 * without any additional space,
 * time complexity (N. logN)
 * https://javarevisited.blogspot.com/2014/08/how-to-find-all-pairs-in-array-of-integers-whose-sum-equal-given-number-java.html?source=post_page---------------------------
 */
