using AppBlocks.Autofac.Common;
using AppBlocks.Autofac.Support;
using Autofac;
using System;

namespace AppBlocks.Autofac.Examples.RegistrationControl
{
    internal class ApplicationContainerBuilder : AppBlocksContainerBuilder
    {
        public ApplicationContainerBuilder() : base(AppBlocksApplicationMode.Test) { }

        protected override void RegisterAssemblyServices(ContainerBuilder builder)
        {
            RegisterAssembly(typeof(ApplicationContainerBuilder).Assembly, builder);
        }

        protected override bool ShouldRegisterService(Type type, 
            AppBlocksServiceAttributeBase serviceAttribute)
        {
            if (type.FullName == "AppBlocks.Autofac.Examples.RegistrationControl.FilteredOutService") 
                return false;

            return base.ShouldRegisterService(type, serviceAttribute);
        }
    }
}
