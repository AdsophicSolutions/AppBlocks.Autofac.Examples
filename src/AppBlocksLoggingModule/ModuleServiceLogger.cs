using AppBlocks.Autofac.Common;
using AppBlocks.Autofac.Support;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace AppBlocks.Autofac.Examples.AppBlocksLoggingModule
{

    [AppBlocksLoggerService("AppBlocks.Autofac.Examples.AppBlocksModule.ModuleService")]
    public class ModuleServiceLogger : IServiceLogger
    {
        private readonly ILogger<ModuleServiceLogger> logger;

        public ModuleServiceLogger(ILogger<ModuleServiceLogger> logger)
        {
            this.logger = logger;
        }

        public void PreMethodInvocationLog(IInvocation invocation)
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation($"Custom Service Logger " +
                    $"{nameof(ModuleServiceLogger)}.{nameof(PreMethodInvocationLog)} for ModuleService");
        }

        public void PostMethodInvocationLog(IInvocation invocation)
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation($"Custom Service Logger " +
                    $"{nameof(ModuleServiceLogger)}.{nameof(PostMethodInvocationLog)} for ModuleService");
        }
    }
}
