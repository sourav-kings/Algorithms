using System;
using System.Collections.Generic;

namespace DirectedAcyclicGraphs_SingleSourceShortestPaths
{
    /* NOT WORKING CORRECTLY */

    class Program
    {
        static void Main(string[] args)
        {
            // Create a graph given in the above diagram.  Here vertex
            // numbers are 0, 1, 2, 3, 4, 5 with following mappings:
            // 0=r, 1=s, 2=t, 3=x, 4=y, 5=z
            Graph g = new Graph(6);
            g.AddEdge(0, 1, 5);
            g.AddEdge(0, 2, 3);
            g.AddEdge(1, 3, 6);
            g.AddEdge(1, 2, 2);
            g.AddEdge(2, 4, 4);
            g.AddEdge(2, 5, 2);
            g.AddEdge(2, 3, 7);
            g.AddEdge(3, 4, -1);
            g.AddEdge(4, 5, -2);

            int s = 1;
            Console.WriteLine("Following are shortest distances " +
                                "from source " + s);
            g.ShortestPath(s);
        }
    }



    // Class to represent graph as an adjcency list of
    // nodes of type AdjListNode
    class Graph
    {
        int V;
        AdjacencyLists[] lists;
        const int INF = int.MaxValue;


        public Graph(int V)
        {
            this.V = V;
            this.lists = new AdjacencyLists[V];

            for (int i = 0; i < V; i++)
                lists[i] = new AdjacencyLists();
        }


        public void AddEdge(int u, int v, int weight)
        {
            Node node = new Node();
            node.data = v;
            node.weight = weight;
            lists[u].Enqueue(node);
        }

        // A recursive function used by shortestPath.
        // See below link for details
        void TopologicalSortUtil(int v, bool[] visited, Queue<int> res)
        {
            // Mark the current node as visited.
            visited[v] = true;

            // Recur for all the vertices adjacent to this vertex
            IEnumerator<Node> i = lists[v].GetEnumerator();
            while (i.MoveNext())
            {
                Node node = i.Current;
                if (!visited[node.data])
                    TopologicalSortUtil(node.data, visited, res);
            }
            // Push current vertex to stack which stores result
            res.Enqueue(v);
        }

        // The function to find shortest paths from given vertex. It
        // uses recursive topologicalSortUtil() to get topological
        // sorting of given graph.
        public void ShortestPath(int s)
        {
            Queue<int> res  = new Queue<int>();
            int[] dist = new int[V];


            // Mark all the vertices as not visited
            Boolean[] visited = new Boolean[V];
            for (int i = 0; i < V; i++)
                visited[i] = false;


            // Call the recursive helper function to store Topological
            // Sort starting from all vertices one by one
            for (int i = 0; i < V; i++)
                if (visited[i] == false)
                    TopologicalSortUtil(i, visited, res);


            // Initialize distances to all vertices as infinite and
            // distance to source as 0
            for (int i = 0; i < V; i++)
                dist[i] = INF;
            dist[s] = 0;


            // Process vertices in topological order
            while (res.Count != 0)
            {
                // Get the next vertex from topological order
                int u = res.Dequeue();

                // Update distances of all adjacent vertices
                if (dist[u] != INF)
                {
                    IEnumerator<Node> i = lists[u].GetEnumerator();
                    while (i.MoveNext())
                    {
                        Node n = i.Current;
                        if (dist[n.data] > dist[u] + n.weight)
                            dist[n.data] = dist[u] + n.weight;
                    }
                }
            }

            // Print the calculated shortest distances
            for (int i = 0; i < V; i++)
            {
                if (dist[i] == INF)
                    Console.WriteLine("INF ");
                else
                    Console.WriteLine(dist[i] + " ");
            }
        }
    }

    class AdjacencyLists : Queue<Node>
    {
    }

    class Node
    {
        public int data;
        public int weight;
    }
}

/*
 * (3.5 / 41)
 * 
 * CLRS - page 655
 * https://www.geeksforgeeks.org/shortest-path-for-directed-acyclic-graphs/
 * 
 * 
 * https://www.geeksforgeeks.org/shortest-path-for-directed-acyclic-graphs/
 * For a general weighted graph, we can calculate single source shortest distances in O(VE) time using Bellman–Ford Algorithm. 
 * For a graph with no negative weights, we can do better and calculate single source shortest distances in O(E + VLogV) time using Dijkstra’s algorithm. 
 * Can we do even better for Directed Acyclic Graph (DAG)? We can calculate single source shortest distances in O(V+E) time for DAGs. 
 * The idea is to use Topological Sorting.
 */
