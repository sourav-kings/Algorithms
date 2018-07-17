using System;

namespace Check_If_Two_BinaryTrees_Identical
{
    class Program
    {
        /* Driver program to test identicalTrees() function */
        public static void main(String[] args)
        {
            BinaryTree tree = new BinaryTree();

            tree.root1 = new Node(1);
            tree.root1.left = new Node(2);
            tree.root1.right = new Node(3);
            tree.root1.left.left = new Node(4);
            tree.root1.left.right = new Node(5);

            tree.root2 = new Node(1);
            tree.root2.left = new Node(2);
            tree.root2.right = new Node(3);
            tree.root2.left.left = new Node(4);
            tree.root2.left.right = new Node(5);

            if (tree.IdenticalTrees(tree.root1, tree.root2))
                Console.WriteLine("Both trees are identical");
            else
                Console.WriteLine("Trees are not identical");

        }
    }


    class BinaryTree
    {
        internal Node root1, root2;

        /* Given two trees, return true if they are
           structurally identical */
        internal bool IdenticalTrees(Node a, Node b)
        {
            /*1. both empty */
            if (a == null && b == null)
                return true;

            /* 2. both non-empty -> compare them */
            if (a != null && b != null)
                return (a.data == b.data
                        && IdenticalTrees(a.left, b.left)
                        && IdenticalTrees(a.right, b.right));

            /* 3. one empty, one not -> false */
            return false;
        }


    }


    // A binary tree node
    class Node
    {
        internal int data;
        internal Node left, right;

        internal Node(int item)
        {
            data = item;
            left = right = null;
        }
    }
}
//https://www.geeksforgeeks.org/write-c-code-to-determine-if-two-trees-are-identical/
//1.5