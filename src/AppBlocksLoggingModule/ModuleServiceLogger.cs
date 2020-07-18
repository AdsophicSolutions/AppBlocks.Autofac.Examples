using AppBlocks.Autofac.Common;
using AppBlocks.Autofac.Support;
using Castle.DynamicProxy;
using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppBlocks.Autofac.Examples.AppBlocksLoggingModule
{   

    [AppBlocksLoggerService("AppBlocks.Autofac.Examples.AppBlocksModule.ModuleService")]
    public class ModuleServiceLogger : IServiceLogger
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void PreMethodInvocationLog(IInvocation invocation)
        {
            if (logger.IsInfoEnabled)
                logger.Info($"Custom Service Logger " +
                    $"{nameof(ModuleServiceLogger)}.{nameof(PreMethodInvocationLog)} for ModuleService");
        }

        public void PostMethodInvocationLog(IInvocation invocation)
        {
            if (logger.IsInfoEnabled)
                logger.Info($"Custom Service Logger " +
                    $"{nameof(ModuleServiceLogger)}.{nameof(PostMethodInvocationLog)} for ModuleService");
        }
    }
}
