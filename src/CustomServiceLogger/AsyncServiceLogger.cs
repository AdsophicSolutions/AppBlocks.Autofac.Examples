using AppBlocks.Autofac.Common;
using AppBlocks.Autofac.Support;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace AppBlocks.Autofac.Examples.CustomServiceLogger
{
    [AppBlocksLoggerService("AppBlocks.Autofac.Examples.CustomServiceLogger.AsyncService")]
    public class AsyncServiceLogger : IServiceLogger
    {
        private readonly ILogger<AsyncServiceLogger> logger;

        public AsyncServiceLogger(ILogger<AsyncServiceLogger> logger)
        {
            this.logger = logger;
        }

        public void PreMethodInvocationLog(IInvocation invocation)
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation($"Custom Service Logger {nameof(AsyncServiceLogger)}.{nameof(PreMethodInvocationLog)} for {nameof(AsyncService)}");
        }

        public void PostMethodInvocationLog(IInvocation invocation)
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation($"Custom Service Logger " +
                    $"{nameof(AsyncServiceLogger)}.{nameof(PostMethodInvocationLog)} for {nameof(AsyncService)}." +
                    $" Return value is {Utility.GetAsyncInvocationResult(invocation)}");
        }
    }
}
