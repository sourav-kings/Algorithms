using System;

namespace Correct_BST_By_Swapping_TwoNodes_2_Working
{
    class BinaryTree
    {
        Node first, middle, last, prev;

        static void Main(string[] args)
        {
            Node root = new Node(6);
            root.left = new Node(10);
            root.right = new Node(2);
            root.left.left = new Node(1);
            root.left.right = new Node(3);
            root.right.right = new Node(12);
            root.right.left = new Node(7);

            BinaryTree tree = new BinaryTree();
            Console.WriteLine("InCorrect Bst Inorder traversal :");
            tree.InOrder(root);
            tree.CorrectBST(root);
            Console.WriteLine();
            Console.WriteLine("Corrected Bst Inorder traversal");
            tree.InOrder(root);
        }

        // A function to fix a given BST where two nodes are swapped.  This
        // function uses correctBSTUtil() to find out two nodes and swaps the
        // nodes to fix the BST
        void CorrectBST(Node root)
        {
            // Initialize pointers needed for correctBSTUtil()
            first = middle = last = prev = null;

            // Set the poiters to find out two nodes
            CorrectBSTUtil(root);

            // Fix (or correct) the tree
            if (first != null && last != null)
            {
                Swap(ref first.data, ref last.data);
            }
            else if (first != null && middle != null)
            {
                Swap(ref first.data, ref middle.data);
            } // Adjacent nodes swapped


            // else nodes have not been swapped, passed tree is really BST.
        }

        // This function does inorder traversal to find out the two swapped nodes.
        // It sets three pointers, first, middle and last.  If the swapped nodes are
        // adjacent to each other, then first and middle contain the resultant nodes
        // Else, first and last contain the resultant nodes
        void CorrectBSTUtil(Node root)
        {
            if (root != null)
            {
                // Recur for the Left subtree
                CorrectBSTUtil(root.left);

                // If this node is smaller than the previous node, it's violating
                // the BST rule.
                if (prev != null && root.data < prev.data)
                {
                    // If this is first violation, mark these two nodes as
                    // 'first' and 'middle'
                    if (first == null)
                    {
                        first = prev;
                        middle = root;
                    }

                    // If this is second violation, mark this node as last
                    else
                        last = root;
                }

                // Mark this node as previous
                prev = root;

                // Recur for the Right subtree
                CorrectBSTUtil(root.right);
            }
        }

        void InOrder(Node node)
        {
            if (node == null)
                return;

            InOrder(node.left);
            Console.Write(node.data + "  ");
            InOrder(node.right);
        }

        // A utility function to swap two integers
        void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
    }

    class Node
    {

        public int data;
        public Node left, right;

        public Node(int d)
        {
            data = d;
            left = right = null;
        }
    }
}
