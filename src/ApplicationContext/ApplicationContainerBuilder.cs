using AppBlocks.Autofac.Common;
using Autofac;
using Microsoft.Extensions.Logging;

namespace AppBlocks.Autofac.Examples.ApplicationContext
{
    internal class ApplicationContainerBuilder : AppBlocksContainerBuilder
    {
        private readonly static ILogger<ApplicationContainerBuilder> logger =
            new Logger<ApplicationContainerBuilder>(AppBlocksLogging.Instance.GetLoggerFactory());

        public ApplicationContainerBuilder()
            : base(new ApplicationConfiguration("appsettings.json"),
                  AppBlocksApplicationMode.Live) 
        { 

        }

        protected override void RegisterExternalServices(
            ContainerBuilder builder)
        {
            if(logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation($"Key:appKey1 Value:{ApplicationContext["appKey1"]}");
                logger.LogInformation($"Key:appKey2 Value:{ApplicationContext["appKey2"]}");
            }

            ApplicationContext["appKey3"] = "appValue3";

            base.RegisterExternalServices(builder);
        }

        protected override void RegisterAssemblyServices(ContainerBuilder builder)
        {
            RegisterAssembly(typeof(ApplicationContainerBuilder).Assembly, builder);
        }
    }
}
