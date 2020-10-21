using AppBlocks.Autofac.Support;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBlocks.Autofac.Examples.QuickStart
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
                    logger.LogInformation($"{nameof(Service)}.{nameof(Run)} called");
                return 2;
            });
        }
    }
}
