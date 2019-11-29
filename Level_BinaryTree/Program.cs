using System;

namespace Level_Of_BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            /* Constructing tree given in the above figure */
            tree.root = new Node(3);
            tree.root.left = new Node(2);
            tree.root.right = new Node(5);
            tree.root.left.left = new Node(1);
            tree.root.left.right = new Node(4);
            for (int x = 1; x <= 5; x++)
            {
                int level = tree.GetLevel(tree.root, x);
                if (level != 0)
                    Console.WriteLine("Level of " + x + " is "
                            + tree.GetLevel(tree.root, x));
                else
                    Console.WriteLine(x + " is not present in tree");
            }
        }
    }


    class BinaryTree
    {

        internal Node root;

        /* Helper function for getLevel().  It returns level of the data
        if data is present in tree, otherwise returns 0.*/
        int GetLevelUtil(Node node, int data, int level)
        {
            if (node == null)
                return 0;

            if (node.data == data)
                return level;

            int downlevel = GetLevelUtil(node.left, data, level + 1);
            if (downlevel != 0)
                return downlevel;

            downlevel = GetLevelUtil(node.right, data, level + 1);
            return downlevel;
        }

        /* Returns level of given data value */
        internal int GetLevel(Node node, int data)
        {
            return GetLevelUtil(node, data, 1);
        }
    }

    class Node
    {
        internal int data;
        internal Node left, right;

        internal Node(int d)
        {
            data = d;
            left = right = null;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/get-level-of-a-node-in-a-binary-tree/
 */
