using Autofac;

namespace AppBlocks.Autofac.Examples.MediatRSupport
{
    class Example
    {
        internal void Run()
        {
            var containerBuilder = new ApplicationContainerBuilder();
            var autofacContainer = containerBuilder.BuildContainer();

            using var scope = autofacContainer.BeginLifetimeScope();
            var service = scope.Resolve<IMediatRReceiverService>();

            service.RunRequest();
            service.RunNotification();
        }
    }
}
