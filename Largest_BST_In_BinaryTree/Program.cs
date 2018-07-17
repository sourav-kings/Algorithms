using System;

namespace Largest_BST_In_BinaryTree
{
    class Program
    {
        static Node root;

        static void Main(string[] args)
        {
            root = new Node(60)
            {
                left = new Node(65),//left = new Node(55),
                right = new Node(70)
            };
            root.left.left = new Node(50);

            Console.WriteLine("Size of the largest BST is:- "+ LargestBST(root));
        }

        /* Returns size of the largest BST subtree in a Binary Tree
         (efficient version). */
        static int LargestBST(Node node)
        {
            Value val = new Value();
            LargestBSTUtil(node, val, val, val, val);
            return val.max_size;
        }


        /* largestBSTUtil() updates *max_size_ref for the size of the largest BST
     subtree.   Also, if the tree rooted with node is non-empty and a BST,
     then returns size of the tree. Otherwise returns 0.*/
        static int LargestBSTUtil(Node node, Value min_ref, Value max_ref,
                Value max_size_ref, Value is_bst_ref)
        {

            /* Base Case */
            if (node == null)
            {
                is_bst_ref.is_bst = true; // An empty tree is BST
                return 0;    // Size of the BST is 0
            }

            int min = int.MaxValue;

            /* A flag variable for left subtree property
             i.e., max(root->left) < root->data */
            bool left_flag = false;

            /* A flag variable for right subtree property
             i.e., min(root->right) > root->data */
            bool right_flag = false;

            int ls, rs; // To store sizes of left and right subtrees

            /* Following tasks are done by recursive call for left subtree
             a) Get the maximum value in left subtree (Stored in *max_ref)
             b) Check whether Left Subtree is BST or not (Stored in *is_bst_ref)
             c) Get the size of maximum size BST in left subtree (updates *max_size) */
            max_ref.max = int.MinValue;
            ls = LargestBSTUtil(node.left, min_ref, max_ref, max_size_ref, is_bst_ref);
            if (is_bst_ref.is_bst == true && node.data > max_ref.max)
                left_flag = true;

            /* Before updating *min_ref, store the min value in left subtree. So that we
             have the correct minimum value for this subtree */
            min = min_ref.min;

            /* The following recursive call does similar (similar to left subtree) 
             task for right subtree */
            min_ref.min = int.MaxValue;
            rs = LargestBSTUtil(node.right, min_ref, max_ref, max_size_ref, is_bst_ref);

            if (is_bst_ref.is_bst == true && node.data < min_ref.min)
                right_flag = true;

            // Update min and max values for the parent recursive calls
            if (min < min_ref.min)
                min_ref.min = min;

            if (node.data < min_ref.min) // For leaf nodes
                min_ref.min = node.data;

            if (node.data > max_ref.max)
                max_ref.max = node.data;

            /* If both left and right subtrees are BST. And left and right
             subtree properties hold for this node, then this tree is BST.
             So return the size of this tree */
            if (left_flag && right_flag)
            {
                if (ls + rs + 1 > max_size_ref.max_size)
                    max_size_ref.max_size = ls + rs + 1;

                return ls + rs + 1;
            }
            else
            {
                //Since this subtree is not BST, set is_bst flag for parent calls
                is_bst_ref.is_bst = false;
                return 0;
            }
        }
    }

    class Node
    {
        public int data;
        public Node left, right;

        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }

    class Value
    {
        public int max_size = 0; // for size of largest BST
        public bool is_bst = false;
        public int min = int.MaxValue;  // For minimum value in right subtree
        public int max = int.MinValue;  // For maximum value in left subtree

    }
}

/*
 * https://www.geeksforgeeks.org/largest-bst-binary-tree-set-2/
 * 
 * We have discussed a two methods in below post.
Find the largest BST subtree in a given Binary Tree | Set 1

In this post a different O(n) solution is discussed. 
This solution is simpler than the solutions discussed above and works in O(n) time.
 */
