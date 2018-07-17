using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeDesignPattern
{
    abstract class Celebrities
    {
        protected readonly IHighlighter highlighter;

        protected Celebrities(IHighlighter highlighter)
        {
            this.highlighter = highlighter;
        }

        abstract protected void Display();
    }
}
