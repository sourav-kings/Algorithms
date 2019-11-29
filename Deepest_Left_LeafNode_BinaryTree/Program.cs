using System;

namespace Deepest_Left_LeafNode_BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.right.left = new Node(5);
            tree.root.right.right = new Node(6);
            tree.root.right.left.right = new Node(7);
            tree.root.right.right.right = new Node(8);
            tree.root.right.left.right.left = new Node(9);
            tree.root.right.right.right.right = new Node(10);

            tree.DeepestLeftLeaf(tree.root);
            if (tree.result != null)
                Console.WriteLine("The deepest left child" +
                                   " is " + tree.result.data);
            else
                Console.WriteLine("There is no left leaf in" +
                                   " the given tree");
        }
    }

    class BinaryTree
    {
        internal Node root;

        // Node to store resultant
        // node after left traversal
        internal Node result;

        // A utility function to
        // find deepest leaf node.
        // lvl: level of current node.
        // isLeft: A bool indicate
        // that this node is left child
        void DeepestLeftLeafUtil(Node node,
                                 int lvl,
                                 Level level,
                                 bool isLeft)
        {
            // Base case
            if (node == null)
                return;

            // Update result if this node
            // is left leaf and its level
            // is more than the maxl level
            // of the current result
            if (isLeft != false &&
                node.left == null &&
                node.right == null &&
                lvl > level.maxlevel)
            {
                result = node;
                level.maxlevel = lvl;
            }

            // Recur for left and right subtrees
            DeepestLeftLeafUtil(node.left, lvl + 1,
                                level, true);
            DeepestLeftLeafUtil(node.right, lvl + 1,
                                level, false);
        }

        // A wrapper over deepestLeftLeafUtil().
        internal void DeepestLeftLeaf(Node node)
        {
            Level level = new Level();
            DeepestLeftLeafUtil(node, 0, level, false);
        }
    }


    class Node
    {
        internal int data;
        internal Node left, right;

        // Constructor
        internal Node(int data)
        {
            this.data = data;
            left = right = null;
        }
    }

    class Level
    {
        // maxlevel: gives the
        // value of level of
        // maximum left leaf
        internal int maxlevel = 0;
    }
}

/*
 * https://www.geeksforgeeks.org/deepest-left-leaf-node-in-a-binary-tree/
 * 
 * The idea is to recursively traverse the given binary tree and while traversing, 
 * maintain “level” which will store the current node’s level in the tree. 
 * If current node is left leaf, 
 * then check if its level is more than the level of deepest left leaf seen so far. 
 * If level is more then update the result. 
 * If current node is not leaf, then recursively find maximum depth in left and right subtrees, 
 * and return maximum of the two depths.
 * 
 * Time Complexity: The function does a simple traversal of the tree, so the complexity is O(n).
 */
