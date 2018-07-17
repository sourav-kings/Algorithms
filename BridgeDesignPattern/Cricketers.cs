using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeDesignPattern
{
    class Cricketers : Celebrities
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public int MyProperty { get; set; }

        protected override void Display()
        {
            throw new NotImplementedException();
        }
    }
}
