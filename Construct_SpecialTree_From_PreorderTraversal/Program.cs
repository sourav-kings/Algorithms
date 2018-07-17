using System;

namespace Construct_SpecialTree_From_PreorderTraversal
{
    class Program
    {
        static Index myindex = new Index();
        static int[] pre;
        static char[] preLN;
        //static int myindex = 0;

        static void Main(string[] args)
        {
            pre = new int[] { 10, 30, 20, 5, 15 };
            preLN = new char[] { 'N', 'N', 'L', 'L', 'L' };

            // construct the above tree
            Node mynode = ConstructTree(myindex, null);
            //Node mynode = ConstructTree(0, null);

            // Test the constructed tree
            Console.WriteLine("Following is Inorder Traversal of the"
                                          + "Constructed Binary Tree: ");
            PrintInorder(mynode);
        }

        /* 
           A recursive function to create a Binary Tree from given pre[]
           preLN[] arrays. The function returns root of tree. index_ptr is used
           to update index values in recursive calls. index must be initially
           passed as 0 
        */
        static Node ConstructTree(Index index_ptr, Node temp)
        {
            // store the current value of index in pre[]
            int index = index_ptr.index;

            // Base Case: All nodes are constructed
            if (index == pre.Length)
                return null;

            // Allocate memory for this node and increment index for
            // subsequent recursive calls
            temp = new Node(pre[index]);
            (index_ptr.index)++;

            // If this is an internal node, construct left and right subtrees 
            // and link the subtrees
            if (preLN[index] == 'N')
            {
                temp.left = ConstructTree(index_ptr, temp.left);
                temp.right = ConstructTree(index_ptr, temp.right);
            }

            return temp;
        }
        //static Node ConstructTree(int index_ptr, Node temp)
        //{
        //    // store the current value of index in pre[]
        //    //int index = index_ptr.index;

        //    // Base Case: All nodes are constructed
        //    if (index_ptr == pre.Length)
        //        return null;

        //    // Allocate memory for this node and increment index for
        //    // subsequent recursive calls
        //    temp = new Node(pre[index_ptr]);
        //    (index_ptr)++;

        //    // If this is an internal node, construct left and right subtrees 
        //    // and link the subtrees
        //    if (preLN[index_ptr] == 'N')
        //    {
        //        temp.left = ConstructTree(index_ptr, temp.left);
        //        temp.right = ConstructTree(index_ptr, temp.right);
        //    }

        //    return temp;
        //}

        /* This function is used only for testing */
        static void PrintInorder(Node node)
        {
            if (node == null)
                return;

            /* first recur on left child */
            PrintInorder(node.left);

            /* then print the data of node */
            Console.Write(node.data + " ");

            /* now recur on right child */
            PrintInorder(node.right);
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

    class Index
    {
        public int index = 0;
    }
}
