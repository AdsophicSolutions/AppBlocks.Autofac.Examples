using AppBlocks.Autofac.Support;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBlocks.Autofac.Examples.RegistrationControl
{
    [AppBlocksLiveService]
    public class LiveService : IService
    {
        /// <summary>
        /// Method not called ApplicationContainerBuilder running in Test mode
        /// </summary>
        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
