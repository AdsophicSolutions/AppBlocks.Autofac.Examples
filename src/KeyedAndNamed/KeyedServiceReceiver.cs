using AppBlocks.Autofac.Support;
using Autofac.Features.Indexed;
using Microsoft.Extensions.Logging;

namespace AppBlocks.Autofac.Examples.KeyedAndNamed
{
    [AppBlocksService]
    public class KeyedServiceReceiver : IKeyedServiceReceiver
    {
        private readonly IIndex<string, IKeyedService> keyedServices;
        private readonly ILogger<KeyedServiceReceiver> logger;

        public KeyedServiceReceiver(ILogger<KeyedServiceReceiver> logger, 
            IIndex<string, IKeyedService> keyedServices)
        {
            this.logger = logger;
            this.keyedServices = keyedServices;
        }

        public void RunKeyedServices()
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation($"{nameof(KeyedServiceReceiver)}.{nameof(RunKeyedServices)} called successfully");

            if(keyedServices.TryGetValue("KeyedService1", out IKeyedService keyedService))
                keyedService.RunKeyedService();

            if (keyedServices.TryGetValue("KeyedService2", out keyedService))
                keyedService.RunKeyedService();
        }
    }
}
