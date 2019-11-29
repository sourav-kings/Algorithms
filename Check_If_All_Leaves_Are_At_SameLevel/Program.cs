using System;
using System.Collections.Generic;

namespace Check_If_All_Leaves_Are_At_SameLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let us create the tree as shown in the example
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(12);
            tree.root.left = new Node(5);
            tree.root.left.left = new Node(3);
            tree.root.left.right = new Node(9);
            tree.root.left.left.left = new Node(1);
            tree.root.left.right.left = new Node(1);
            if (tree.Check_Iterative(tree.root))
                Console.WriteLine("Leaves are at same level");
            else
                Console.WriteLine("Leaves are not at same level");
        }
    }

    // Java program to check if all leaves are at same level
    class BinaryTree
    {
        internal Node root;
        Leaf mylevel = new Leaf();

        /* Recursive function which checks whether all leaves are at same 
           level */
        bool CheckUtil(Node node, int level, Leaf leafLevel)
        {
            // Base case
            if (node == null)
                return true;

            // If a leaf node is encountered
            if (node.left == null && node.right == null)
            {
                // When a leaf node is found first time
                if (leafLevel.leaflevel == 0)
                {
                    // Set first found leaf's level
                    leafLevel.leaflevel = level;
                    return true;
                }

                // If this is not first leaf node, compare its level with
                // first leaf's level
                return (level == leafLevel.leaflevel);
            }

            // If this node is not leaf, recursively check left and right 
            // subtrees
            return CheckUtil(node.left, level + 1, leafLevel)
                    && CheckUtil(node.right, level + 1, leafLevel);
        }

        /* The main function to check if all leafs are at same level.
           It mainly uses checkUtil() */
        internal bool Check_Recursive(Node node)
        {
            int level = 0;
            return CheckUtil(node, level, mylevel);
        }

        internal bool Check_Iterative(Node root)
        {
            if (root != null)
                return true;

            // create a queue for level order traversal
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            int result = int.MaxValue;
            int level = 0;

            // traverse until the queue is empty
            while (q.Count != 0)
            {
                int size = q.Count;
                level += 1;

                // traverse for complete level
                while (size > 0)
                {
                    Node temp = q.Peek();
                    q.Dequeue();

                    // check for left child
                    if (temp.left != null)
                    {
                        q.Enqueue(temp.left);

                        // if its leaf node
                        if (temp.left.right != null && temp.left.left != null)
                        {

                            // if it's first leaf node, then update result
                            if (result == int.MaxValue)
                                result = level;

                            // if it's not first leaf node, then compare 
                            // the level with level of previous leaf node
                            else if (result != level)
                                return false;
                        }
                    }

                    // check for right child
                    if (temp.right != null)
                    {
                        q.Enqueue(temp.right);

                        // if it's leaf node
                        if (temp.right.left != null && temp.right.right != null)

                            // if it's first leaf node till now, 
                            // then update the result
                            if (result == int.MaxValue)
                                result = level;

                            // if it is not the first leaf node, 
                            // then compare the level with level 
                            // of previous leaf node
                            else if (result != level)
                                return false;

                    }

                    size -= 1;
                }
            }

            return true;
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

    class Leaf
    {
        internal int leaflevel = 0;
    }
}

/*
 * https://www.geeksforgeeks.org/check-leaves-level/
 * 
 * 
 * Method 1 (Recursive)
 * 
 * The idea is to first find level of the leftmost leaf and store it in a variable leafLevel. 
 * Then compare level of all other leaves with leafLevel, if same, return true, else return false. 
 * We traverse the given Binary Tree in Preorder fashion. 
 * An argument leaflevel is passed to all calls. 
 * The value of leafLevel is initialized as 0 to indicate that the first leaf is not yet seen yet. 
 * The value is updated when we find first leaf. 
 * Level of subsequent leaves (in preorder) is compared with leafLevel.
 * 
 * 
 * 
 * Method 2 (Iterative)
 * 
 * The idea is to iteratively traverse the tree, and when you encounter the first leaf node, 
 * store it’s level in result variable, now whenever you encounter any leaf node, 
 * compare it’s level with previously stored result, if they are same then proceed for rest of the tree, 
 * else return false.
 */
