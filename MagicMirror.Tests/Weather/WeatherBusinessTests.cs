using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Entities.Weather;

namespace MagicMirror.Tests.Weather
{
    public class WeatherBusinessTests
    {
        private IWeatherService _service;

        public WeatherBusinessTests()
        {
            _service = new WeatherService();
        }

        private WeatherEntity GetMockEntity()
        {
            var main = new Main
            {
                Temp = 295.15f
            };

            var sys = new Sys
            {
                Sunrise = 1512345678,
                Sunset = 1587654321
            };

            var weather = new DataAccess.Entities.Weather.Weather
            {
                Main = "Cloudy",
                Icon = "01d"
            };

            var weatherEntity = new WeatherEntity
            {
                Name = "London",
                Main = main,
                Sys = sys,
                Weather = new[] { weather }
            };

            return weatherEntity;
        }
    }
}
