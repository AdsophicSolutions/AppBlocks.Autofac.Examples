using AppBlocks.Autofac.Common;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBlocks.Autofac.Examples.AppBlocksModule
{
    public class AppBlocksModuleImpl : AppBlocksModuleBase
    {
        protected override void RegisterExternalServices(ContainerBuilder builder,
            IContext applicationContext)
        {
            var singleInstanceService = new SingleInstanceModuleService();
            RegisterAsSingleInstance(builder, singleInstanceService);
        }

        protected override void RegisterAssemblyServices
            (ContainerBuilder builder, AppBlocksContainerBuilder appBlocksContainerBuilder)
        {
            RegisterAssembly(typeof(AppBlocksModuleImpl).Assembly, builder, appBlocksContainerBuilder);
        }
    }
}
