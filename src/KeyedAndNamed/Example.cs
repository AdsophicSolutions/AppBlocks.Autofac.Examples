using Autofac;

namespace AppBlocks.Autofac.Examples.KeyedAndNamed
{
    class Example
    {
        internal void Run()
        {
            var containerBuilder = new ApplicationContainerBuilder();
            var autofacContainer = containerBuilder.BuildContainer();

            using var scope = autofacContainer.BeginLifetimeScope();
            var namedService = scope.ResolveNamed<INamedService>("AppBlocks.Autofac.Examples.KeyedAndNamed.NamedService");
            namedService.RunService();

            var receiverService =
                scope.Resolve<IKeyedServiceReceiver>();
            receiverService.RunKeyedServices();
        }
    }
}
