using AppBlocks.Autofac.Common;
using AppBlocks.Autofac.Support;
using Castle.DynamicProxy;
using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppBlocks.Autofac.Examples.CustomServiceLogger
{
    [AppBlocksLoggerService("AppBlocks.Autofac.Examples.CustomServiceLogger.Service")]
    public class ServiceLogger : IServiceLogger
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void PreMethodInvocationLog(IInvocation invocation)
        {
            if (logger.IsInfoEnabled)
                logger.Info($"Custom Service Logger {nameof(ServiceLogger)}.{nameof(PreMethodInvocationLog)} for {nameof(Service)}");
        }

        public void PostMethodInvocationLog(IInvocation invocation)
        {
            if (logger.IsInfoEnabled)
                logger.Info($"Custom Service Logger {nameof(ServiceLogger)}.{nameof(PostMethodInvocationLog)} for {nameof(Service)}");
        }
    }
}
