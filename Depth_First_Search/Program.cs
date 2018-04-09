using System;
using System.Collections.Generic;

namespace Depth_First_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Gives wrong result for DAG
             * for example take use case of tolpological sort
             * https://www.geeksforgeeks.org/topological-sorting/
             */
            Graph g = new Graph(5);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);
            g.AddEdge(0, 4);//for test

            Console.WriteLine("Following is Depth First Traversal ");

            g.DFS(2);
        }
    }

    class Graph
    {
        int V;
        Queue<int>[] adj;
        bool[] visited;

        public Graph(int n)
        {
            this.V = n;
            this.adj = new Queue<int>[V];
            this.visited = new bool[V];

            for (int i = 0; i < V; i++)
                adj[i] = new Queue<int>();
        }

        public void AddEdge(int u, int v)
        {
            adj[u].Enqueue(v);
        }

        public void DFS(int v)
        {
            visited[v] = true;
            Console.Write(v + " ");

            foreach (var i in adj[v])
                if (!visited[i])
                    DFS(i);
        }

    }
}

/*
 * Created - March 2018
 * (2.3 / 234)
 * 
 * Depth First Traversals is Pre-order by default.
 * References
 * https://www.geeksforgeeks.org/depth-first-search-or-dfs-for-a-graph/
 * Introduction To Algorithms - CLRS
 * 
 * 
 * 
 * DFS of a graph produces a single tree if all vertices are reachable from the DFS starting point. 
 * Otherwise DFS produces a forest. 
 * So DFS of a graph with only one SCC always produces a tree.
 */
