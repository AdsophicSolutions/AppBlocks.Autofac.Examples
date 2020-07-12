using AppBlocks.Autofac.Support;
using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppBlocks.Autofac.Examples.KeyedAndNamed
{
    [AppBlocksKeyedService("KeyedService2", typeof(IKeyedService))]
    public class KeyedService2 : IKeyedService
    {
        private static readonly ILog logger =
           LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void RunKeyedService()
        {
            if (logger.IsInfoEnabled)
                logger.Info($"{nameof(KeyedService2)}.{nameof(RunKeyedService)} called successfully");
        }
    }
}
