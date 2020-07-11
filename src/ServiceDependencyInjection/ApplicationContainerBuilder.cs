using AppBlocks.Autofac.Common;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBlocks.Autofac.Examples.ServiceDependencyInjection
{
    internal class ApplicationContainerBuilder : AppBlocksContainerBuilder
    {
        public ApplicationContainerBuilder() : base(AppBlocksApplicationMode.Live) { }

        protected override void RegisterAssemblyServices(ContainerBuilder builder)
        {
            RegisterAssembly(typeof(ApplicationContainerBuilder).Assembly, builder);
            base.RegisterAssemblyServices(builder);
        }
    }
}
