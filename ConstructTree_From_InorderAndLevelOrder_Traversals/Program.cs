using System;

namespace ConstructTree_From_InorderAndLevelOrder_Traversals
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            int[] in1 = new int[] { 4, 8, 10, 12, 14, 20, 22 };
            int[] level = new int[] { 20, 8, 22, 4, 12, 10, 14 };
            int n = in1.Length;
            Node node = BuildTree(in1, level);

            /* Let us test the built tree by printing Inorder traversal */
            Console.WriteLine("Inorder traversal of the constructed tree is ");
            PrintInorder(node);
        }

        static Node BuildTree(int[] in1, int[] level)
        {
            Node startnode = null;
            return ConstructTree(startnode, level, in1, 0, in1.Length - 1);
        }

        static Node ConstructTree(Node startNode, int[] levelOrder, int[] inOrder,
            int inStart, int inEnd)
        {

            // if start index is more than end index
            if (inStart > inEnd)
                return null;

            if (inStart == inEnd)
                return new Node(inOrder[inStart]);

            bool found = false;
            int index = 0;

            // it represents the index in inOrder array of element that
            // appear first in levelOrder array.
            for (int i = 0; i < levelOrder.Length - 1; i++)
            {
                int data = levelOrder[i];
                for (int j = inStart; j < inEnd; j++)
                {
                    if (data == inOrder[j])
                    {
                        startNode = new Node(data);
                        index = j;
                        found = true;
                        break;
                    }
                }
                if (found == true)
                    break;
            }

            //elements present before index are part of left child of startNode.
            //elements present after index are part of right child of startNode.
            startNode.SetLeft(ConstructTree(startNode, levelOrder, inOrder,
                                                        inStart, index - 1));
            startNode.SetRight(ConstructTree(startNode, levelOrder, inOrder,
                                                         index + 1, inEnd));

            return startNode;
        }

        /* Utility function to print inorder traversal of binary tree */
        static void PrintInorder(Node node)
        {
            if (node == null)
                return;
            PrintInorder(node.left);
            Console.WriteLine(node.data + " ");
            PrintInorder(node.right);
        }
    }

    // A binary tree node
    class Node
    {
        public int data;
        public Node left, right;

        public Node(int item)
        {
            data = item;
            left = right = null;
        }

        public void SetLeft(Node left)
        {
            this.left = left;
        }

        public void SetRight(Node right)
        {
            this.right = right;
        }
    }
}

/*
 * Can be further optimized to O(n^2) using hash maps. 
The recursion is simpler too.

Here's the code: http://ideone.com/bOEUNp
 */
