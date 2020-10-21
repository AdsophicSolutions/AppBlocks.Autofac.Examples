using System;
using AppBlocks.Autofac.Common;
using AppBlocks.Autofac.Logging.Log4Net;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace AppBlocks.Autofac.Examples.RestAPI
{
    public class Program
    {   
        public static void Main(string[] args)
        {
            var logMethod = string.Empty;

            // Use command line parameter seri to use serilog 
            if ((args?.Length ?? 0) != 0 &&
                            string.Equals(args[0], "seri", StringComparison.InvariantCultureIgnoreCase))
            {
                Log.Logger = new LoggerConfiguration()
                             .Enrich
                             .FromLogContext()                             
                             .WriteTo.File("AppBlocks.Autofac.Examples.RestAPI.Serilog.log")
                             .CreateLogger();

                logMethod = "seri";

                var loggerFactory = LoggerFactory.Create(builder =>
                {
                    builder.AddSerilog();
                }
                );

                AppBlocksLogging.Instance.SetLoggerFactory(loggerFactory);
            }
            else
            {
                logMethod = "log4net";
                AppBlocksLogging.Instance.UseLog4Net("log4net.config");
            }

            CreateHostBuilder(args, logMethod).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, string logMethod) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(b => ConfigureLogging(b, logMethod))
                // Add this line to add Autofac service provider factory to 
                // the pipeline
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void ConfigureLogging(ILoggingBuilder builder, string logMethod)
        {
            if (logMethod == "seri")
                builder.AddSerilog();
            else
            {                
                builder                    
                    .AddLog4Net("log4net.config")
                    // Let log4net configuration drive the log levels
                    // do not filter anything via ILogger
                    .AddFilter((l) => true);                
            }
        }
    }
}
