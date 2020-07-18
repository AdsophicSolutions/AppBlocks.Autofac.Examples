using AppBlocks.Autofac.Common;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBlocks.Autofac.Examples.AppBlocksModule
{
    public class AppBlocksModuleImpl : AppBlocksModuleBase
    {
        public AppBlocksModuleImpl(AppBlocksContainerBuilder appBlocksContainerBuilder)
            : base(appBlocksContainerBuilder) { }

        protected override void RegisterExternalServices(ContainerBuilder builder)
        {
            var singleInstanceService = new SingleInstanceModuleService();
            RegisterAsSingleInstance(builder, singleInstanceService);
        }

        protected override void RegisterAssemblyServices(ContainerBuilder builder)
        {
            RegisterAssembly(typeof(AppBlocksModuleImpl).Assembly, 
                builder, 
                AppBlocksContainerBuilder);
        }
    }
}
