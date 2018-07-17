using System;

namespace BridgeDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

/*
 * 
 * 
celebs 1-3 ----> highlights A-C
    Our project

platforms 1-3 ----> scheduler A-C
    https://sourcemaking.com/design_patterns/bridge

platforms 1-3 ----> I/O operations A-C
    https://howtodoinjava.com/design-patterns/structural/bridge-design-pattern/

datasets 1-3 ----> print formats A-C
    https://app.pluralsight.com/player?course=patterns-library&author=john-sonmez&name=design-patterns-bridge&clip=5&mode=live
    IMP - Record the hi-level understanding under 2 min for with and without Bridge patterns.
    BEST EXAMPLE - same understanding can be used for SCHEDULER example as well.
 */
