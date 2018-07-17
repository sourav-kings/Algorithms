using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeDesignPattern
{
    class Actors : Celebrities
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public int MyProperty { get; set; }

        public Actors(IHighlighter highlighter) :  base(highlighter)
        {

        }

        protected override void Display()
        {
            Console.WriteLine(highlighter.Highlight(this));
        }
    }
}
