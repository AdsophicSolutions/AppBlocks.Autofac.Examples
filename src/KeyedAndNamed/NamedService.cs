using AppBlocks.Autofac.Support;
using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppBlocks.Autofac.Examples.KeyedAndNamed
{
    [AppBlocksNamedService("AppBlocks.Autofac.Examples.KeyedAndNamed.NamedService")]
    public class NamedService : INamedService
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void RunService()
        {
            if (logger.IsInfoEnabled)
                logger.Info($"{nameof(NamedService)}.{nameof(RunService)} called successfully");
        }
    }
}
