using System;

namespace Diameter_BinaryTree
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);

            // Console.WriteLine("The diameter of given binary tree is : " + Diameter());

            Console.WriteLine("The diameter of given binary tree is : " + DiameterFaster());
        }


        /* A wrapper over diameter(Node root) */
        static int Diameter()
        {
            return Diameter(root);
        }

        /* Method to calculate the diameter and return it to main */
        static int Diameter(Node root)
        {
            /* base case if tree is empty */
            if (root == null)
                return 0;

            /* get the height of left and right sub trees */
            int lheight = Height(root.left);
            int rheight = Height(root.right);

            /* get the diameter of left and right subtrees */
            int ldiameter = Diameter(root.left);
            int rdiameter = Diameter(root.right);

            /* Return max of following three 
              1) Diameter of left subtree 
             2) Diameter of right subtree 
             3) Height of left subtree + height of right subtree + 1 */
            return Math.Max(lheight + rheight + 1,
                            Math.Max(ldiameter, rdiameter));

        }





        /* A wrapper over diameter(Node root) */
        static int DiameterFaster()
        {
            Height height = new Height();
            return Diameter(root, height);
        }


        /* define height =0 globally and  call diameterOpt(root,height) from main */
        static int Diameter(Node root, Height height)
        {
            /* lh --> Height of left subtree 
               rh --> Height of right subtree */
            Height lh = new Height(), rh = new Height();

            if (root == null)
            {
                height.h = 0;
                return 0; /* diameter is also 0 */
            }

            /* ldiameter  --> diameter of left subtree 
               rdiameter  --> Diameter of right subtree */
            /* Get the heights of left and right subtrees in lh and rh 
             And store the returned values in ldiameter and ldiameter */
            int ldiameter = Diameter(root.left, lh);
            int rdiameter = Diameter(root.right, rh);

            /* Height of current node is max of heights of left and 
             right subtrees plus 1*/
            height.h = Math.Max(lh.h, rh.h) + 1;

            return Math.Max(lh.h + rh.h + 1, Math.Max(ldiameter, rdiameter));
        }


        /*The function Compute the "height" of a tree. Height is the 
          number f nodes along the longest path from the root node 
          down to the farthest leaf node.*/
        static int Height(Node node)
        {
            /* base case tree is empty */
            if (node == null)
                return 0;

            /* If tree is not empty then height = 1 + max of left 
               height and right heights */
            return (1 + Math.Max(Height(node.left), Height(node.right)));
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

    // A utility class to pass heigh object 
    class Height
    {
        public int h;
    }
}



/*
 * 
 * https://www.geeksforgeeks.org/diameter-of-a-binary-tree/
 * 
 * 3 (450)
 * 
 */
