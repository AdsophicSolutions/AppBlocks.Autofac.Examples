using AppBlocks.Autofac.Support;
using log4net;
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
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public int Run(string parameter)
        {
            if (logger.IsInfoEnabled) 
                logger.Info($"{nameof(Service)} Run() called with parameter {parameter}");

            return 0;
        }
    }
}
