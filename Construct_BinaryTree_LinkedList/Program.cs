using System;
using System.Collections.Generic;

namespace Construct_BinaryTree_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.push(36); /* Last node of Linked List */
            tree.push(30);
            tree.push(25);
            tree.push(15);
            tree.push(12);
            tree.push(10); /* First node of Linked List */
            BinaryTreeNode node = tree.ConvertList2Binary(tree.root);

            Console.WriteLine("Inorder Traversal of the" +
                            " constructed Binary Tree is:");
            tree.InorderTraversal(node);
        }
    }

    class BinaryTree
    {
        ListNode head;
        internal BinaryTreeNode root;

        // Function to insert a node at the beginning of
        // the Linked List
        internal void push(int new_data)
        {
            // allocate node and assign data
            ListNode new_node = new ListNode(new_data);

            // link the old list off the new node
            new_node.next = head;

            // move the head to point to the new node
            head = new_node;
        }

        // converts a given linked list representing a 
        // complete binary tree into the linked 
        // representation of binary tree.
        internal BinaryTreeNode ConvertList2Binary(BinaryTreeNode node)
        {
            // queue to store the parent nodes
            Queue<BinaryTreeNode> q = new Queue<BinaryTreeNode>();

            // Base Case
            if (head == null)
            {
                node = null;
                return null;
            }

            // 1.) The first node is always the root node, and
            //     add it to the queue
            node = new BinaryTreeNode(head.data);
            q.Enqueue(node);

            // advance the pointer to the next node
            head = head.next;

            // until the end of linked list is reached, do the
            // following steps
            while (head != null)
            {
                // 2.a) take the parent node from the q and 
                //      remove it from q
                BinaryTreeNode parent = q.Peek();
                BinaryTreeNode pp = q.Dequeue();

                // 2.c) take next two nodes from the linked list.
                // We will add them as children of the current 
                // parent node in step 2.b. Push them into the
                // queue so that they will be parents to the 
                // future nodes
                BinaryTreeNode leftChild = null, rightChild = null;
                leftChild = new BinaryTreeNode(head.data);
                q.Enqueue(leftChild);
                head = head.next;
                if (head != null)
                {
                    rightChild = new BinaryTreeNode(head.data);
                    q.Enqueue(rightChild);
                    head = head.next;
                }

                // 2.b) assign the left and right children of
                //      parent
                parent.left = leftChild;
                parent.right = rightChild;
            }

            return node;
        }

        // Utility function to traverse the binary tree 
        // after conversion
        internal void InorderTraversal(BinaryTreeNode node)
        {
            if (node != null)
            {
                InorderTraversal(node.left);
                Console.Write(node.data + " ");
                InorderTraversal(node.right);
            }
        }

    }

    // A linked list node
    class ListNode
    {
        internal int data;
        internal ListNode next;
        internal ListNode(int d)
        {
            data = d;
            next = null;
        }
    }

    // A binary tree node
    class BinaryTreeNode
    {
        internal int data;
        internal BinaryTreeNode left, right = null;
        internal BinaryTreeNode(int data)
        {
            this.data = data;
            left = right = null;
        }
    }
}
