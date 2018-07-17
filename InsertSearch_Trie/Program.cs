using System;

namespace InsertSearch_Trie
{
    class Program
    {

        // Alphabet size (# of symbols)
        static TrieNode root;

        static void Main(string[] args)
        {
            // Input keys (use only 'a' through 'z' and lower case)
            string[] keys = {"the", "a", "there", "answer", "any",
                         "by", "bye", "their"};

            string[] output = { "Not present in trie", "Present in trie" };


            root = new TrieNode();

            // Construct trie
            int i;
            for (i = 0; i < keys.Length; i++)
                Insert(keys[i]);

            // Search for different keys
            if (Search("the") == true)
                Console.WriteLine("the --- " + output[1]);
            else Console.WriteLine("the --- " + output[0]);

            if (Search("these") == true)
                Console.WriteLine("these --- " + output[1]);
            else Console.WriteLine("these --- " + output[0]);

            if (Search("their") == true)
                Console.WriteLine("their --- " + output[1]);
            else Console.WriteLine("their --- " + output[0]);

            if (Search("thaw") == true)
                Console.WriteLine("thaw --- " + output[1]);
            else Console.WriteLine("thaw --- " + output[0]);
        }


        // If not present, inserts key into trie
        // If the key is prefix of trie node, just marks leaf node
        static void Insert(String key)
        {
            int level;
            int length = key.Length;
            int index;

            TrieNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (pCrawl.children[index] == null)
                    pCrawl.children[index] = new TrieNode();

                pCrawl = pCrawl.children[index];
            }

            // mark last node as leaf
            pCrawl.isEndOfWord = true;
        }


        // Returns true if key presents in trie, else false
        static bool Search(String key)
        {
            int level;
            int length = key.Length;
            int index;
            TrieNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';

                if (pCrawl.children[index] == null)
                    return false;

                pCrawl = pCrawl.children[index];
            }

            return (pCrawl != null && pCrawl.isEndOfWord);
        }
    }


    // trie node
    class TrieNode
    {
        const int ALPHABET_SIZE = 26;
        public TrieNode[] children = new TrieNode[ALPHABET_SIZE];

        // isEndOfWord is true if the node represents
        // end of a word
        public bool isEndOfWord;

        public TrieNode()
        {
            isEndOfWord = false;
            for (int i = 0; i < ALPHABET_SIZE; i++)
                children[i] = null;
        }
    };
}

/*
 * April, 2018.
 * (3.5 / 123)
 */