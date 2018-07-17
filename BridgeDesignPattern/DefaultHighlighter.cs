using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeDesignPattern
{
    class DefaultHighlighter : IHighlighter
    {
        public string Highlight(Celebrities celeb)
        {
            Console.Write(celeb.Name)
        }
    }
}
