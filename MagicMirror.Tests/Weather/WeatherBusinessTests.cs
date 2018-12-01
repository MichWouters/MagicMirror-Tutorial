using System.Threading.Tasks;
using MagicMirror.Business.Enums;
using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using Moq;
using Xunit;

namespace MagicMirror.Tests.Weather
{
    public class WeatherBusinessTests
    {
        private readonly IWeatherService _service;

        // Mock values
        private const string Location = "London";
        private const float Kelvin = 295.15f;
        private const string WeatherType = "Clear";
        private const string Icon = "01d";
        private const int Sunrise = 1512345678;
        private const int Sunset = 1587654321;

        public WeatherBusinessTests()
        {
            var mockRepo = new Mock<IWeatherRepo>();
            _service = new WeatherService(mockRepo.Object);

            // Arrange
            mockRepo.Setup(x => x.GetWeatherEntityByCityAsync(It.IsAny<string>()))
                .ReturnsAsync(GetMockEntity);
        }

        [Fact]
        public async Task Calculate_DateTimes_Correctly()
        {
            // Act
            WeatherModel model = await _service.GetWeatherModelAsync(Location);

            // Assert
            Assert.Equal("01:01", model.Sunrise);
            Assert.Equal("17:05", model.Sunset);
        }

        [Fact]
        public async Task Calculate_Temperatures_Correctly()
        {
            // Act
            WeatherModel model = await _service.GetWeatherModelAsync(Location);
            double celsius = model.ConvertTemperature(TemperatureUom.Celsius);
            double fahrenheit = model.ConvertTemperature(TemperatureUom.Fahrenheit);
            double kelvin = model.ConvertTemperature(TemperatureUom.Kelvin);

            // Assert
            Assert.Equal(22, celsius);
            Assert.Equal(71.6, fahrenheit);
            Assert.Equal(295.15, kelvin);
        }

        [Fact]
        public async Task Can_Map_From_Entity()
        {
            // Act
            WeatherModel model = await _service.GetWeatherModelAsync(Location);

            // Assert
            Assert.Equal(Location, model.Location);
            Assert.Equal(WeatherType, model.WeatherType);
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
                Main = WeatherType,
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