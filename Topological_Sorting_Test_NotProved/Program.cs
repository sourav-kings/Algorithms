using System;
using System.Collections.Generic;

namespace Topological_Sorting_Test_Proved
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(6);
            g.AddEdge(5, 2);
            g.AddEdge(5, 0);
            g.AddEdge(4, 0);
            g.AddEdge(4, 1);
            g.AddEdge(2, 3);
            g.AddEdge(3, 1);

            Console.WriteLine("Following is a Topological " +
                               "sort of the given graph");
            g.TopologicalSort();
            //g.Print();
        }
    }

    class Graph
    {
        int V;
        Queue<int>[] adj;
        bool[] visited;
        Stack<int> stack;

        public Graph(int n)
        {
            this.V = n;
            this.adj = new Queue<int>[V];
            this.visited = new bool[V];
            this.stack = new Stack<int>();

            for (int i = 0; i < V; i++)
                adj[i] = new Queue<int>();
        }

        public void AddEdge(int u, int v)
        {
            adj[u].Enqueue(v);
        }

        public void TopologicalSort()
        {
            for (int v = 0; v < V; v++)
                if (!visited[v])
                    TopologicalSortUtil(v);

            while (stack.Count != 0)
                Console.Write(stack.Pop() + " ");
        }


        public void TopologicalSortUtil(int v)
        {
            visited[v] = true;

            foreach (var i in adj[v])
                if (!visited[i])
                    TopologicalSortUtil(i);

            stack.Push(v);
        }
    }
}
