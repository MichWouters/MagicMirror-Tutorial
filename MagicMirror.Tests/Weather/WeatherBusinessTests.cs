using MagicMirror.Business.Services;
using Xunit;
using Moq;
using MagicMirror.DataAccess.Repos;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Entities.Traffic;
using System;
using MagicMirror.Business.Models;

namespace MagicMirror.Tests.Weather
{
    public class WeatherBusinessTests
    {
        private IWeatherService _service;

        private const string Location = "London";
        private const double Kelvin = 295.15;
        private const string Weathertype = "Clear";
        private const string Icon = "01d";
        private const int Sunrise = 1531281435;
        private const int Sunset = 1531340063;

        public WeatherBusinessTests()
        {
            var mockInterface = new Mock<IWeatherRepo>();
            _service = new WeatherService(mockInterface.Object);
        }

        [Fact]
        public void Can_Map_From_Entity()
        {
            // Arrange
            WeatherEntity entity = GetMockEntity();

            // Act
            WeatherModel model = _service.
        }

        private WeatherEntity GetMockEntity()
        {
            Main main = new Main
            {
                Temp = Kelvin
            };

            Sys sys = new Sys
            {
                Sunrise = Sunrise,
                Sunset = Sunset
            };

            var weather = new DataAccess.Entities.Weather.Weather
            {
                Main = Weathertype
            };

            var weatherEntity = new WeatherEntity
            {
                Name = Location,
                Main = main,
                Sys = sys,
                Weather = new[] { weather }
            };

            return weatherEntity;
        }
    }
}