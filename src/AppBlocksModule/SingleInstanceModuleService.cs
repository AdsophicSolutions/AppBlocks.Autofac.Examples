using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppBlocks.Autofac.Examples.AppBlocksModule
{
    public class SingleInstanceModuleService
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Run()
        {
            if (logger.IsDebugEnabled)
                logger.Debug($"{nameof(SingleInstanceModuleService)}.{nameof(Run)} called");
        }
    }
}
