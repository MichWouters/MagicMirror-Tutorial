using MagicMirror.Business.Enums;
using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Entities.Weather;
using Xunit;
using Moq;
using MagicMirror.DataAccess.Repos;
using AutoMapper;
using MagicMirror.Business.Configuration;
using System.Threading.Tasks;

namespace MagicMirror.Tests.Weather
{
    public class WeatherBusinessTests
    {
        private Mock<IWeatherRepo> _mockRepo;
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
            // Initialize AutoMapper for Unit Tests
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperBusinessProfile>();
            });

            IMapper mapper = config.CreateMapper();

            // Initialize Service with Dependencies
            _mockRepo = new Mock<IWeatherRepo>();
            _service = new WeatherService(_mockRepo.Object, mapper);
        }

        [Fact]
        public async Task Calculate_DateTimes_Correctly()
        {
            // Arrange
            WeatherEntity entity = GetMockEntity();

            // Act
            WeatherModel model = await _service.GetWeatherModelAsync(Location);
            model.ConvertValues();

            // Assert
            Assert.Equal("01:01", model.Sunrise);
            Assert.Equal("17:05", model.Sunset);
        }

        [Fact]
        public async Task Calculate_Temperatures_CorrectlyAsync()
        {
            // Arrange
            WeatherEntity entity = GetMockEntity();

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
        public async Task Can_Map_From_EntityAsync()
        {
            // Arrange
            WeatherEntity entity = GetMockEntity();

            // Act
            WeatherModel model = await _service.GetWeatherModelAsync(Location);

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