using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance_Between_TwoNodes_BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.left = new Node(6);
            root.right.right = new Node(7);
            root.right.left.right = new Node(8);

            //findDist(4, 5);
            //findDist(4, 6);
            //findDist(3, 4);
            //findDist(2, 4);
            //findDist(8, 5);

            int n1 = 4, n2 =5;
            Console.WriteLine("Distance for " + n1 + ", " + n2 + " is : " + FindDist(root, n1, n2, 0, new FlagVisited()));

            n1 = 4; n2 = 6;
            Console.WriteLine("Distance for " + n1 + ", " + n2 + " is : " + FindDist(root, n1, n2, 0, new FlagVisited())); ;

            n1 = 3; n2 = 4;
            Console.WriteLine("Distance for " + n1 + ", " + n2 + " is : " + FindDist(root, n1, n2, 0, new FlagVisited())); ;

            n1 = 2; n2 = 4;
            Console.WriteLine("Distance for " + n1 + ", " + n2 + " is : " + FindDist(root, n1, n2, 0, new FlagVisited())); ;

            n1 = 8; n2 = 5;
            Console.WriteLine("Distance for " + n1 + ", " + n2 + " is : " + FindDist(root, n1, n2, 0, new FlagVisited())); ;
        }


        static int FindDist(Node node, int n1, int n2, int dist, FlagVisited flag)
        {
            // Base case
            if (node == null)
                return 0;

            FlagVisited leftF = new FlagVisited();
            FlagVisited rightF = new FlagVisited();

            // Look for keys in left and right subtrees
            int leftDist = FindDist(node.left, n1, n2, dist, leftF);
            int rightDist = FindDist(node.right, n1, n2, dist, rightF);

            if ((leftF.visited || rightF.visited)  ||
                (leftDist >= 1 && rightDist >= 1)  || 
                ((leftDist >= 1 || rightDist >= 1) && (node.data == n1 || node.data == n2)))
            {
                flag.visited = true;
                return leftDist + rightDist;
            }

            if ((leftDist >= 1 || rightDist >= 1) || (node.data == n1 || node.data == n2))
            {
                dist++;
                return leftDist + rightDist + dist;
            }

            return leftDist + rightDist;
        }
    }

    class Node
    {
        public int data;
        public Node left, right;

        public Node(int data)
        {
            this.data = data;
        }
    }

    class FlagVisited
    {
        public bool visited = false;
    }
}


//http://www.geeksforgeeks.org/find-distance-two-given-nodes/
//http://code.geeksforgeeks.org/leM4IG

//Average Difficulty : 3.8/5.0
//Based on 55 vote(s)

//Time Complexity: Time complexity of the above solution is O(n)

/*
 * 
 * The distance between two nodes can be obtained in terms of lowest common ancestor. Following is the formula.

    Dist(n1, n2) = Dist(root, n1) + Dist(root, n2) - 2*Dist(root, lca) 
    'n1' and 'n2' are the two given keys
    'root' is root of given Binary Tree.
    'lca' is lowest common ancestor of n1 and n2
    Dist(n1, n2) is the distance between n1 and n2.
    Following is the implementation of above approach. 

    The implementation is adopted from last code provided in Lowest Common Ancestor Post.
 */


/*
 * 
 * ALGO::
 * 
 * 0. 
 * 1. Create a Flag class with bool isVisited flag.
 * 2. Call function with root, two given values, distance = 0, and new Flag instance.
 * 3. Check base case of node.
 * 4. Set LeftVisitedFlag and RightVisitedFlag as two new isntances of Flag class.
 * 5. Set leftDistance and rightDistance as Recur function with left or right node (resp.), two given values, 
 *      distance variable, and left or right Flag instance.
 * 6. If :-
 *              either of trees is visited
 *          OR, both distances are more than 0.
 *          OR, either of distances is more than 0 OR either of given values is equal to node data
 *    Then :-
 *          Set flag parameter as true.
 *          Return sum of left & right distances.
 * 8. If :-
 *              either of distances is more than 0.
 *          OR, either of given values is equal to node data
 *    Then :-
 *          Increment distance parameter by 1.
 *          Return sum of left & right distances & distance parameter.
 * 10. Return sum of left & right distances.
 */
