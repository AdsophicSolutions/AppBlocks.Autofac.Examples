using AppBlocks.Autofac.Common;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace AppBlocks.Autofac.Examples.ApplicationContext
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureLogging(args);
            new Example().Run();
        }

        private static void ConfigureLogging(string[] args)
        {
            // Use command line parameter seri to use serilog 
            if ((args?.Length ?? 0) != 0 &&
                            string.Equals(args[0], "seri", StringComparison.InvariantCultureIgnoreCase))
            {

                Log.Logger = new LoggerConfiguration()
                                 .Enrich
                                 .FromLogContext()
                                 .WriteTo
                                 .Console()
                                 .CreateLogger();

                var loggerFactory = LoggerFactory.Create(builder =>
                {
                    builder.AddSerilog();
                }
                );

                AppBlocksLogging.Instance.SetLoggerFactory(loggerFactory);
            }
            else
                AppBlocksLogging.Instance.UseLog4Net("log4net.config");
        }
    }
}
