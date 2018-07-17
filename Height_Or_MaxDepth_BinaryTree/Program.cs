using System;

namespace Height_Or_MaxDepth_BinaryTree
{
    class Program
    {
        /* Driver program to test above functions */
        public static void Main(String[] args)
        {
            BinaryTree tree = new BinaryTree();

            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            Console.WriteLine("Height of tree is : " +
                                          tree.MaxDepth(tree.root));
        }
    }

    class BinaryTree
    {
        internal Node root;

        /* Compute the "maxDepth" of a tree -- the number of 
           nodes along the longest path from the root node 
           down to the farthest leaf node.*/
        internal int MaxDepth(Node node)
        {
            if (node == null)
                return 0;
            
            int lDepth = MaxDepth(node.left);
            int rDepth = MaxDepth(node.right);

            return (lDepth > rDepth) ? (lDepth+1) : (rDepth+1);
            
        }
    }

    // A binary tree node
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
