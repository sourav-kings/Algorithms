using System;

namespace Sum_Of_AllNos_Formed_From_Root_To_Leaf_Paths
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(6);
            tree.root.left = new Node(3);
            tree.root.right = new Node(5);
            tree.root.right.right = new Node(4);
            tree.root.left.left = new Node(2);
            tree.root.left.right = new Node(5);
            tree.root.left.right.right = new Node(4);
            tree.root.left.right.left = new Node(7);

            Console.WriteLine("Sum of all paths is " +
                                     tree.TreePathsSum(tree.root));
        }
    }


    class BinaryTree
    {
        internal Node root;

        // Returns sum of all root to leaf paths. The first parameter is 
        // root of current subtree, the second parameter is value of the  
        // number formed by nodes from root to this node
        int TreePathsSumUtil(Node node, int val)
        {
            // Base case
            if (node == null)
                return 0;

            // Update val
            val = (val * 10 + node.data);

            // if current node is leaf, return the current value of val
            if (node.left == null && node.right == null)
                return val;

            // recur sum of values for left and right subtree
            return TreePathsSumUtil(node.left, val)
                    + TreePathsSumUtil(node.right, val);
        }

        // A wrapper function over treePathsSumUtil()
        internal int TreePathsSum(Node node)
        {
            // Pass the initial value as 0 as there is nothing above root
            return TreePathsSumUtil(node, 0);
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
 * https://www.geeksforgeeks.org/sum-numbers-formed-root-leaf-paths/
 */
