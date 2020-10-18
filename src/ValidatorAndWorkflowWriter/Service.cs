using AppBlocks.Autofac.Support;
using log4net;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace AppBlocks.Autofac.Examples.ValidatorAndWorkflowWriter
{
    [AppBlocksService(Name:"",
        ServiceType:null,
        ServiceScope:AppBlocksInstanceLifetime.InstancePerLifetimeScope,
        Interceptors: new[] { AppBlocksInterceptorConstants.Logging, AppBlocksInterceptorConstants.Validation },
        Workflows: new[] { "Application" },
        IsKeyed: false)]
    public class Service : IService
    {
        private readonly ILogger<Service> logger;
        public Service(ILogger<Service> logger)
        {
            this.logger = logger;
        }

        public int Run(string parameter)
        {
            if (logger.IsEnabled(LogLevel.Information)) 
                logger.LogInformation($"{nameof(Service)} Run() called with parameter {parameter}");

            return 0;
        }
    }
}
