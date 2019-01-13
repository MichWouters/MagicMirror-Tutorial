using AutoMapper;
using MagicMirror.Business.Enums;
using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.ConsoleApp;
using MagicMirror.ConsoleApp.Configuration;
using MagicMirror.ConsoleApp.Models;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MagicMirror.Tests.Weather
{
    public class WeatherConsoleTests
    {
        private readonly MagicMirrorApp _magicMirrorApp;
        private readonly Mock<IWeatherService> weatherServiceMock;
        private readonly Mock<ITrafficService> trafficServiceMock;

        public WeatherConsoleTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperPresentationProfile>();
            });

            IMapper mapper = config.CreateMapper();

            weatherServiceMock = new Mock<IWeatherService>();
            trafficServiceMock = new Mock<ITrafficService>();

            _magicMirrorApp = new MagicMirrorApp(weatherServiceMock.Object, trafficServiceMock.Object, mapper);
        }

        [Fact]
        public async Task CanMapUsingConverterClassAsync()
        {
            // Arrange
            string address = "Prongers Cottage Sandygate Lane 14";
            string zipcode = "RH13 6";
            string name = "Michiel";
            string town = "London";
            string workAddress = "Tower Of London";
            var temperatureUom = TemperatureUom.Celsius;
            int temperature = 14;
            string weatherType = "Cloudy";
            var distanceUom = DistanceUom.Metric;
            int distance = 12;
            int duration = 85;
            var sunrise = "8:15";
            var sunset = "21:30";
            DateTime timeOfArrival = new DateTime().AddHours(2).AddMinutes(10);

            var information = new UserInformation()
            {
                Address = address,
                Zipcode = zipcode,
                Name = name,
                Town = town,
                WorkAddress = workAddress
            };

            var mockWeatherModel = new WeatherModel()
            {
                Location = town,
                TemperatureUom = temperatureUom,
                Temperature = temperature,
                WeatherType = weatherType,
                Sunrise = sunrise,
                Sunset = sunset,
            };

            var mockTrafficModel = new TrafficModel()
            {
                Origin = $"{address} {zipcode} {town}",
                DistanceUom = distanceUom,
                Destination = workAddress,
                Distance = distance,
                Duration = duration,
                TimeOfArrival = timeOfArrival
            };

            weatherServiceMock.Setup(x => x.GetWeatherModelAsync(It.IsAny<string>()))
                .ReturnsAsync(mockWeatherModel);

            trafficServiceMock.Setup(x => x.GetTrafficModelAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(mockTrafficModel);

            // Act
            var model = await _magicMirrorApp.GenerateViewModel(information);

            // Assert
            Assert.Equal(timeOfArrival.ToLocalTime().ToShortTimeString(), model.TimeOfArrival);
            Assert.Equal("08:25", model.Sunrise);
            Assert.Equal("20:35", model.Sunset);
            Assert.Equal(temperature, model.Temperature);
            Assert.Equal(temperatureUom.ToString(), model.TemperatureUom);
            Assert.Equal("1 hours and 25 minutes", model.TravelTime);
            Assert.Equal(name, model.UserName);
            Assert.Equal(weatherType, model.WeatherType);

        }
    }
}