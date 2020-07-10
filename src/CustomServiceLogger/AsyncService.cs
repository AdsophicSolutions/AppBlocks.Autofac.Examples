using AppBlocks.Autofac.Support;
using log4net;
using System.Reflection;
using System.Threading.Tasks;

namespace AppBlocks.Autofac.Examples.CustomServiceLogger
{
    [AppBlocksService]
    public class AsyncService : IAsyncService
    {
        private static readonly ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<int> Run()
        {
            return await Task.Run(() =>
                {
                    if (logger.IsDebugEnabled) logger.Debug($"{nameof(Service)} Run() called");
                    return 0;
                });
        }
    }
}
