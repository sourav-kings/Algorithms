using Construct_BinaryTree_From_InorderPreorderTraversals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construct_BinaryTree_From_InorderPreorderTraversals
{
    class Program
    {
        //static Node root;
        static int preIndex = 0;

        static void Main(string[] args)
        {
            //char[] inOrder = new char[] { 'D', 'B', 'E', 'A', 'F', 'C' };
            //char[] preOrder = new char[] { 'A', 'B', 'D', 'E', 'C', 'F' };
            //int len = inOrder.Length;
            //Node<char> root = BuildTree<char>(inOrder, preOrder, 0, len - 1);//O(n * n)
            //Console.WriteLine("Inorder traversal of constructed tree is : ");
            //PrintInorder<char>(root);

            //Console.WriteLine();
            //preIndex = 0;


            //int[] inOrder2 = new int[] { 4, 2, 5, 1, 7, 3 };
            //int[] preOrder2 = new int[] { 1, 2, 4, 5, 3, 7 };
            //int len2 = inOrder2.Length;
            //Node<int> root2 = BuildTree<int>(inOrder2, preOrder2, 0, len2 - 1);
            ////TreeNode root2 = buildTreeFaster(preOrder2, inOrder2);
            //Console.WriteLine("Faster Inorder traversal of constructed tree is : ");
            //PrintInorder<int>(root2);


            int[] inOrder3 = new int[] { 9, 8, 4, 2, 10, 5, 10, 1, 6, 3, 13, 12, 7 };
            int[] preOrder3 = new int[] { 1, 2, 4, 8, 9, 5, 10, 10, 3, 6, 7, 12, 13 };
            int len = inOrder3.Length;

            TreeNode root3 = BuildTree_Stack(preOrder3, inOrder3);
            Console.WriteLine("Stack - Inorder traversal of constructed tree is : ");
            PrintInorder3(root3);
        }


        /* Recursive function to construct binary of size len from
           Inorder traversal inOrder[] and Preorder traversal pre[].
           Initial values of inStrt and inEnd should be 0 and len -1.  

           The function doesn't do any error checking for cases where 
           inorder and preorder do not form a tree */
        static Node<T> BuildTree<T>(T[] inOrder, T[] pre, int inStrt, int inEnd)
        {
            if (inStrt > inEnd)
                return null;

            /* Pick current node from Preorder traversal using preIndex
               and increment preIndex */
            Node<T> tNode = new Node<T>(pre[preIndex++]);

            /* If this node has no children then return */
            if (inStrt == inEnd)
                return tNode;

            /* Else find the index of this node inOrder Inorder traversal */
            int inIndex = Search<T>(inOrder, inStrt, inEnd, tNode.data);

            /* Using index inOrder Inorder traversal, construct left and
               right subtress */
            tNode.left = BuildTree(inOrder, pre, inStrt, inIndex - 1);
            tNode.right = BuildTree(inOrder, pre, inIndex + 1, inEnd);

            return tNode;
        }

        /* UTILITY FUNCTIONS */

        /* Function to find index of value inOrder arr[start...end]
         The function assumes that value is present inOrder inOrder[] */
        static int Search<T>(T[] arr, int strt, int end, T value)
        {
            int i;
            for (i = strt; i <= end; i++)
            {
                if (EqualityComparer<T>.Default.Equals(arr[i], value))
                    return i;
            }
            return i;
        }

        /* This funtcion is here just to test buildTree() */
        static void PrintInorder<T>(Node<T> node)
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







        static TreeNode buildTreeFaster(int[] preorder, int[] inorder)
        {
            if (preorder == null || inorder == null)
                return null;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++) //map inorder index for each node to map index faster 
                map[inorder[i]] = i;

            return helper(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1, map);
        }
        static TreeNode helper(int[] preorder, int preL, int preR, int[] inorder, int inL, int inR, Dictionary<int, int> map)
        {
            if (preL > preR || inL > inR)
                return null;
            TreeNode root = new TreeNode(preorder[preL]); //according to the preorder, the first must be the root for current sub tree
            int index = map[root.data]; //use hashmap to find index instead of linear search
            root.left = helper(preorder, preL + 1, index - inL + preL, inorder, inL, index - 1, map);
            root.right = helper(preorder, preL + index - inL + 1, preR, inorder, index + 1, inR, map);
            return root;
        }
        static void printInorder2(TreeNode node)
        {
            if (node == null)
                return;

            /* first recur on left child */
            printInorder2(node.left);

            /* then print the data of node */
            Console.Write(node.data + " ");

            /* now recur on right child */
            printInorder2(node.right);
        }






        static HashSet<TreeNode> set = new HashSet<TreeNode>();
        static Stack<TreeNode> stack = new Stack<TreeNode>();
        // Function to build tree using given traversal
        static TreeNode BuildTree_Stack(int[] preorder, int[] inorder)
        {
            TreeNode root = null;
            for (int pre1 = 0, in1 = 0; pre1 < preorder.Length;)
            {

                TreeNode node = null;
                do
                {
                    node = new TreeNode(preorder[pre1]);
                    if (root == null)
                    {
                        root = node;
                    }
                    if (stack.Any())
                    {
                        if (set.Contains(stack.Peek()))
                        {
                            set.Remove(stack.Peek());
                            stack.Pop().right = node;
                        }
                        else
                        {
                            stack.Peek().left = node;
                        }
                    }
                    stack.Push(node);
                } while (preorder[pre1++] != inorder[in1] && pre1 < preorder.Length);

                node = null;
                while (stack.Any() && in1 < inorder.Length && stack.Peek().data == inorder[in1])
                {
                    node = stack.Pop();
                    in1++;
                }

                if (node != null)
                {
                    set.Add(node);
                    stack.Push(node);

                }

            }

            return root;
        }
        // Function to print tree in Inorder
        static void PrintInorder3(TreeNode node)
        {
            if (node == null)
                return;

            /* first recur on left child */
            PrintInorder3(node.left);

            /* then print the data of node */
            Console.Write(node.data + " ");


            /* now recur on right child */
            PrintInorder3(node.right);
        }

    }


    /* A binary tree node has data, pointer to left child
       and a pointer to right child */
    class Node<T>
    {
        public T data;
        public Node<T> left, right;

        public Node(T item)
        {
            this.data = item;
            left = right = null;
        }

        //public Node(char item)
        //{
        //    data = item;
        //    left = right = null;
        //}
    }

    class TreeNode
    {
        public int data;
        public TreeNode left, right;

        public TreeNode(int item)
        {
            data = item;
            left = right = null;
        }
    }

}


