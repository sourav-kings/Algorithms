using System;

namespace Count_Subsequences_Of_Form_a_i_b_j_c_k
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = "abcabc";
            Console.WriteLine(CountSubsequences(s));
        }


        // Returns count of subsequences 
        // of the form a^i b^j c^k
        static int CountSubsequences(String s)
        {
            // Initialize counts of different
            // subsequences caused by different
            // combination of 'a'
            int aCount = 0;

            // Initialize counts of different
            // subsequences caused by different
            // combination of 'a' and
            // different combination of 'b'
            int bCount = 0;

            // Initialize counts of different 
            // subsequences caused by different
            // combination of 'a', 'b' and 'c'
            int cCount = 0;

            // Traverse all characters of given string
            for (int i = 0; i < s.Length; i++)
            {

                // If current character is 'a', then
                // there are following possibilities :
                // a) Current character begins a
                //    new subsequence.
                // b) Current character is part 
                //    of aCount subsequences
                // c) Current character is not part
                //    of aCount subsequences.

                if (s[i] == 'a')
                    aCount = (1 + 2 * aCount);

                // If current character is 'b', then
                // there are following possibilities :
                // a) Current character begins a new
                //    subsequence of b's with aCount
                //    subsequences.
                // b) Current character is part of bCount
                //    subsequences.
                // c) Current character is not part of
                //    bCount subsequences.
                else if (s[i] == 'b')
                    bCount = (aCount + 2 * bCount);

                // If current character is 'c', then
                // there are following possibilities :
                // a) Current character begins a new
                //      subsequence of c's with bCount
                //      subsequences.
                // b) Current character is part of cCount
                //      subsequences.
                // c) Current character is not part of
                //      cCount subsequences.
                else if (s[i] == 'c')
                    cCount = (bCount + 2 * cCount);
            }

            return cCount;
        }
    }
}

/*
 * https://www.geeksforgeeks.org/number-subsequences-form-ai-bj-ck/
 * 
 * 4 / 100
 * 
    Number of subsequences of the form a^i b^j c^k
    Given a string, count number of subsequences of the form aibjck, i.e., it consists of i ’a’ characters, followed by j ’b’ characters, followed by k ’c’ characters where i >= 1, j >=1 and k >= 1.

    Note: Two subsequences are considered different if the set of array indexes picked for the 2 subsequences are different.

    Expected Time Complexity : O(n)

    Examples:

    Input  : abbc
    Output : 3
    Subsequences are abc, abc and abbc

    Input  : abcabc
    Output : 7
    Subsequences are abc, abc, abbc, aabc
    abcc, abc and abc
 */
