using AppBlocks.Autofac.Support;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AppBlocks.Autofac.Examples.CustomServiceLogger
{
    [AppBlocksService]
    public class AsyncService : IAsyncService
    {
        private readonly ILogger<AsyncService> logger;

        public AsyncService(ILogger<AsyncService> logger)
        {
            this.logger = logger;
        }

        public async Task<int> Run()
        {
            return await Task.Run(() =>
                {
                    if (logger.IsEnabled(LogLevel.Information)) 
                        logger.LogInformation($"{nameof(Service)} Run() called");
                    return 0;
                });
        }
    }
}
