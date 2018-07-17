using System;

namespace Common_Nodes_On_Path_From_Root_Or_CommonAncestors
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Let us create Binary Tree shown in 
            above example */

            BinaryTree tree = new BinaryTree();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(6);
            tree.root.right.right = new Node(7);
            tree.root.left.left.left = new Node(8);
            tree.root.right.left.left = new Node(9);
            tree.root.right.left.right = new Node(10);

            if (tree.FindCommonNodes(tree.root, 9, 7) == false)
                Console.WriteLine("No Common nodes");
        }
    }


    class BinaryTree
    {
        internal Node root;
        // Utility function to find the LCA of two given values
        // n1 and n2.
        Node FindLCA(Node root, int n1, int n2)
        {
            // Base case
            if (root == null)
                return null;

            // If either n1 or n2 matches with root's key,
            // report the presence by returning root (Note
            // that if a key is ancestor of other, then the
            // ancestor key becomes LCA
            if (root.data == n1 || root.data == n2)
                return root;

            // Look for keys in left and right subtrees
            Node left_lca = FindLCA(root.left, n1, n2);
            Node right_lca = FindLCA(root.right, n1, n2);

            // If both of the above calls return Non-NULL, then
            // one key is present in once subtree and other is
            // present in other, So this node is the LCA
            if (left_lca != null && right_lca != null)
                return root;

            // Otherwise check if left subtree or right
            // subtree is LCA
            return (left_lca != null) ? left_lca : right_lca;
        }

        // Utility Function to print all ancestors of LCA
        bool PrintAncestors(Node root, int target)
        {
            /* base cases */
            if (root == null)
                return false;

            if (root.data == target)
            {
                Console.Write(root.data + " ");
                return true;
            }

            /* If target is present in either left or right
            subtree of this node, then print this node */
            if (PrintAncestors(root.left, target) ||
                PrintAncestors(root.right, target))
            {
                Console.Write(root.data + " ");
                return true;
            }

            /* Else return false */
            return false;
        }

        // Function to find nodes common to given two nodes
        internal bool FindCommonNodes(Node root, int first,
                                            int second)
        {
            Node LCA = FindLCA(root, first, second);
            if (LCA == null)
                return false;

            PrintAncestors(root, LCA.data);
            return true;
        }
    }


    class Node
    {
        internal int data;
        internal Node left, right;

        internal Node(int item)
        {
            data = item;
            left = null;
            right = null;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/print-common-nodes-path-root-common-ancestors/
 * 
 * 
 */
