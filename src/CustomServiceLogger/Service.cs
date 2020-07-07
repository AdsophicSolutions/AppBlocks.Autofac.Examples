using AppBlocks.Autofac.Support;
using log4net;
using System.Reflection;

namespace AppBlocks.Autofac.Examples.CustomServiceLogger
{
    [AppBlocksService]
    public class Service : IService
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Run()
        {
            if (logger.IsDebugEnabled) logger.Debug($"{nameof(Service)} Run() called");
        }
    }
}
