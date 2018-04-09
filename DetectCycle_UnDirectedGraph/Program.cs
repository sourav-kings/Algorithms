using System;
using System.Collections.Generic;

namespace DetectCycle_UnDirectedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a graph given in the above diagram
            Graph g1 = new Graph(5);
            g1.AddEdge(1, 0);
            g1.AddEdge(0, 2);
            g1.AddEdge(2, 0);
            g1.AddEdge(0, 3);
            g1.AddEdge(3, 4);
            if (g1.IsCyclic(0, -1))
                Console.WriteLine("Graph contains cycle");
            else
                Console.WriteLine("Graph doesn't contains cycle");

            Graph g2 = new Graph(3);
            g2.AddEdge(0, 1);
            g2.AddEdge(1, 2);
            if (g2.IsCyclic(0, -1))
                Console.WriteLine("Graph contains cycle");
            else
                Console.WriteLine("Graph doesn't contains cycle");
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
            adj[v].Enqueue(u);
        }

        public bool IsCyclic(int v, int parent)
        {
            if (!visited[v])
            {
                visited[v] = true;

                foreach (var i in adj[v])
                {
                    if (!visited[i])
                    {
                        if (IsCyclic(i, v))
                            return true;
                    }
                    else
                    {
                        if (i != parent)
                            return true;
                    }
                }
            }
            return false;
        }
    }
}

/*
 * https://www.geeksforgeeks.org/detect-cycle-undirected-graph/
 * 
 * (2.8 / 105)
 */
