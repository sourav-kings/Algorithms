using System;

namespace Nodes_At_K_Distance_From_LeafNode
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            /* Let us construct the tree shown in above diagram */
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(6);
            tree.root.right.right = new Node(7);
            tree.root.right.left.right = new Node(8);

            Console.WriteLine(" Nodes at distance 2 are :");
            tree.PrintKDistantfromLeaf(tree.root, 2);
        }
    }

    class BinaryTree
    {
        internal Node root;
        int[] path;
        bool[] visited;
        int pathLen;
        int k;

        /* This function prints all nodes that are distance k from a leaf node
         path[] --> Store ancestors of a node
         visited[] --> Stores true if a node is printed as output.  A node may
         be k distance away from many leaves, we want to print it once */
        internal void PrintKDistantfromLeafUtil(Node node, int pathLen)
        {
            // Base case
            if (node == null)
                return;

            /* append this Node to the path array */
            path[pathLen] = node.data;
            visited[pathLen] = false;
            pathLen++;

            /* it's a leaf, so print the ancestor at distance k only
             if the ancestor is not already printed  */
            if (node.left == null && node.right == null
               && pathLen - k - 1 >= 0 && visited[pathLen - k - 1] == false)
            {
                Console.WriteLine(path[pathLen - k - 1] + " ");
                visited[pathLen - k - 1] = true;
                return;
            }

            /* If not leaf node, recur for left and right subtrees */
            PrintKDistantfromLeafUtil(node.left, pathLen);
            PrintKDistantfromLeafUtil(node.right, pathLen);
        }

        /* Given a binary tree and a nuber k, print all nodes that are k
         distant from a leaf*/
        internal void PrintKDistantfromLeaf(Node node, int dist)
        {
            path = new int[1000];
            visited = new bool[1000];
            pathLen = 0;
            k = dist;
            PrintKDistantfromLeafUtil(node, pathLen);
        }
    }

    class Node
    {
        internal int data;
        internal Node left, right;

        internal Node(int item)
        {
            data = item;
            left = right = null;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/print-nodes-distance-k-leaf-node/
 */
