using Autofac;

namespace AppBlocks.Autofac.Examples.ValidatorAndWorkflowWriter
{
    class Example
    {
        internal void Run()
        {
            var containerBuilder = new ApplicationContainerBuilder();
            var autofacContainer = containerBuilder.BuildContainer();

            using var scope = autofacContainer.BeginLifetimeScope();
            var service = scope.Resolve<IService>();
            service.Run("hello world");
        }
    }
}
