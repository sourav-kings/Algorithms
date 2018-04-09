using System;
using System.Collections.Generic;

namespace JumpingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 40;
            Graph g = new Graph(x);
            g.PrintJumping();
        }
    }

    class Graph
    {
        private int x;
        private Queue<int> q;

        public Graph(int x)
        {
            this.x = x;
        }
        public void PrintJumping()
        {
            Console.Write(0 + " - ");
            for (int i = 1; i <= 9 && i <= x; i++)
                Bfs(i);
        }

        private void Bfs(int num)
        {
            q = new Queue<int>();
            q.Enqueue(num);

            while (q.Count != 0)
            {
                num = q.Dequeue();
                if (num <= x)
                {
                    Console.Write(num + " - ");
                    int last_dig = num % 10;

                    // If last digit is 0, append next digit only
                    if (last_dig == 0)
                        q.Enqueue((num * 10) + (last_dig + 1));


                    // If last digit is 9, append previous digit only
                    else if (last_dig == 9)
                        q.Enqueue((num * 10) + (last_dig - 1));

                    // If last digit is neighter 0 nor 9, append both 
                    // previous and next digits
                    else
                    {
                        q.Enqueue((num * 10) + (last_dig - 1));
                        q.Enqueue((num * 10) + (last_dig + 1));
                    }
                }
            }
        }
    }
}
