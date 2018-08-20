using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Entities.Weather;
using Xunit;

namespace MagicMirror.Tests.Weather
{
    public class WeatherBusinessTests
    {
        private IWeatherService _service;

        // Mock values
        private const string Location = "London";

        private const float Kelvin = 295.15f;
        private const string Weathertype = "Clear";
        private const string Icon = "01d";
        private const int Sunrise = 1512345678;
        private const int Sunset = 1587654321;

        public WeatherBusinessTests()
        {
            _service = new WeatherService();
        }

        [Fact]
        public void Can_Map_From_Entity()
        {
            // Arrange
            WeatherEntity entity = GetMockEntity();

            // Act
            WeatherModel model = _service.MapFromEntity(entity);

            // Assert
            Assert.Equal(Location, model.Location);
            Assert.Equal(Weathertype, model.WeatherType);
            Assert.Equal(Kelvin, model.Temperature);
            Assert.Equal(Sunrise.ToString(), model.Sunrise);
            Assert.Equal(Sunset.ToString(), model.Sunset);
            Assert.Equal(Icon, model.Icon);
        }

        private WeatherEntity GetMockEntity()
        {
            var main = new Main

            {
                Temp = Kelvin
            };

            var sys = new Sys

            {
                Sunrise = Sunrise,
                Sunset = Sunset
            };

            var weather = new DataAccess.Entities.Weather.Weather
            {
                Main = Weathertype,
                Icon = Icon
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