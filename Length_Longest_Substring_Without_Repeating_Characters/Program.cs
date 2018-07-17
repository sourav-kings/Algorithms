using System;
using System.Collections.Generic;
using System.Linq;

namespace Length_Longest_Substring_Without_Repeating_Characters
{
    class Program
    {
        const int NO_OF_CHARS = 256;
        static void Main(string[] args)
        {
            //string input = "abcabcbb";
            //string input = "ABDEFGABEF";
            string input = "geeksforgeeks";

            /*testing
             
             */
            string input_test = "geeks";
            Console.WriteLine(lengthOfLongestSubstringFaster(input_test));//"eks" - 3

            input_test = "gekes";
            Console.WriteLine(lengthOfLongestSubstringFaster(input_test));//"kes" - 3

            input_test = "gekse";
            Console.WriteLine(lengthOfLongestSubstringFaster(input_test));// "geks" - 4

            input_test = "geeksgo";
            Console.WriteLine(lengthOfLongestSubstringFaster(input_test));// "eksgo" - 5

            Console.WriteLine(lengthOfLongestSubstring(input));
            Console.WriteLine(lengthOfLongestSubstringFaster(input));// "eksforg" - 7
        }

        static int lengthOfLongestSubstring(string s)
        {
            if (s == null || s.Length == 0)
                return 0;

            HashSet<char> set = new HashSet<char>();

            int start = 0, max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (!set.Contains(s[i]))
                    set.Add(s[i]);
                else
                {
                    max = Math.Max(max, set.Count());

                    //keep looping until --> (start has reached ith item) OR (start item is equal to ith item)
                    while (start < i && s[start] != s[i])
                    {
                        set.Remove(s[start]);
                        start++;
                    }
                    start++;
                }
            }

            return Math.Max(max, set.Count());
        }

        static int lengthOfLongestSubstringFaster(string str)
        {
            int n = str.Length;
            int cur_len = 1;  // lenght of current substring
            int max_len = 1;  // result
            int prev_index;  //  previous index
            int[] visited = new int[NO_OF_CHARS];

            /* Initialize the visited array as -1, -1 is used to
               indicate that character has not been visited yet. */
            for (int i = 0; i < NO_OF_CHARS; i++)
                visited[i] = -1;

            /* Mark first character as visited by storing the index
               of first character in visited array. */
            visited[str[0]] = 0;

            for (int i = 1; i < n; i++)
            {
                prev_index = visited[str[i]];

                if (prev_index == -1) //if (prev_index == -1 || cur_len < i - prev_index)   
                    cur_len++;
                else
                {
                    if (cur_len < i - prev_index)
                        cur_len++;
                    else
                    {
                        max_len = Math.Max(cur_len, max_len);
                        cur_len = i - prev_index;
                    }
                }

                // update the index of current character
                visited[str[i]] = i;
            }

            // Compare the length of last NRCS with max_len and
            // update max_len if needed
            return Math.Max(cur_len, max_len);
        }
    }
}

/*
 * https://www.geeksforgeeks.org/length-of-the-longest-substring-without-repeating-characters/
 * 
 * Method 1 - Naive
 *      Consider all substrings one by one and check for each substring whether it contains all unique characters or not.
 *      
 *      There will be n*(n+1)/2 substrings.
 *      
 *      Whether a substirng contains all unique characters or not can be checked in linear time by scanning it from left to right and keeping a map of visited characters.
 *      
 *      
 *      
 *  Method 2 - Liner Time
 *      Scan the string from left to right, keep track of the maximum length Non-Repeating Character Substring (NRCS) seen so far.
 *      
 *      Let the maximum length be max_len.
 *      
 *      When we traverse the string, we also keep track of length of the current NRCS using cur_len variable
 *      
 *      For every new character, we look for it in already processed part of the string
 *      
 */
