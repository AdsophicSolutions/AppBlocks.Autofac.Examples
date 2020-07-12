using AppBlocks.Autofac.Support;
using Autofac.Features.Indexed;
using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppBlocks.Autofac.Examples.KeyedAndNamed
{
    [AppBlocksService]
    public class KeyedServiceReceiver : IKeyedServiceReceiver
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IIndex<string, IKeyedService> keyedServices;

        public KeyedServiceReceiver(IIndex<string, IKeyedService> keyedServices)
        {
            this.keyedServices = keyedServices;
        }

        public void RunKeyedServices()
        {
            if (logger.IsInfoEnabled)
                logger.Info($"{nameof(KeyedServiceReceiver)}.{nameof(RunKeyedServices)} called successfully");

            if(keyedServices.TryGetValue("KeyedService1", out IKeyedService keyedService))
                keyedService.RunKeyedService();

            if (keyedServices.TryGetValue("KeyedService2", out keyedService))
                keyedService.RunKeyedService();
        }
    }
}
