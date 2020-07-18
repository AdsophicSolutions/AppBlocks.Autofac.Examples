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
            builder.RegisterModule(new AppBlocksModuleImpl(this));
            RegisterAssembly(typeof(ApplicationContainerBuilder).Assembly, builder);
        }
    }
}
