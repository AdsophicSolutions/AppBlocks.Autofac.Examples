using AppBlocks.Autofac.Common;
using AppBlocks.Autofac.Support;
using Castle.DynamicProxy;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AppBlocks.Autofac.Examples.CustomServiceLogger
{
    [AppBlocksLoggerService("AppBlocks.Autofac.Examples.CustomServiceLogger.AsyncService")]
    public class AsyncServiceLogger : IServiceLogger
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void PreMethodInvocationLog(IInvocation invocation)
        {
            if (logger.IsInfoEnabled)
                logger.Info($"Custom Service Logger {nameof(AsyncServiceLogger)}.{nameof(PreMethodInvocationLog)} for {nameof(AsyncService)}");
        }

        public void PostMethodInvocationLog(IInvocation invocation)
        {
            if (logger.IsInfoEnabled)
                logger.Info($"Custom Service Logger " +
                    $"{nameof(AsyncServiceLogger)}.{nameof(PostMethodInvocationLog)} for {nameof(AsyncService)}." +
                    $" Return value is {Utility.GetAsyncInvocationResult(invocation)}");
        }
    }
}
