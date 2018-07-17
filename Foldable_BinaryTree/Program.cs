using System;

namespace Foldable_BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {


            /* The constructed binary tree is
                 1
               /   \
              2     3
               \    /
                4  5
            */
            BinaryTree tree = new BinaryTree { 
            root = new Node(1);
            root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.right.left = new Node(4);
            tree.root.left.right = new Node(5)
                };

            if (tree.IsFoldable(tree.root))
                Console.WriteLine("tree is foldable");
            else
                Console.WriteLine("Tree is not foldable");
        }
    }


    class BinaryTree
    {
        internal Node root;

        /* Returns true if the given tree can be folded */
        internal bool IsFoldable(Node node)
        {
            if (node == null)
                return true;

            return IsFoldableUtil(node.left, node.right);
        }

        /* A utility function that checks if trees with roots as n1 and n2
         are mirror of each other */
        internal bool IsFoldableUtil(Node n1, Node n2)
        {

            /* If both left and right subtrees are NULL,
             then return true */
            if (n1 == null && n2 == null)
                return true;

            /* If one of the trees is NULL and other is not,
             then return false */
            if (n1 == null || n2 == null)
                return false;

            /* Otherwise check if left and right subtrees are mirrors of
             their counterparts */
            return IsFoldableUtil(n1.left, n2.right)
                    && IsFoldableUtil(n1.right, n2.left);
        }

    }


    /* A binary tree node has data, pointer to left child
   and a pointer to right child */
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
/*
 * Average Difficulty : 2.5/5.0
    Based on 116 vote(s)


 * https://www.geeksforgeeks.org/foldable-binary-trees/
 * 
 * A tree can be folded if left and right subtrees of the tree are 
 * structure wise mirror image of each other
 * 
 * empty tree is considered as foldable.
 */
