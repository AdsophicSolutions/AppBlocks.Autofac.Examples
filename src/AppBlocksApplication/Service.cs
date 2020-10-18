using AppBlocks.Autofac.Examples.AppBlocksModule;
using AppBlocks.Autofac.Support;
using log4net;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace AppBlocks.Autofac.Examples.AppBlocksApplication
{
    [AppBlocksService]
    public class Service : IService
    {
        private readonly ILogger<Service> logger;
        private readonly IModuleService moduleService;
        private readonly SingleInstanceModuleService singleInstanceModuleService;

        public Service(
            ILogger<Service> logger,
            IModuleService moduleService, 
            SingleInstanceModuleService singleInstanceModuleService)
        {
            this.logger = logger;
            this.moduleService = moduleService;
            this.singleInstanceModuleService = singleInstanceModuleService;
        }

        public void Run()
        {
            if (logger.IsEnabled(LogLevel.Information)) 
                logger.LogInformation($"{nameof(Service)} Run() called");

            moduleService.RunModuleService();
            singleInstanceModuleService.Run();
        }
    }
}
