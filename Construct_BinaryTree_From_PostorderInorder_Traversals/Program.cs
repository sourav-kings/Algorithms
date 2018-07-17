using System;

namespace Construct_BinaryTree_From_PostorderInorder_Traversals
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            int[] inOrder = new int[] { 4, 8, 2, 5, 1, 6, 3, 7 };
            int[] postOrder = new int[] { 8, 4, 5, 2, 6, 7, 3, 1 };
            int n = inOrder.Length;
            Node root = tree.BuildTree(inOrder, postOrder, n);
            Console.WriteLine("Preorder of the constructed tree : ");
            tree.PreOrder(root);
        }
    }

    class BinaryTree
    {
        /* Recursive function to construct binary of size n
           from  Inorder traversal in[] and Preorder traversal
           post[].  Initial values of inStrt and inEnd should
           be 0 and n -1.  The function doesn't do any error
           checking for cases where inorder and postorder
           do not form a tree */
        internal Node BuildUtil(int[] inOrder, int[] postOrder, int inStrt, int inEnd, Index pIndex)
        {
            // Base case
            if (inStrt > inEnd)
                return null;

            /* Pick current node from Preorder traversal using
               postIndex and decrement postIndex */
            Node node = new Node(postOrder[pIndex.index]);
            (pIndex.index)--;

            /* If this node has no children then return */
            if (inStrt == inEnd)
                return node;

            /* Else find the index of this node in Inorder
               traversal */
            int iIndex = Search(inOrder, inStrt, inEnd, node.data);

            /* Using index in Inorder traversal, construct left and
               right subtress */
            node.right = BuildUtil(inOrder, postOrder, iIndex + 1, inEnd, pIndex);
            node.left = BuildUtil(inOrder, postOrder, inStrt, iIndex - 1, pIndex);

            return node;
        }

        // This function mainly initializes index of root
        // and calls buildUtil()
        internal Node BuildTree(int[] inOrder, int[] postOrder, int n)
        {
            Index pIndex = new Index();
            pIndex.index = n - 1;
            return BuildUtil(inOrder, postOrder, 0, n - 1, pIndex);
        }

        /* Function to find index of value in arr[start...end]
           The function assumes that value is postsent in in[] */
        int Search(int[] arr, int strt, int end, int value)
        {
            int i;
            for (i = strt; i <= end; i++)
            {
                if (arr[i] == value)
                    break;
            }
            return i;
        }

        /* This funtcion is here just to test  */
        internal void PreOrder(Node node)
        {
            if (node == null)
                return;
            Console.Write(node.data + " --> ");
            PreOrder(node.left);
            PreOrder(node.right);
        }
    }


    class Node
    {
        internal int data;
        internal Node left, right;

        internal Node(int data)
        {
            this.data = data;
            left = right = null;
        }
    }

    // Class Index created to implement pass by reference of Index
    class Index
    {
        internal int index;
    }
}
/*
 * https://www.geeksforgeeks.org/construct-a-binary-tree-from-postorder-and-inorder/
 */
