using AutoMapper;
using MagicMirror.Business.Enums;
using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using Moq;
using System;
using System.Threading.Tasks;
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
        private DateTime SunriseDateTime = new DateTime(2019, 6, 1, 6, 20, 0);
        private DateTime SunsetDateTime = new DateTime(2019, 6, 1, 19, 15, 0);

        private Mock<IWeatherRepo> mockRepo;
        private Mock<IMapper> mockMapper;

        public WeatherBusinessTests()
        {
            mockRepo = new Mock<IWeatherRepo>();
            mockMapper = new Mock<IMapper>();

            // Initialize Service with Dependencies
            _service = new WeatherService(mockRepo.Object, mockMapper.Object);
        }

        [Fact]
        public async Task Calculate_DateTimes_Correctly()
        {
            // Arrange
            mockMapper.Setup(x => x.Map<WeatherModel>(It.IsAny<WeatherEntity>()))
                .Returns(GetMockModel());

            // Act
            WeatherModel model = await _service.GetWeatherModelAsync(Location);

            // Assert
            Assert.Equal(new DateTime(2019, 6, 1, 6, 20, 0), model.Sunrise);
            Assert.Equal(new DateTime(2019, 6, 1, 19, 15, 0), model.Sunset);
        }

        [Fact]
        public async Task Calculate_Temperatures_CorrectlyAsync()
        {
            // Arrange
            mockMapper.Setup(x => x.Map<WeatherModel>(It.IsAny<WeatherEntity>()))
                .Returns(GetMockModel());

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

        private WeatherModel GetMockModel()
        {
            return new WeatherModel
            {
                Location = Location,
                Sunrise = SunriseDateTime,
                Sunset = SunsetDateTime,
                Temperature = 22,
                TemperatureUom = TemperatureUom.Celsius,
                Icon = string.Empty,
                WeatherType = "Sunny"
            };
        }
    }
}