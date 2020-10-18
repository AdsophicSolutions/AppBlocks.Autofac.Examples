using AppBlocks.Autofac.Support;
using Microsoft.Extensions.Logging;

namespace AppBlocks.Autofac.Examples.QuickStart
{
    [AppBlocksService]
    public class Service : IService
    {
        private readonly ILogger<Service> logger;

        public Service(ILogger<Service> logger)
        {
            this.logger = logger;
        }

        public void Run()
        {
            if (logger.IsEnabled(LogLevel.Information)) 
                logger.LogInformation($"{nameof(Service)} Run() called");
        }
    }
}
