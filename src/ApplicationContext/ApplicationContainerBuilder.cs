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
            ContainerBuilder builder, 
            IContext applicationContext)
        {
            if(logger.IsInfoEnabled)
            {
                logger.Info($"Key:appKey1 Value:{applicationContext["appKey1"]}");
                logger.Info($"Key:appKey2 Value:{applicationContext["appKey2"]}");
            }

            applicationContext["appKey3"] = "appValue3";

            base.RegisterExternalServices(builder, applicationContext);
        }

        protected override void RegisterAssemblyServices(ContainerBuilder builder)
        {
            RegisterAssembly(typeof(ApplicationContainerBuilder).Assembly, builder);
        }
    }
}
