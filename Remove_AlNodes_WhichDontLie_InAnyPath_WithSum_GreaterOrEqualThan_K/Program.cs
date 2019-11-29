using System;

namespace Remove_AlNodes_WhichDontLie_InAnyPath_WithSum_GreaterOrEqualThan_K
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
            tree.root.right.left = new Node(6);
            tree.root.right.right = new Node(7);
            tree.root.left.left.left = new Node(8);
            tree.root.left.left.right = new Node(9);
            tree.root.left.right.left = new Node(12);
            tree.root.right.right.left = new Node(10);
            tree.root.right.right.left.right = new Node(11);
            tree.root.left.left.right.left = new Node(13);
            tree.root.left.left.right.right = new Node(14);
            tree.root.left.left.right.right.left = new Node(15);

            Console.WriteLine("Tree before truncation");
            tree.Print(tree.root);

            tree.Prune(tree.root, 45);

            Console.WriteLine("\nTree after truncation");
            tree.Print(tree.root);
        }
    }

    // class to truncate binary tree
    class BinaryTree
    {
        internal Node root;

        // recursive method to truncate binary tree
        internal Node Prune(Node root, int sum)
        {

            // base case
            if (root == null)
                return null;

            // recur for left and right subtree
            root.left = Prune(root.left, sum - root.data);
            root.right = Prune(root.right, sum - root.data);

            // if node is a leaf node whose data is smaller
            // than the sum we delete the leaf.An important
            // thing to note is a non-leaf node can become
            // leaf when its children are deleted.
            if (IsLeaf(root))
            {
                if (sum > root.data)
                    root = null;
            }

            return root;
        }

        // utility method to check if node is leaf
        public bool IsLeaf(Node root)
        {
            if (root == null)
                return false;
            if (root.left == null && root.right == null)
                return true;
            return false;
        }

        // for print traversal
        public void Print(Node root)
        {

            // base case
            if (root == null)
                return;

            Print(root.left);
            Console.Write(root.data + " ");
            Print(root.right);
        }
    }

    class Node
    {
        internal int data;
        internal Node left;
        internal Node right;

        // Constructor to create a new node
        internal Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/remove-all-nodes-which-lie-on-a-path-having-sum-less-than-k/
 * 
 * Remove all nodes which don’t lie in any path with sum>= k
 * 
 * Time Complexity: O(n), the solution does a single traversal of given Binary Tree.
 * 
 */
