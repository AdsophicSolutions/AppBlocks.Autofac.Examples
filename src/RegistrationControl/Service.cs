using AppBlocks.Autofac.Support;
using log4net;
using System.Reflection;

namespace AppBlocks.Autofac.Examples.RegistrationControl
{
    [AppBlocksService]
    public class Service : IService
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Run()
        {
            if (logger.IsInfoEnabled) logger.Info($"{nameof(Service)} Run() called");
        }
    }
}
