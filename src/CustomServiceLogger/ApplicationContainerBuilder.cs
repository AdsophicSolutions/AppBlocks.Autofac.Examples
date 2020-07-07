using AppBlocks.Autofac.Common;
using Autofac;

namespace AppBlocks.Autofac.Examples.CustomServiceLogger
{
    internal class ApplicationContainerBuilder : AppBlocksContainerBuilder
    {
        protected override void RegisterAssemblyServices(ContainerBuilder builder)
        {
            RegisterAssembly(typeof(ApplicationContainerBuilder).Assembly, builder);
            base.RegisterAssemblyServices(builder);
        }
    }
}
