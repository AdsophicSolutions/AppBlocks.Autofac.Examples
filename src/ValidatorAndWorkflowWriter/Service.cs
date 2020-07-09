using AppBlocks.Autofac.Support;
using log4net;
using System.Reflection;

namespace AppBlocks.Autofac.Examples.ValidatorAndWorkflowWriter
{
    [AppBlocksService]
    public class Service : IService
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public int Run(string parameter)
        {
            if (logger.IsDebugEnabled) 
                logger.Debug($"{nameof(Service)} Run() called with parameter {parameter}");

            return 0;
        }
    }
}
