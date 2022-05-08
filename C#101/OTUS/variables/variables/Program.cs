using System;

namespace variables
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var x1 = 2;
            var x2 = 4;
            var x3 = 3;
            var x4 = 2;
            var result = (x1 + x2) / x3 + x4;

            Console.WriteLine(result);

        }
    }
}
