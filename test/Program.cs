using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CheckList();
        }

        private static void CheckList()
        {
            List<string> names = new List<string> { "sourav", "rahul", null, "xavier" };

            names.ForEach(x =>
            {
                if (String.IsNullOrEmpty(x))
                    x = "NA";
            });
        }
    }
}
