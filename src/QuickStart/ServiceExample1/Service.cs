using AppBlocks.Autofac.Support;
using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace QuickStart.ServiceExample1
{
    [AppBlocksService]
    public class Service : IService
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Run()
        {
            if (logger.IsDebugEnabled) logger.Debug($"{nameof(Service)} run successful");
        }
    }
}
