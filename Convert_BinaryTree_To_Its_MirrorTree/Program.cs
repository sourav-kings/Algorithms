
using System;
using System.Collections.Generic;

namespace Convert_BinaryTree_To_Its_MirrorTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = null;

            /* Constructing tree given in the above figure
                   1
                 /  \
                3    2
                    / \
                   5   4   
            */
            root = new Node(1);
            root.left = new Node(3);
            root.right = new Node(2);
            root.right.left = new Node(5);
            root.right.right = new Node(4);


            Console.WriteLine("Following is Inorder Traversal of original Binary Tree: \n");
            PrintInorder(root);
            //3 1 5 2 4

            // convert Binary Tree to its Mirror Tree
            //Mirror(root);
            Mirror_Iterative(root);


            Console.WriteLine("Following is Inorder Traversal of its Mirror Tree: \n");
            PrintInorder(root);
            //
        }

        private static Node Mirror(Node node)
        {
            if (node == null)
                return node;

            /* do the subtrees */
            Node left = Mirror(node.left);
            Node right = Mirror(node.right);

            /* swap the left and right pointers */
            node.left = right;
            node.right = left;

            return node;
        }

        private static void Mirror_Iterative(Node root)
        {
            if (root == null)
                return;

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            // Do BFS. While doing BFS, keep swapping
            // left and right children
            while (q.Count != 0)
            {
                // pop top node from queue
                Node curr = q.Peek();
                q.Dequeue();

                // swap left child with right child
                //Swap(curr.left, curr.right);
                Node temp = curr.left;
                curr.left = curr.right;
                curr.right = temp;

                // push left and right children
                if (curr.left != null)
                    q.Enqueue(curr.left);
                if (curr.right != null)
                    q.Enqueue(curr.right);
            }
        }

        private static void Swap(Node x, Node y)
        {
            Node temp = x;
            x = y;
            y = temp;
        }


        /* Utility function to print inorder traversal of Binary Tree */
        private static void PrintInorder(Node node)
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

        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }

}
