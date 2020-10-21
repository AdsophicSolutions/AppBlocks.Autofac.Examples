using AppBlocks.Autofac.Common;
using Castle.Core.Logging;
using log4net;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppBlocks.Autofac.Examples.AppBlocksModule
{
    public class SingleInstanceModuleService
    {
        private readonly ILogger<SingleInstanceModuleService> logger = 
            new Logger<SingleInstanceModuleService>(AppBlocksLogging.Instance.GetLoggerFactory());

        public void Run()
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation($"{nameof(SingleInstanceModuleService)}.{nameof(Run)} called");
        }
    }
}
