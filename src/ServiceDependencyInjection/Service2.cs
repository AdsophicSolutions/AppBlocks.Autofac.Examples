using AppBlocks.Autofac.Support;
using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppBlocks.Autofac.Examples.ServiceDependencyInjection
{
    [AppBlocksService]
    public class Service2 : IService2
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void RunService2()
        {
            if (logger.IsDebugEnabled)
                logger.Debug($"Executing service method {nameof(RunService2)}");
        }
    }
}
