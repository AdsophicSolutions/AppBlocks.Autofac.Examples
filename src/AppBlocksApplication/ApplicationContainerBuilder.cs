using AppBlocks.Autofac.Common;
using AppBlocks.Autofac.Examples.AppBlocksModule;
using Autofac;

namespace AppBlocks.Autofac.Examples.AppBlocksApplication
{
    internal class ApplicationContainerBuilder : AppBlocksContainerBuilder
    {
        public ApplicationContainerBuilder() : base(AppBlocksApplicationMode.Live) { }

        protected override void RegisterAssemblyServices(ContainerBuilder builder)
        {
            RegisterModule(builder, new AppBlocksModuleImpl());
            RegisterAssembly(typeof(ApplicationContainerBuilder).Assembly, builder);
        }
    }
}
