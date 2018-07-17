using System;
using System.Collections;
using System.Collections.Generic;

namespace VerticalSum_BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Create following Binary Tree
                      1
                    /    \
                  2        3
                 / \      / \
                4   5    6   7

            */
            TreeNode root = new TreeNode(1);
            root.SetLeft(new TreeNode(2));
            root.SetRight(new TreeNode(3));
            root.Left().SetLeft(new TreeNode(4));
            root.Left().SetRight(new TreeNode(5));
            root.Right().SetLeft(new TreeNode(6));
            root.Right().SetRight(new TreeNode(7));
            Tree t = new Tree(root);

            Console.WriteLine("Following are the values of" +
                               " vertical sums with the positions" +
                            " of the columns with respect to root ");
            t.VerticalSumMain();
        }
    }

    // Class for a Binary Tree
    class Tree
    {

        private TreeNode root;

        // Constructors
        public Tree() { root = null; }
        public Tree(TreeNode n) { root = n; }

        // Method to be called by the consumer classes 
        // like Main class
        public void VerticalSumMain() { VerticalSum(root); }

        // A wrapper over VerticalSumUtil()
        private void VerticalSum(TreeNode root)
        {

            // base case
            if (root == null) { return; }

            // Creates an empty hashMap hM
            Dictionary<int, int> hM =
                       new Dictionary<int, int>();

            // Calls the VerticalSumUtil() to store the 
            // vertical sum values in hM
            VerticalSumUtil(root, 0, hM);

            // Prints the values stored by VerticalSumUtil()
            if (hM != null)
            {
                IEnumerator dasd = hM.Values.GetEnumerator();
                while (dasd.MoveNext())
                    Console.Write(dasd.Current + " ");
            }
        }

        // Traverses the tree in Inoorder form and builds
        // a hashMap hM that contains the vertical sum
        private void VerticalSumUtil(TreeNode root, int hD,
                             Dictionary<int, int> hM)
        {

            // base case
            if (root == null) { return; }

            // Store the values in hM for left subtree
            VerticalSumUtil(root.Left(), hD - 1, hM);

            // Update vertical sum for hD of this node
            int prevSum = (!hM.ContainsKey(hD)) ? 0 : hM[hD];
            hM[hD] = prevSum + root.Key();

            // Store the values in hM for right subtree
            VerticalSumUtil(root.Right(), hD + 1, hM);
        }
    }


    // Class for a tree node
    class TreeNode
    {

        // data members
        private int key;
        private TreeNode left;
        private TreeNode right;

        // Accessor methods
        public int Key() { return key; }
        public TreeNode Left() { return left; }
        public TreeNode Right() { return right; }

        // Constructor
        public TreeNode(int key)
        { this.key = key; left = null; right = null; }

        // Methods to set left and right subtrees
        public void SetLeft(TreeNode left) { this.left = left; }
        public void SetRight(TreeNode right) { this.right = right; }
    }
}

///https://www.geeksforgeeks.org/vertical-sum-in-a-given-binary-tree/