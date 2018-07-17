using System;

namespace Count_SmallerElements_On_RightSide
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = new int[]{12, 10, 5, 4,
            //                2, 20, 6, 1, 0, 2};
            //int n = arr.Length;
            //int[] low = new int[n];

            //ConstructLowerArray(arr, low, n);
            //PrintArray(low, n);



            int[] arr = { 10, 6, 15, 20, 30, 5, 7 };
            int n = arr.Length;

            int[] low = new int[n];

            ConstructLowerArray_UsingAVL(arr, low, n);

            Console.WriteLine("Following is the constructed smaller count array");
            PrintArray(low, n);
        }

        static void ConstructLowerArray(int[] arr,
                int[] countSmaller, int n)
        {
            int i, j;

            // initialize all the counts in
            // countSmaller array as 0
            for (i = 0; i < n; i++)
                countSmaller[i] = 0;

            for (i = 0; i < n; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[i])
                        countSmaller[i]++;
                }
            }
        }


        // The following function updates the countSmaller array to contain count of
        // smaller elements on right side.
        static void ConstructLowerArray_UsingAVL(int[] arr, int[] countSmaller, int n)
        {
            int i, j;
            Node root = null;

            // initialize all the counts in countSmaller array as 0
            for (i = 0; i < n; i++)
                countSmaller[i] = 0;

            // Starting from rightmost element, insert all elements one by one in
            // an AVL tree and get the count of smaller elements
            for (i = n - 1; i >= 0; i--)
            {
                root = Insert(root, arr[i], countSmaller[i]);
            }
        }

        // Inserts a new key to the tree rotted with node. Also, updates *count
        // to contain count of smaller elements for the new key
        static Node Insert(Node node, int key, int count)
        {
            /* 1.  Perform the normal BST rotation */
            if (node == null)
                return (NewNode(key));

            if (key < node.key)
                node.left = Insert(node.left, key, count);
            else
            {
                node.right = Insert(node.right, key, count);

                // UPDATE COUNT OF SMALLER ELEMENTS FOR KEY
                count = count + Size(node.left) + 1;
            }


            /* 2. Update Height and Size of this ancestor node */
            node.Height = Math.Max(Height(node.left), Height(node.right)) + 1;
            node.Size = Size(node.left) + Size(node.right) + 1;

            /* 3. Get the balance factor of this ancestor node to check whether
               this node became unbalanced */
            int balance = GetBalance(node);

            // If this node becomes unbalanced, then there are 4 cases

            // Left Left Case
            if (balance > 1 && key < node.left.key)
                return RightRotate(node);

            // Right Right Case
            if (balance < -1 && key > node.right.key)
                return LeftRotate(node);

            // Left Right Case
            if (balance > 1 && key > node.left.key)
            {
                node.left = LeftRotate(node.left);
                return RightRotate(node);
            }

            // Right Left Case
            if (balance < -1 && key < node.right.key)
            {
                node.right = RightRotate(node.right);
                return LeftRotate(node);
            }

            /* return the (unchanged) node pointer */
            return node;
        }

        // Get Balance factor of node N
        static int GetBalance(Node N)
        {
            if (N == null)
                return 0;
            return Height(N.left) - Height(N.right);
        }

        // A utility function to get Height of the tree rooted with N
        static int Height(Node N)
        {
            if (N == null)
                return 0;
            return N.Height;
        }

        // A utility function to Size of the tree of rooted with N
        static int Size(Node N)
        {
            if (N == null)
                return 0;
            return N.Size;
        }

        /* Helper function that allocates a new node with the given key and
            null left and right pointers. */
        static Node NewNode(int key)
        {
            Node node = new Node
            {
                key = key,
                left = null,
                right = null,
                Height = 1,  // new node is initially added at leaf
                Size = 1
            };
            return (node);
        }

        // A utility function to right rotate subtree rooted with y
        static Node RightRotate(Node y)
        {
            Node x = y.left;
            Node T2 = x.right;

            // Perform rotation
            x.right = y;
            y.left = T2;

            // Update heights
            y.Height = Math.Max(Height(y.left), Height(y.right)) + 1;
            x.Height = Math.Max(Height(x.left), Height(x.right)) + 1;

            // Update sizes
            y.Size = Size(y.left) + Size(y.right) + 1;
            x.Size = Size(x.left) + Size(x.right) + 1;

            // Return new root
            return x;
        }

        // A utility function to left rotate subtree rooted with x
        static Node LeftRotate(Node x)
        {
            Node y = x.right;
            Node T2 = y.left;

            // Perform rotation
            y.left = x;
            x.right = T2;

            //  Update heights
            x.Height = Math.Max(Height(x.left), Height(x.right)) + 1;
            y.Height = Math.Max(Height(y.left), Height(y.right)) + 1;

            // Update sizes
            x.Size = Size(x.left) + Size(x.right) + 1;
            y.Size = Size(y.left) + Size(y.right) + 1;

            // Return new root
            return y;
        }


        /* Utility function that prints out
        an array on a line */
        static void PrintArray(int[] arr, int Size)
        {
            int i;
            for (i = 0; i < Size; i++)
                Console.Write(arr[i] + " ");

            Console.WriteLine("");
        }
    }
}

// An AVL tree node
class Node
{
    public int key;
    public Node left;
    public Node right;
    public int Height;
    public int Size; // Size of the tree rooted with this node
};






/*
 * https://www.geeksforgeeks.org/count-smaller-elements-on-right-side/
 * 
 * Count smaller elements on right side
    Write a function to count number of smaller elements on right of each element in an array. 
    Given an unsorted array arr[] of distinct integers, construct another array countSmaller[] 
    such that countSmaller[i] contains count of smaller elements on right side of each element arr[i] in array.

    Examples:

    Input:   arr[] =  {12, 1, 2, 3, 0, 11, 4}
    Output:  countSmaller[]  =  {6, 1, 1, 1, 0, 1, 0} 

    (Corner Cases)
    Input:   arr[] =  {5, 4, 3, 2, 1}
    Output:  countSmaller[]  =  {4, 3, 2, 1, 0} 

    Input:   arr[] =  {1, 2, 3, 4, 5}
    Output:  countSmaller[]  =  {0, 0, 0, 0, 0}


            z
           / \
          y
         /
        x
       /
      w
 */
