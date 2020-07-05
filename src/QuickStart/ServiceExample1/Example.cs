using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickStart.ServiceExample1
{
    class Example
    {
        internal void Run()
        {
            var containerBuilder = new ApplicationContainerBuilder();
            var autofacContainer = containerBuilder.BuildContainer();
            using(var scope = autofacContainer.BeginLifetimeScope())
            {
                var service = scope.Resolve<IService>();
                service.Run();
            }
        }
    }
}
