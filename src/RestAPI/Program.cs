using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AppBlocks.Autofac.Common;
using AppBlocks.Autofac.Logging.Log4Net;
using Autofac.Extensions.DependencyInjection;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace AppBlocks.Autofac.Examples.RestAPI
{
    public class Program
    {
        internal static string LogMethod { get; private set; }

        public static void Main(string[] args)
        {
            // Use command line parameter seri to use serilog 
            if ((args?.Length ?? 0) != 0 &&
                            string.Equals(args[0], "seri", StringComparison.InvariantCultureIgnoreCase))
            {
                Log.Logger = new LoggerConfiguration()
                             .Enrich
                             .FromLogContext()
                             .MinimumLevel.Debug()
                             .WriteTo.File("AppBlocks.Autofac.Examples.RestAPI.Serilog.log")
                             .CreateLogger();

                LogMethod = "seri";

                var loggerFactory = LoggerFactory.Create(builder =>
                {
                    builder.AddSerilog();
                }
                );

                AppBlocksLogging.Instance.SetLoggerFactory(loggerFactory);
            }
            else
            {
                LogMethod = "log4net";
                AppBlocksLogging.Instance.UseLog4Net("log4net.config");
            }

                //AppBlocksLogging.Instance.UseLog4Net("log4net.config");

            //var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            //XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(b => ConfigureLogging(b))
                // Add this line to add Autofac service provider factory to 
                // the pipeline
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void ConfigureLogging(ILoggingBuilder builder)
        {
            if (LogMethod == "seri")
                builder.AddSerilog();
            else
                builder.AddLog4Net("log4net.config");
        }
    }
}
