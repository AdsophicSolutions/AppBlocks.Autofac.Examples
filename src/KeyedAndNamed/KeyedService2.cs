using AppBlocks.Autofac.Support;
using Microsoft.Extensions.Logging;

namespace AppBlocks.Autofac.Examples.KeyedAndNamed
{
    [AppBlocksKeyedService("KeyedService2", typeof(IKeyedService))]
    public class KeyedService2 : IKeyedService
    {
        private readonly ILogger<KeyedService2> logger;

        public KeyedService2(ILogger<KeyedService2> logger)
        {
            this.logger = logger;
        }

        public void RunKeyedService()
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation($"{nameof(KeyedService2)}.{nameof(RunKeyedService)} called successfully");
        }
    }
}
