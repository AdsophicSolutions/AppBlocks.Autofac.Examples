using AppBlocks.Autofac.Common;
using AppBlocks.Autofac.Support;
using log4net;
using System.Reflection;

namespace AppBlocks.Autofac.Examples.ApplicationContext
{
    [AppBlocksService]
    public class Service : IService
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IContext applicationContext;

        public Service(IContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public void Run()
        {
            if (logger.IsDebugEnabled) 
                logger.Debug($"{nameof(Service)} Run() called");

            if (logger.IsInfoEnabled)
                logger.Info($"Key:appKey3 Value:{applicationContext["appKey3"]}");
        }
    }
}
