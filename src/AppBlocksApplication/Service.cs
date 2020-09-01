using AppBlocks.Autofac.Examples.AppBlocksModule;
using AppBlocks.Autofac.Support;
using log4net;
using System.Reflection;

namespace AppBlocks.Autofac.Examples.AppBlocksApplication
{
    [AppBlocksService]
    public class Service : IService
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IModuleService moduleService;
        private readonly SingleInstanceModuleService singleInstanceModuleService;

        public Service(IModuleService moduleService, 
            SingleInstanceModuleService singleInstanceModuleService)
        {
            this.moduleService = moduleService;
            this.singleInstanceModuleService = singleInstanceModuleService;
        }

        public void Run()
        {
            if (logger.IsInfoEnabled) logger.Info($"{nameof(Service)} Run() called");

            moduleService.RunModuleService();
            singleInstanceModuleService.Run();
        }
    }
}
