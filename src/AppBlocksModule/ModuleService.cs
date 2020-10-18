using AppBlocks.Autofac.Support;
using log4net;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppBlocks.Autofac.Examples.AppBlocksModule
{
    [AppBlocksService]
    public class ModuleService : IModuleService
    {
        private readonly ILogger<ModuleService> logger;
        
        public ModuleService(ILogger<ModuleService> logger)
        {
            this.logger = logger;
        }

        public void RunModuleService()
        {
            if (logger.IsEnabled(LogLevel.Information)) 
                logger.LogInformation($"{nameof(ModuleService)}.{nameof(RunModuleService)} called");
        }
    }
}
