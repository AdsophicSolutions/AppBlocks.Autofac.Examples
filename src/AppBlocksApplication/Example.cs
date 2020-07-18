using AppBlocks.Autofac.Common;
using Autofac;

namespace AppBlocks.Autofac.Examples.AppBlocksApplication
{
    class Example
    {
        internal void Run()
        {
            var applicationConfiguration =
                new ApplicationConfiguration("appsettings.json");
            applicationConfiguration.GenerateConfiguration();

            var containerBuilder = new ApplicationContainerBuilder(applicationConfiguration);
            var autofacContainer = containerBuilder.BuildContainer();

            using var scope = autofacContainer.BeginLifetimeScope();
            var service = scope.Resolve<IService>();
            service.Run();
        }
    }
}
