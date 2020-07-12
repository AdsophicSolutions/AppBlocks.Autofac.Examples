using AppBlocks.Autofac.Support;
using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppBlocks.Autofac.Examples.KeyedAndNamed
{
    [AppBlocksKeyedService("KeyedService1", typeof(IKeyedService))]
    public class KeyedService1 : IKeyedService
    {
        private static readonly ILog logger =
           LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void RunKeyedService()
        {
            if (logger.IsInfoEnabled)
                logger.Info($"{nameof(KeyedService1)}.{nameof(RunKeyedService)} called successfully");
        }
    }
}
