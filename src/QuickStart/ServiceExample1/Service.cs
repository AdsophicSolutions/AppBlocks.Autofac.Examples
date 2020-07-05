using AppBlocks.Autofac.Support;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickStart.ServiceExample1
{
    [AppBlocksService]
    public class Service : IService
    {
        public void Run()
        {
            Console.WriteLine("Service run successfully");
        }
    }
}
