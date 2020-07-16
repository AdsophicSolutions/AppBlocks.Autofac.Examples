using AppBlocks.Autofac.Support;
using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppBlocks.Autofac.Examples.AppBlocksModule
{
    [AppBlocksService]
    public class ModuleService : IModuleService
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void RunModuleService()
        {
            if (logger.IsDebugEnabled) 
                logger.Debug($"{nameof(ModuleService)}.{nameof(RunModuleService)} called");
        }
    }
}
