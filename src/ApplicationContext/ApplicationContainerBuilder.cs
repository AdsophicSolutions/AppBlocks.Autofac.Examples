using AppBlocks.Autofac.Common;
using Autofac;
using log4net;
using System.Diagnostics.Tracing;
using System.Reflection;

namespace AppBlocks.Autofac.Examples.ApplicationContext
{
    internal class ApplicationContainerBuilder : AppBlocksContainerBuilder
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ApplicationContainerBuilder()
            : base(new ApplicationConfiguration("appsettings.json"),
                  AppBlocksApplicationMode.Live) { }

        protected override void RegisterExternalServices(
            ContainerBuilder builder)
        {
            if(logger.IsInfoEnabled)
            {
                logger.Info($"Key:appKey1 Value:{ApplicationContext["appKey1"]}");
                logger.Info($"Key:appKey2 Value:{ApplicationContext["appKey2"]}");
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
