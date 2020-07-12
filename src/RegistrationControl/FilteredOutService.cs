using AppBlocks.Autofac.Support;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBlocks.Autofac.Examples.RegistrationControl
{
    [AppBlocksService]
    public class FilteredOutService : IService
    {
        /// <summary>
        /// Not called. Filtered Out in ApplicationContainerBuilder
        /// </summary>
        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
