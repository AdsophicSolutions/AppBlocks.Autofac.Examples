using AppBlocks.Autofac.Support;
using Microsoft.Extensions.Logging;

namespace AppBlocks.Autofac.Examples.ServiceDependencyInjection
{
    [AppBlocksService]
    public class Service2 : IService2
    {
        private readonly ILogger<Service2> logger;        
        public Service2(ILogger<Service2> logger)
        {
            this.logger = logger;            
        }

        public void RunService2()
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation($"Executing service method {nameof(RunService2)}");
        }
    }
}
