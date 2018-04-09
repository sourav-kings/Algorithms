using System;

namespace Kruskals_MinimumSpanningTree
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Let us create following weighted graph
                   10
                0------1
                |  \   |
               6|  5\  |15
                |    \ |
                2------3
                   4       
            */

            int V = 4;  // Number of vertices in graph
            int E = 5;  // Number of edges in graph
            Graph graph = new Graph(V, E);

            // add edge 0-1
            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;
            graph.edge[0].weight = 10;

            // add edge 0-2
            graph.edge[1].src = 0;
            graph.edge[1].dest = 2;
            graph.edge[1].weight = 6;

            // add edge 0-3
            graph.edge[2].src = 0;
            graph.edge[2].dest = 3;
            graph.edge[2].weight = 5;

            // add edge 1-3
            graph.edge[3].src = 1;
            graph.edge[3].dest = 3;
            graph.edge[3].weight = 15;

            // add edge 2-3
            graph.edge[4].src = 2;
            graph.edge[4].dest = 3;
            graph.edge[4].weight = 4;

            graph.KruskalMST();
        }
    }

    public class Graph
    {
        // A class to represent a graph edge
        public class Edge: IComparable<Edge>
        {
            public int src, dest, weight;

            // Comparator function used for sorting edges 
            // based on their weight
            public int CompareTo(Edge compareEdge)
            {
                return this.weight - compareEdge.weight;
            }
        };

        // A class to represent a subset for union-find
        class Subset
        {
            public int parent, rank;
        };

        int V, E;    // V-> no. of vertices & E->no.of edges
        public Edge[] edge; // collection of all edges

        // Creates a graph with V vertices and E edges
        public Graph(int v, int e)
        {
            V = v;
            E = e;
            edge = new Edge[E];
            for (int i = 0; i < e; ++i)
                edge[i] = new Edge();
        }

        // A utility function to find set of an element i
        // (uses path compression technique)
        int Find(Subset[] subsets, int i)
        {
            // find root and make root as parent of i (path compression)
            if (subsets[i].parent != i)
                subsets[i].parent = Find(subsets, subsets[i].parent);

            return subsets[i].parent;
        }

        // A function that does union of two sets of x and y
        // (uses union by rank)
        void Union(Subset[] subsets, int x, int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);

            // Attach smaller rank tree under root of high rank tree
            // (Union by Rank)
            if (subsets[xroot].rank < subsets[yroot].rank)
                subsets[xroot].parent = yroot;
            else if (subsets[xroot].rank > subsets[yroot].rank)
                subsets[yroot].parent = xroot;

            // If ranks are same, then make one as root and increment
            // its rank by one
            else
            {
                subsets[yroot].parent = xroot;
                subsets[xroot].rank++;
            }
        }

        // The main function to construct MST using Kruskal's algorithm
        public void KruskalMST()
        {
            Edge[] result = new Edge[V];  // Tnis will store the resultant MST
            int e = 0;  // An index variable, used for result[]
            int i = 0;  // An index variable, used for sorted edges
            for (i = 0; i < V; ++i)
                result[i] = new Edge();

            // Step 1:  Sort all the edges in non-decreasing order of their
            // weight.  If we are not allowed to change the given graph, we
            // can create a copy of array of edges
            Array.Sort(edge);

            // Allocate memory for creating V ssubsets
            Subset[] subsets = new Subset[V];
            for (i = 0; i < V; ++i)
                subsets[i] = new Subset();

            // Create V subsets with single elements
            for (int v = 0; v < V; ++v)
            {
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }

            i = 0;  // Index used to pick next edge

            // Number of edges to be taken is equal to V-1
            while (e < V - 1)
            {
                // Step 2: Pick the smallest edge. And increment 
                // the index for next iteration
                Edge next_edge = new Edge();
                next_edge = edge[i++];

                int x = Find(subsets, next_edge.src);
                int y = Find(subsets, next_edge.dest);

                // If including this edge does't cause cycle,
                // include it in result and increment the index 
                // of result for next edge
                if (x != y)
                {
                    result[e++] = next_edge;
                    Union(subsets, x, y);
                }
                // Else discard the next_edge
            }

            // print the contents of result[] to display
            // the built MST
            Console.WriteLine("Following are the edges in the constructed MST");
            for (i = 0; i < e; ++i)
                Console.WriteLine(result[i].src + " -- " +
                       result[i].dest + " == " + result[i].weight);
        }
    }
}


/*
 * Created - March 2018
 * (3.5 out of 5 - rated by 161 users)
 * References
 * https://www.geeksforgeeks.org/greedy-algorithms-set-2-kruskals-minimum-spanning-tree-mst/
 * Introduction To Algorithms - CLRS
 * 
 * 
 * Time Complexity: O(ElogE) or O(ElogV). Sorting of edges takes O(ELogE) time. 
 * After sorting, we iterate through all edges and apply find-union algorithm. 
 * The find and union operations can take atmost O(LogV) time. 
 * So overall complexity is O(ELogE + ELogV) time. 
 * The value of E can be atmost O(V2), so O(LogV) are O(LogE) same. 
 * Therefore, overall time complexity is O(ElogE) or O(ElogV)
 */
