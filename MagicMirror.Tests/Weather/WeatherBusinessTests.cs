﻿using AutoMapper;
using MagicMirror.Business.Configuration;
using MagicMirror.Business.Enums;
using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace MagicMirror.Tests.Weather
{
    public class WeatherBusinessTests
    {
        private IWeatherService _service;

        // Mock values
        private const string Location = "Dublin";
        private const float Kelvin = 295.15f;
        private const string Weathertype = "Clear";
        private const string Icon = "01d";
        private const int Sunrise = 1512345678;
        private const int Sunset = 1587654321;

        // Mock objects
        private Mock<IWeatherRepo> mockRepo;

        public WeatherBusinessTests()
        {
            mockRepo = new Mock<IWeatherRepo>();

            // Initialize AutoMapper for Unit Tests
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperBusinessProfile>();
            });

            IMapper mapper = config.CreateMapper();

            // Initialize Service with Dependencies
            _service = new WeatherService(mockRepo.Object, mapper);
        }

        [Fact]
        public async Task Calculate_DateTimes_Correctly()
        {
            // Arrange
            mockRepo.Setup(x => x.GetWeatherEntityByCityAsync(It.IsAny<string>()))
                .ReturnsAsync(GetMockEntity());

            // Act
            WeatherModel model = await _service.GetWeatherModelAsync(Location);

            // Assert
            Assert.Equal("1:01", model.Sunrise);
            Assert.Equal("17:05", model.Sunset);
        }

        [Fact]
        public async Task Calculate_Temperatures_CorrectlyAsync()
        {
            // Arrange
            mockRepo.Setup(x => x.GetWeatherEntityByCityAsync(It.IsAny<string>()))
                .ReturnsAsync(GetMockEntity());

            // Act
            WeatherModel model = await _service.GetWeatherModelAsync("Paris");
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
    }
}