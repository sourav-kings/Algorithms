using System;

namespace Check_If_String_Is_Subsequence_Of_Another
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "gksrek";
            string str2 = "geeksforgeeks";
            int m = str1.Length;
            int n = str2.Length;
            bool res = IsSubSequence(str1, str2, m, n);

            if (res)
                Console.Write("Yes");
            else
                Console.Write("No");
        }

        // Returns true if str1[] is a 
        // subsequence of str2[] m is 
        // length of str1 and n is length 
        // of str2
        static bool IsSubSequence(string str1,
                      string str2, int m, int n)
        {

            // Base Cases
            if (m == 0)
                return true;
            if (n == 0)
                return false;

            // If last characters of two strings
            // are matching
            if (str1[m - 1] == str2[n - 1])
                return IsSubSequence(str1, str2,
                                        m - 1, n - 1);

            // If last characters are not matching
            return IsSubSequence(str1, str2, m, n - 1);
        }



        // Returns true if str1[] is a subsequence 
        // of str2[] m is length of str1 and n is
        // length of str2
        static bool IsSubSequence_iterative(string str1,
                        string str2, int m, int n)
        {
            int j = 0;

            // Traverse str2 and str1, and compare 
            // current character of str2 with first
            // unmatched char of str1, if matched 
            // then move ahead in str1
            for (int i = 0; i < n && j < m; i++)
                if (str1[j] == str2[i])
                    j++;

            // If all characters of str1 were found
            // in str2
            return (j == m);
        }
    }
}

/*
 * https://www.geeksforgeeks.org/given-two-strings-find-first-string-subsequence-second/
 * 
 * The idea is simple, we traverse both strings from one side to other side 
 * (say from rightmost character to leftmost). 
 * If we find a matching character, we move ahead in both strings. 
 * Otherwise we move ahead only in str2.
 * 
 * Time Complexity of both implementations above is O(n) where n is the length of str2.
 */
