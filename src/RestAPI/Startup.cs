using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppBlocks.Autofac.Common;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace AppBlocks.Autofac.Examples.RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //ConfigureLogging();            
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        private void ConfigureLogging()
        {
            if (Program.LogMethod == "seri")
            {
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        //Add this method to initialize Containerbuilder
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var containerBuilder = new ApplicationContainerBuilder();
            containerBuilder.BuildContainer(builder);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
