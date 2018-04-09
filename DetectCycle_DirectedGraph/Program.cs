using System;
using System.Collections.Generic;

namespace DetectCycle_DirectedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a graph given in the above diagram
            Graph g = new Graph(4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            if (g.IsCyclic2(0))
                Console.WriteLine("Graph contains cycle");
            else
                Console.WriteLine("Graph doesn't contain cycle");
        }
    }
    class Graph
    {
        int V;
        Queue<int>[] adj;
        bool[] visited;
        bool[] recStack;

        public Graph(int n)
        {
            this.V = n;
            this.adj = new Queue<int>[V];
            this.visited = new bool[V];
            this.recStack = new bool[V];

            for (int i = 0; i < V; i++)
                adj[i] = new Queue<int>();
        }

        public void AddEdge(int u, int v)
        {
            adj[u].Enqueue(v);
        }

        public bool IsCyclic2(int v)
        {
            if (!visited[v])
            {
                visited[v] = true;
                recStack[v] = true;


                foreach (var i in adj[v])
                {
                    if (!visited[i])
                    {
                        if (IsCyclic2(i))
                            return true;
                    }
                    else
                    {
                        if (recStack[v])
                            return true;
                    }
                }
            }
            recStack[v] = false;
            return false;
        }
    }
}


/*
 * https://www.geeksforgeeks.org/detect-cycle-in-a-graph/
 * 
 * (2.9 / 192)
 * Time Complexity of this method is same as time complexity of DFS traversal which is O(V+E).
 * 
 */