//http://www.geeksforgeeks.org/construct-tree-from-given-inorder-and-preorder-traversal/
/*
 * Time Complexity - Recursive
 * 
 * O(n^2). Worst case occurs when tree is left skewed. 
 * Example Preorder and Inorder traversals for worst case are {A, B, C, D} and {D, C, B, A}.
 */




//http://blog.welkinlan.com/2014/11/08/construct-binary-tree-from-preorder-and-inorder-traversal/#comment-3200

//Average Difficulty : 3.4/5.0
//Based on 131 vote(s)

/*
1) Pick an element from Preorder. Increment a Preorder Index Variable (preIndex in below code) to pick next element in next recursive call.
2) Create a new tree node tNode with the data as picked element.
3) Find the picked element’s index in Inorder. Let the index be inIndex.
4) Call buildTree for elements before inIndex and make the built tree as left subtree of tNode.
5) Call buildTree for elements after inIndex and make the built tree as right subtree of tNode.
6) return tNode.
 */

/*
 * 
 * 
 *      Let us consider the below traversals:

        Inorder sequence: D B E A F C
        Preorder sequence: A B D E C F

        In a Preorder sequence, leftmost element is the root of the tree. So we know ‘A’ is root for given sequences. 
        By searching ‘A’ in Inorder sequence, we can find out all elements on left side of ‘A’ are in left subtree and elements on right are in right subtree. 
        
        So we know below structure now.

                             A
                           /   \
                         /       \
                       D B E     F C

        We recursively follow above steps and get the following tree.

                             A
                           /   \
                         /       \
                        B         C
                       / \        /
                     /     \    /
                    D       E  F



 * 
 * 
 * ALGO::
 * 
 * O(n * n) method::
 * 
 * Create a new node with first PreOrder value.
 * 
 * Check if start == end. If yes, return this node.
 * 
 * Search this new node in InOrder array and get index.
 * 
 * Set this new new node's left children as Recur with start and index - 1.
 * 
 * Set this new new node's right children as Recur with index + 1 and end.
 * 
 * Return this new node
 * 
 */
