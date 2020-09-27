using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBlocks.Autofac.Examples.RestAPI
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> GetWeatherForecasts();
    }
}
