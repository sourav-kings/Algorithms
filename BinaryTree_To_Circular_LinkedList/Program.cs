using System;

namespace BinaryTree_To_Circular_LinkedList
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            root = new Node(10);
            root.left = new Node(12);
            root.right = new Node(15);
            root.left.left = new Node(25);
            root.left.right = new Node(30);
            root.right.left = new Node(36);

            // head refers to the head of the Link List
            Node head = BTreeToCList(root);

            // Display the Circular LinkedList
            Display(head);
        }


        // Method converts a tree to a circular
        // Link List and then returns the head
        // of the Link List
        private static Node BTreeToCList(Node root)
        {
            if (root == null)
                return null;

            // Recursively convert left and right subtrees
            Node left = BTreeToCList(root.left);
            Node right = BTreeToCList(root.right);

            // Make a circular linked list of single node
            // (or root). To do so, make the right and
            // left pointers of this node point to itself
            root.left = root.right = root;

            // Step 1 (concatenate the left list with the list 
            //         with single node, i.e., current node)
            // Step 2 (concatenate the returned list with the
            //         right List)
            return Concatenate(Concatenate(left, root), right);
        }


        // concatenate both the lists and returns the head
        // of the List
        private static Node Concatenate(Node leftList, Node rightList)
        {
            // If either of the list is empty, then
            // return the other list
            if (leftList == null)
                return rightList;
            if (rightList == null)
                return leftList;

            // Store the last Node of left List
            Node leftLast = leftList.left;

            // Store the last Node of right List
            Node rightLast = rightList.left;

            // Connect the last node of Left List
            // with the first Node of the right List
            leftLast.right = rightList;
            rightList.left = leftLast;

            // left of first node refers to
            // the last node in the list
            leftList.left = rightLast;

            // Right of last node refers to the first
            // node of the List
            rightLast.right = leftList;

            // Return the Head of the List
            return leftList;
        }


        // Display Circular Link List
        private static void Display(Node head)
        {
            Console.WriteLine("Circular Linked List is :");
            Node itr = head;
            do
            {
                Console.Write(value: itr.data + " ");
                itr = itr.right;
            }
            while (itr != head);
            Console.WriteLine();
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
}
