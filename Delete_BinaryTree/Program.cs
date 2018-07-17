using System;

namespace Delete_BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            /* Note that we pass root node here */
            tree.DeleteTreeRef(tree.root);
            Console.WriteLine("Tree deleted");
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

    class BinaryTree
    {

        internal Node root;

        /*  This function is same as deleteTree() in the previous program */
        void DeleteTree(Node node)
        {
            // In Java automatic garbage collection
            // happens, so we can simply make root
            // null to delete the tree
            root = null;
        }

        /* Wrapper function that deletes the tree and 
           sets root node as null  */
        internal void DeleteTreeRef(Node nodeRef)
        {
            DeleteTree(nodeRef);
            nodeRef = null;
        }

    }
}
