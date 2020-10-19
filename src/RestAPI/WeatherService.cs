using AppBlocks.Autofac.Support;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBlocks.Autofac.Examples.RestAPI
{
    [AppBlocksService]
    public class WeatherService : IWeatherService
    {
        private readonly ILogger<WeatherService> logger;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherService(ILogger<WeatherService> logger)
        {
            this.logger = logger;            
        }

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            if (logger.IsEnabled(LogLevel.Debug))
                logger.LogDebug($"Called {nameof(WeatherService)}.{nameof(GetWeatherForecasts)}");

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
