using System;

namespace Connect_Nodes_At_SameLevel_ConstantExtraSpace
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            root = new Node(10);
            root.left = new Node(8);
            root.right = new Node(2);
            root.left.left = new Node(3);
            root.right.right = new Node(90);

            // Populates nextRight pointer in all nodes
            //ConnectRecursive(root);
            ConnectIterative(root);


            // Let us check the values of nextRight pointers
            int a = root.nextRight != null ?
                              root.nextRight.data : -1;
            int b = root.left.nextRight != null ?
                              root.left.nextRight.data : -1;
            int c = root.right.nextRight != null ?
                                root.right.nextRight.data : -1;
            int d = root.left.left.nextRight != null ?
                            root.left.left.nextRight.data : -1;
            int e = root.right.right.nextRight != null ?
                            root.right.right.nextRight.data : -1;

            // Now lets print the values
            Console.WriteLine("Following are populated nextRight pointers in "
                    + " the tree(-1 is printed if there is no nextRight)");
            Console.WriteLine("nextRight of " + root.data + " is " + a);
            Console.WriteLine("nextRight of " + root.left.data + " is " + b);
            Console.WriteLine("nextRight of " + root.right.data + " is " + c);
            Console.WriteLine("nextRight of " + root.left.left.data +
                                                                  " is " + d);
            Console.WriteLine("nextRight of " + root.right.right.data +
                                                                  " is " + e);

        }



        /* Set next right of all descendents of p. This function makes sure that
       nextRight of nodes ar level i is set before level i+1 nodes. */
        static void ConnectRecursive(Node p)
        {
            // Base case
            if (p == null)
                return;

            /* Before setting nextRight of left and right children, set nextRight
               of children of other nodes at same level (because we can access 
               children of other nodes using p's nextRight only) */
            if (p.nextRight != null)
                ConnectRecursive(p.nextRight);

            /* Set the nextRight pointer for p's left child */
            if (p.left != null)
            {
                if (p.right != null)
                {
                    p.left.nextRight = p.right;
                    p.right.nextRight = GetNextRight(p);
                }
                else
                    p.left.nextRight = GetNextRight(p);

                /* Recursively call for next level nodes.  Note that we call only
                 for left child. The call for left child will call for right child */
                ConnectRecursive(p.left);
            }

            /* If left child is NULL then first node of next level will either be
             p->right or getNextRight(p) */
            else if (p.right != null)
            {
                p.right.nextRight = GetNextRight(p);
                ConnectRecursive(p.right);
            }
            else
                ConnectRecursive(GetNextRight(p));
        }


        /* Sets nextRight of all nodes of a tree with root as p */
        static void ConnectIterative(Node p)
        {
            Node temp = null;

            if (p == null)
                return;

            // Set nextRight for root
            p.nextRight = null;

            // set nextRight of all levels one by one
            while (p != null)
            {
                Node q = p;

                /* Connect all childrem nodes of p and children nodes of all other
                   nodes at same level as p */
                while (q != null)
                {
                    // Set the nextRight pointer for p's left child
                    if (q.left != null)
                    {

                        // If q has right child, then right child is nextRight of
                        // p and we also need to set nextRight of right child
                        if (q.right != null)
                            q.left.nextRight = q.right;
                        else
                            q.left.nextRight = GetNextRight(q);
                    }

                    if (q.right != null)
                        q.right.nextRight = GetNextRight(q);

                    // Set nextRight for other nodes in pre order fashion
                    q = q.nextRight;
                }

                // start from the first node of next level
                if (p.left != null)
                    p = p.left;
                else if (p.right != null)
                    p = p.right;
                else
                    p = GetNextRight(p);
            }
        }



        /* This function returns the leftmost child of nodes at the same
           level as p. This function is used to getNExt right of p's right child
           If right child of p is NULL then this can also be used for 
           the left child */
        static Node GetNextRight(Node p)
        {
            Node temp = p.nextRight;

            /* Traverse nodes at p's level and find and return
             the first node's first child */
            while (temp != null)
            {
                if (temp.left != null)
                    return temp.left;
                if (temp.right != null)
                    return temp.right;
                temp = temp.nextRight;
            }

            // If all the nodes at p's level are leaf nodes then return NULL
            return null;
        }
    }

    // A binary tree node
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


/*
 * 4.5 (300)
 * We discussed two different approaches to do it in the previous post. 
 * https://www.geeksforgeeks.org/connect-nodes-at-same-level/
 * The auxiliary space required in both of those approaches is not constant. 
 * Also, the method 2 discussed there only works for complete Binary Tree.

In this post, we will first modify the method 2 to make it work for all kind of trees. 
After that, we will remove recursion from this method so that the extra space becomes constant.
 */
