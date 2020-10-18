using AppBlocks.Autofac.Support;
using Microsoft.Extensions.Logging;

namespace AppBlocks.Autofac.Examples.ServiceDependencyInjection
{
    [AppBlocksService]
    public class Service1 : IService1
    {
        private readonly ILogger<Service1> logger;
        private readonly IService2 service2;        

        public Service1(ILogger<Service1> logger, IService2 service2)
        {
            this.logger = logger;
            this.service2 = service2;
        }

        public void RunService1()
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation($"Executing service method {nameof(RunService1)}");

            service2.RunService2();
        }
    }
}
