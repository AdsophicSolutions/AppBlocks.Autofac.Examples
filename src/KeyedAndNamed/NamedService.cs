using AppBlocks.Autofac.Support;
using Microsoft.Extensions.Logging;

namespace AppBlocks.Autofac.Examples.KeyedAndNamed
{
    [AppBlocksNamedService("AppBlocks.Autofac.Examples.KeyedAndNamed.NamedService")]
    public class NamedService : INamedService
    {
        private readonly ILogger<NamedService> logger;

        public NamedService(ILogger<NamedService> logger)
        {
            this.logger = logger;
        }

        public void RunService()
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation($"{nameof(NamedService)}.{nameof(RunService)} called successfully");
        }
    }
}
