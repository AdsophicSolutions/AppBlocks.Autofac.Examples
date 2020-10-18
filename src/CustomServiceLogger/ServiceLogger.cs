using AppBlocks.Autofac.Common;
using AppBlocks.Autofac.Support;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace AppBlocks.Autofac.Examples.CustomServiceLogger
{
    [AppBlocksLoggerService("AppBlocks.Autofac.Examples.CustomServiceLogger.Service")]
    public class ServiceLogger : IServiceLogger
    {
        private readonly ILogger<Service> logger;

        public ServiceLogger(ILogger<Service> logger)
        {
            this.logger = logger;
        }

        public void PreMethodInvocationLog(IInvocation invocation)
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation($"Custom Service Logger {nameof(ServiceLogger)}.{nameof(PreMethodInvocationLog)} for {nameof(Service)}");
        }

        public void PostMethodInvocationLog(IInvocation invocation)
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation($"Custom Service Logger " +
                    $"{nameof(ServiceLogger)}.{nameof(PostMethodInvocationLog)} for {nameof(Service)}." +
                    $" Return value is {invocation.ReturnValue}");
        }
    }
}
