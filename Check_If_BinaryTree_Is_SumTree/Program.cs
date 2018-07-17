using System;

namespace Check_If_BinaryTree_Is_SumTree
{
    class Program
    {
        static Node root;

        static void Main(string[] args)
        {
            root = new Node(26);
            root.left = new Node(10);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(6);
            root.right.right = new Node(3);

            if (IsSumTree_Faster(root) != 0)
                Console.WriteLine("The given tree is a sum tree");
            else
                Console.WriteLine("The given tree is not a sum tree");
        }

        /* returns 1 if sum property holds for the given
            node and both of its children */
        static int IsSumTree(Node node)
        {
            int ls, rs;

            /* If node is NULL or it's a leaf node then
               return true */
            if ((node == null) || (node.left == null && node.right == null))
                return 1;

            /* Get sum of nodes in left and right subtrees */
            ls = Sum(node.left);
            rs = Sum(node.right);

            /* if the node and both of its children satisfy the
               property return 1 else 0*/
            if ((node.data == ls + rs) && (IsSumTree(node.left) != 0)
                    && (IsSumTree(node.right)) != 0)
                return 1;

            return 0;
        }

        /* A utility function to get the sum of values in tree with root
 as root */
        static int Sum(Node node)
        {
            if (node == null)
                return 0;
            return Sum(node.left) + node.data + Sum(node.right);
        }



        /* returns 1 if SumTree property holds for the given
   tree */
        static int IsSumTree_Faster(Node node)
        {
            int ls; // for sum of nodes in left subtree
            int rs; // for sum of nodes in right subtree

            /* If node is NULL or it's a leaf node then
             return true */
            if (node == null || IsLeaf(node) == 1)
                return 1;

            if (IsSumTree_Faster(node.left) != 0 && IsSumTree_Faster(node.right) != 0)
            {
                // Get the sum of nodes in left subtree
                if (node.left == null)
                    ls = 0;
                else if (IsLeaf(node.left) != 0)
                    ls = node.left.data;
                else
                    ls = 2 * (node.left.data);

                // Get the sum of nodes in right subtree
                if (node.right == null)
                    rs = 0;
                else if (IsLeaf(node.right) != 0)
                    rs = node.right.data;
                else
                    rs = 2 * (node.right.data);

                /* If root's data is equal to sum of nodes in left
                   and right subtrees then return 1 else return 0*/
                if ((node.data == rs + ls))
                    return 1;
                else
                    return 0;
            }

            return 0;
        }

        /* Utility function to check if the given node is leaf or not */
        static int IsLeaf(Node node)
        {
            if (node == null)
                return 0;
            if (node.left == null && node.right == null)
                return 1;
            return 0;
        }
    }

    /* A binary tree node has data, left child and right child */
    class Node
    {
        public int data;
        public Node left, right, nextRight;

        public Node(int item)
        {
            data = item;
            left = right = nextRight = null;
        }
    }
}
