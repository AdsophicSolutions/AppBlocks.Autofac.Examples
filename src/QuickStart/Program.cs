using System;

namespace QuickStart
{
    class Program
    {
        static void Main(string[] args)
        {
            RunServiceExample1();
        }

        private static void RunServiceExample1()
        {
            new ServiceExample1.Example().Run();
        }
    }
}
