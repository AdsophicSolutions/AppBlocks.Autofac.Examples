using AppBlocks.Autofac.Common;
using AppBlocks.Autofac.Support;
using Microsoft.Extensions.Logging;

namespace AppBlocks.Autofac.Examples.ApplicationContext
{
    [AppBlocksService]
    public class Service : IService
    {
        private readonly ILogger<Service> logger;
        private readonly IContext applicationContext;

        public Service(ILogger<Service> logger, IContext applicationContext)
        {
            this.logger = logger;
            this.applicationContext = applicationContext;
        }

        public void Run()
        {
            if (logger.IsEnabled(LogLevel.Information)) 
                logger.LogInformation($"{nameof(Service)} Run() called");

            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation($"Key:appKey1 Value:{applicationContext["appKey1"]}");
                logger.LogInformation($"Key:appKey2 Value:{applicationContext["appKey2"]}");
                logger.LogInformation($"Key:appKey3 Value:{applicationContext["appKey3"]}");
            }
        }
    }
}
