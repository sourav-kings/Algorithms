using System;
using System.Collections.Generic;

namespace LongestPath_Directed_AcyclicGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            int V = 6;
            Graph g = new Graph(V);

            g.addEdge(0, 1, 5);
            g.addEdge(0, 2, 3);
            g.addEdge(1, 3, 6);
            g.addEdge(1, 2, 2);
            g.addEdge(2, 4, 4);
            g.addEdge(2, 5, 2);
            g.addEdge(2, 3, 7);
            g.addEdge(3, 5, 1);
            g.addEdge(3, 4, -1);
            g.addEdge(4, 5, -2);

            Console.WriteLine("Graph:");
            g.printGraph();

            int s = 1;
            Console.WriteLine("\nsource:" + s);
            Console.WriteLine("Distances:");
            g.printLongestDistances(s);
        }
    }

    class Graph
    {
        int V;
        MyLinkedList[] lists;

        public Graph(int V)
        {
            this.V = V;
            this.lists = new MyLinkedList[V];

            for (int i = 0; i < V; i++)
                lists[i] = new MyLinkedList();
        }

        public void addEdge(int u, int v, int weight)
        {
            Node node = new Node();
            node.data = v;
            node.weight = weight;
            lists[u].AddFirst(node);
        }

        public void printGraph()
        {
            int i = 0;
            foreach (MyLinkedList l in lists)
            {
                Console.Write(i++ + " : ");
                foreach (Node node in l)
                    Console.Write(node.data + "(" + node.weight + ") ");
                Console.WriteLine();
            }
        }

        void topologicalSortUtil(int u, bool[] visited, LinkedList<int> res)
        {
            visited[u] = true;

            foreach (Node node in lists[u])
            {
                if (!visited[node.data])
                    topologicalSortUtil(node.data, visited, res);
            }

            res.AddFirst(u);
        }

        LinkedList<int> topologicalSort()
        {
            bool[] visited = new bool[V];
            LinkedList<int> res = new LinkedList<int>();

            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                    topologicalSortUtil(i, visited, res);
            }

            return res;

        }

        public void printLongestDistances(int s)
        {
            int[] dist = new int[V];
            int[] parent = new int[V];

            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MinValue;
                parent[i] = -1;
            }

            dist[s] = 0;

            LinkedList<int> res = topologicalSort();

            foreach (int node in res)
            {
                foreach (Node neighbour in lists[node])
                {
                    if (dist[neighbour.data] < dist[node] + neighbour.weight)
                    {
                        dist[neighbour.data] = dist[node] + neighbour.weight;
                        parent[neighbour.data] = node;
                    }
                }
            }

            for (int i = 0; i < V; i++)
            {
                if (dist[i] == int.MinValue)
                    Console.Write(i + " : INF\tPath : ");
                else
                    Console.Write(i + " : " + dist[i] + "\tPath : ");

                Stack<int> st = new Stack<int>();
                int j = i;
                while (parent[j] != -1)
                {
                    st.Push(j);
                    j = parent[j];
                }

                if (dist[i] != int.MinValue)
                    st.Push(s);

                while (st.Count != 0)
                    Console.Write(st.Pop() + " ");
                Console.WriteLine();
            }
        }
    }

    class MyLinkedList : LinkedList<Node>
    {
    }

    class Node
    {
        public int data;
        public int weight;
    }
}
