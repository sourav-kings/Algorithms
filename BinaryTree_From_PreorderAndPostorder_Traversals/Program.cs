using System;

namespace BinaryTree_From_PreorderAndPostorder_Traversals
{
    class Program
    {
        // variable to hold index in pre[] array
        static int preindex;

        static void Main(string[] args)
        {
            int[] pre = { 1, 2, 4, 8, 9, 5, 3, 6, 7 };
            int[] post = { 8, 9, 4, 5, 2, 6, 7, 3, 1 };

            int size = pre.Length;
            Node root = ConstructTree(pre, post, size);

            Console.WriteLine("Inorder traversal of the constructed tree:");
            PrintInorder(root);
        }

        // The main function to construct Full 
        // Binary Tree from given preorder and 
        // postorder traversals. This function 
        // mainly uses constructTreeUtil()
        static Node ConstructTree(int[] pre, int[] post, int size)
        {
            preindex = 0;
            return ConstructTreeUtil(pre, post, 0, size - 1, size);
        }


        // A recursive function to construct Full 
        // from pre[] and post[]. preIndex is used 
        // to keep track of index in pre[]. l is 
        // low index and h is high index for the 
        // current subarray in post[]
        static Node ConstructTreeUtil(int[] pre, int[] post, int l,
                                       int h, int size)
        {

            // Base case
            if (preindex >= size || l > h)
                return null;

            // The first Node in preorder traversal is 
            // root. So take the Node at preIndex from 
            // preorder and make it root, and increment 
            // preIndex
            Node root = new Node(pre[preindex]);
            preindex++;

            // If the current subarry has only one 
            // element, no need to recur or 
            // preIndex > size after incrementing
            if (l == h || preindex >= size)
                return root;
            int i;

            // Search the next element of pre[] in post[]
            for (i = l; i <= h; i++)
            {
                if (post[i] == pre[preindex])
                    break;
            }
            // Use the index of element found in 
            // postorder to divide postorder array 
            // in two parts. Left subtree and right subtree
            if (i <= h)
            {
                root.left = ConstructTreeUtil(pre, post, l, i, size);
                root.right = ConstructTreeUtil(pre, post, i + 1, h, size);
            }
            return root;
        }


        static void PrintInorder(Node root)
        {
            if (root == null)
                return;
            PrintInorder(root.left);
            Console.WriteLine(root.data + " ");
            PrintInorder(root.right);
        }
    }

    class Node
    {
        public int data;
        public Node left, right;

        public Node(int data)
        {
            this.data = data;
        }
    }
}

/*
 *  Impossible to create any binary tree, except it's a full binary tree, from pre-order and post-order traversals.
 *  
 * https://www.geeksforgeeks.org/full-and-complete-binary-tree-from-given-preorder-and-postorder-traversals/
 * 
 * 4 / 100
*/
