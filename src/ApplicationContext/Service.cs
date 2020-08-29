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
            if (logger.IsInfoEnabled) 
                logger.Info($"{nameof(Service)} Run() called");

            if (logger.IsInfoEnabled)
            {
                logger.Info($"Key:appKey1 Value:{applicationContext["appKey1"]}");
                logger.Info($"Key:appKey2 Value:{applicationContext["appKey2"]}");
                logger.Info($"Key:appKey3 Value:{applicationContext["appKey3"]}");
            }
        }
    }
}
