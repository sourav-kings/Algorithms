using System;
//In testing phase - NOT PROVEN TO WORK


namespace Largest_BST_In_BinaryTree_Test
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

            Console.WriteLine("Size of the largest BST is:- " + FindLargestBST(root));
        }

        static int FindLargestBST(Node root)
        {
            Node largestBST = null, child = null;
            int maxNodes = int.MinValue;
            return FindLargestBST(root, int.MinValue, int.MaxValue, maxNodes, largestBST, child);
        }

        private static int FindLargestBST(Node p, int min, int max, int maxNodes, Node largestBST, Node child)
        {
            if (p == null) return 0;

            if (min < p.data && p.data < max)
            {
                int leftNodes = FindLargestBST(p.left, min, p.data, maxNodes, largestBST, child);
                Node leftChild = (leftNodes == 0) ? null : child;

                int rightNodes = FindLargestBST(p.right, p.data, max, maxNodes, largestBST, child);
                Node rightChild = (rightNodes == 0) ? null : child;

                // create a copy of the current node and 
                // assign its left and right child.
                Node parent = new Node(p.data);
                parent.left = leftChild;
                parent.right = rightChild;
                // pass the parent as the child to the above tree.
                child = parent;
                int totalNodes = leftNodes + rightNodes + 1;
                if (totalNodes > maxNodes)
                {
                    maxNodes = totalNodes;
                    largestBST = parent;
                }
                return totalNodes;
            }
            else
            {
                // include this node breaks the BST constraint,
                // so treat this node as an entirely new tree and 
                // check if a larger BST exist in this tree
                FindLargestBST(p, int.MinValue, int.MaxValue, maxNodes, largestBST, child);
                // must return 0 to exclude this node
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
}

//https://articles.leetcode.com/largest-binary-search-tree-bst-in_22/

//https://www.geeksforgeeks.org/find-the-largest-subtree-in-a-tree-that-is-also-a-bst/
//https://www.geeksforgeeks.org/largest-bst-binary-tree-set-2/