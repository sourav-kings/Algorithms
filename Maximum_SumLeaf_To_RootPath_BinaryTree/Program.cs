using System;

namespace Maximum_SumLeaf_To_RootPath_BinaryTree
{
    class Program
    {
        static Node root;
        static Maximum max = new Maximum();
        static Node target_leaf = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            root = new Node(10);
            root.left = new Node(-2);
            root.right = new Node(7);
            root.left.left = new Node(8);
            root.left.right = new Node(-4);
            Console.WriteLine("Following are the nodes " +
                            "on maximum sum path");
            int sum = MaxSumPath();
            Console.WriteLine("");
            Console.WriteLine("Sum of nodes is : " + sum);
        }

        // Returns the maximum sum and prints the nodes on
        // max sum path
        static int MaxSumPath()
        {
            // base case
            if (root == null)
                return 0;

            // find the target leaf and maximum sum
            GetTargetLeaf(root, max, 0);

            // print the path from root to the target leaf
            PrintPath(root, target_leaf);
            return max.max_no; // return maximum sum
        }


        // This function Sets the target_leaf_ref to refer
        // the leaf node of the maximum path sum. Also,
        // returns the max_sum using max_sum_ref
        static void GetTargetLeaf(Node node, Maximum max_sum_ref,
                        int curr_sum)
        {
            if (node == null)
                return;

            // Update current sum to hold sum of nodes on
            // path from root to this node
            curr_sum = curr_sum + node.data;
            int a = max_sum_ref.max_no;

            // If this is a leaf node and path to this node
            // has maximum sum so far, then make this node
            // target_leaf
            if (node.left == null && node.right == null)
            {
                if (curr_sum > max_sum_ref.max_no)
                {
                    max_sum_ref.max_no = curr_sum;
                    target_leaf = node;
                }
            }

            // If this is not a leaf node, then recur down
            // to find the target_leaf
            GetTargetLeaf(node.left, max_sum_ref, curr_sum);
            GetTargetLeaf(node.right, max_sum_ref, curr_sum);
        }


        // A utility function that prints all nodes on the
        // path from root to target_leaf
        static bool PrintPath(Node node, Node target_leaf)
        {
            // base case
            if (node == null)
                return false;

            // return true if this node is the target_leaf or
            // target leaf is present in one of its descendants
            if (node == target_leaf || PrintPath(node.left, target_leaf)
                    || PrintPath(node.right, target_leaf))
            {
                Console.WriteLine(node.data + " ");
                return true;
            }

            return false;
        }
    }

    /* A binary tree node has data, pointer to left child
and a pointer to right child */
    class Node
    {
        public int data;
        public Node left;
        public Node right;

        // Constructor
        public Node(int d)
        {
            data = d;
            left = null;
            right = null;
        }
    }

    // A wrapper class is used so that max_no
    // can be updated among function calls.
    class Maximum
    {
        public int max_no = int.MinValue;
    }
}
/*
 * https://www.geeksforgeeks.org/find-the-maximum-sum-path-in-a-binary-tree/
 * 
 */
