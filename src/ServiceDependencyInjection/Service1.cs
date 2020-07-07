using AppBlocks.Autofac.Support;
using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppBlocks.Autofac.Examples.ServiceDependencyInjection
{
    [AppBlocksService]
    public class Service1 : IService1
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IService2 service2;

        public Service1(IService2 service2)
        {
            this.service2 = service2;
        }

        public void RunService1()
        {
            if (logger.IsDebugEnabled)
                logger.Debug($"Executing service method {nameof(RunService1)}");

            service2.RunService2();
        }
    }
}
