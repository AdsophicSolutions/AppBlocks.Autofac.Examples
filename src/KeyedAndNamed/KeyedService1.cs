using AppBlocks.Autofac.Support;
using Microsoft.Extensions.Logging;

namespace AppBlocks.Autofac.Examples.KeyedAndNamed
{
    [AppBlocksKeyedService("KeyedService1", typeof(IKeyedService))]
    public class KeyedService1 : IKeyedService
    {
        private readonly ILogger<KeyedService1> logger;

        public KeyedService1(ILogger<KeyedService1> logger)
        {
            this.logger = logger;
        }

        public void RunKeyedService()
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation($"{nameof(KeyedService1)}.{nameof(RunKeyedService)} called successfully");
        }
    }
}
