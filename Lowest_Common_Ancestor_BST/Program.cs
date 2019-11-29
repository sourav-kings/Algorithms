using System;

namespace Lowest_Common_Ancestor_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let us construct the BST shown in the above figure
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(20);
            tree.root.left = new Node(8);
            tree.root.right = new Node(22);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(12);
            tree.root.left.right.left = new Node(10);
            tree.root.left.right.right = new Node(14);

            int n1 = 10, n2 = 14;
            Node t = tree.Lca(tree.root, n1, n2);
            Console.WriteLine("LCA of " + n1 + " and " + n2 + " is " + t.data);

            n1 = 14;
            n2 = 8;
            t = tree.Lca(tree.root, n1, n2);
            Console.WriteLine("LCA of " + n1 + " and " + n2 + " is " + t.data);

            n1 = 10;
            n2 = 22;
            t = tree.Lca(tree.root, n1, n2);
            Console.WriteLine("LCA of " + n1 + " and " + n2 + " is " + t.data);

            Console.WriteLine("Hello World!");
        }
    }

    class BinaryTree
    {
        internal Node root;

        /* Function to find LCA of n1 and n2. The function assumes that both
           n1 and n2 are present in BST */
        internal Node Lca(Node node, int n1, int n2)
        {
            if (node == null)
                return null;

            // If both n1 and n2 are smaller than root, then LCA lies in left
            if (node.data > n1 && node.data > n2)
                return Lca(node.left, n1, n2);

            // If both n1 and n2 are greater than root, then LCA lies in right
            if (node.data < n1 && node.data < n2)
                return Lca(node.right, n1, n2);

            return node;
        }
    }

    internal class Node
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
 * https://www.geeksforgeeks.org/lowest-common-ancestor-in-a-binary-search-tree/
 * 
 * 
 * The main idea of the solution is, while traversing from top to bottom, 
 * the first node n we encounter with value between n1 and n2, 
 * i.e., n1 < n < n2 or same as one of the n1 or n2, is LCA of n1 and n2 (assuming that n1 < n2).
 */
