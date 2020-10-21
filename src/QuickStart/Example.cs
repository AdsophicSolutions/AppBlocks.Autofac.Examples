using Autofac;

namespace AppBlocks.Autofac.Examples.QuickStart
{
    class Example
    {
        internal void Run()
        {
            var containerBuilder = new ApplicationContainerBuilder();
            var autofacContainer = containerBuilder.BuildContainer();

            using var scope = autofacContainer.BeginLifetimeScope();
            var service = scope.Resolve<IService>();
            service.Run();

            var asyncService = scope.Resolve<IAsyncService>();
            var result = asyncService.Run().GetAwaiter().GetResult();
        }
    }
}
