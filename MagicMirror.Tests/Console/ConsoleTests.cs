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

namespace MagicMirror.Tests.Console
{
    public class ConsoleTests
    {
        private MagicMirrorApp app;
        private Mock<IWeatherService> mockWeatherService;
        private Mock<ITrafficService> mockTrafficService;

        public ConsoleTests()
        {
            // Mock dependencies
            mockWeatherService = new Mock<IWeatherService>();
            mockTrafficService = new Mock<ITrafficService>();

            // Initialize AutoMapper for Unit Tests
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperPresentationProfile>();
            });

            IMapper mapper = config.CreateMapper();
            app = new MagicMirrorApp(mockWeatherService.Object, mockTrafficService.Object, mapper);
        }

        // Tests
        [Fact]
        public async Task Business_Methods_Called_Once()
        {
            // Arrange
            var information = GetMockUserInformation();
            mockWeatherService.Setup(x => x.GetWeatherModelAsync(It.IsAny<string>())).ReturnsAsync(GetMockWeatherModel());
            mockTrafficService.Setup(x => x.GetTrafficModelAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(GetMockTrafficModel());

            // Act
            var result = await app.GenerateViewModel(information);

            mockWeatherService.Verify(x => x.GetWeatherModelAsync(It.IsAny<string>()), Times.Once);
            mockTrafficService.Verify(x => x.GetTrafficModelAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task EmptyWeatherInformation_ShouldDisplay_OfflineData()
        {
            // Arrange
            mockTrafficService.Setup(x => x.GetTrafficModelAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(GetMockTrafficModel());

            var expectedSunrise = new DateTime(2019, 10, 10, 6, 4, 0, DateTimeKind.Utc).ToLocalTime().ToString("HH:mm");
            var expectedSunset = new DateTime(2019, 10, 10, 18, 36, 0, DateTimeKind.Utc).ToLocalTime().ToString("HH:mm");
            var expectedTimeOfArrival = DateTime.Now.AddMinutes(35).ToShortTimeString();

            // Act
            var result = await app.GenerateViewModel(null);

            // Assert
            Assert.Equal("35 minutes", result.TravelTime);
            Assert.Equal(27.5, result.Distance);
            Assert.Equal("kilometers", result.DistanceUom);
            Assert.Equal(17, result.Temperature);
            Assert.Equal("Celsius", result.TemperatureUom);
            Assert.Equal("Sunny", result.WeatherType);

            Assert.True(result.IsOfflineData);
            Assert.Equal("Anonymous", result.UserName);

            Assert.Equal(expectedSunrise, result.Sunrise);
            Assert.Equal(expectedSunset, result.Sunset);
            Assert.Equal(expectedTimeOfArrival, result.TimeOfArrival);
        }

        [Fact]
        public async Task EmptyTrafficInformation_ShouldDisplay_OfflineData()
        {
            // Arrange
            mockWeatherService.Setup(x => x.GetWeatherModelAsync(It.IsAny<string>()))
                .ReturnsAsync(GetMockWeatherModel());

            var expectedSunrise = new DateTime(2019, 10, 10, 6, 4, 0, DateTimeKind.Utc).ToLocalTime().ToString("HH:mm");
            var expectedSunset = new DateTime(2019, 10, 10, 18, 36, 0, DateTimeKind.Utc).ToLocalTime().ToString("HH:mm");
            var expectedTimeOfArrival = DateTime.Now.AddMinutes(35).ToShortTimeString();

            // Act
            var result = await app.GenerateViewModel(null);

            // Assert
            Assert.Equal("35 minutes", result.TravelTime);
            Assert.Equal(27.5, result.Distance);
            Assert.Equal("kilometers", result.DistanceUom);
            Assert.Equal(17, result.Temperature);
            Assert.Equal("Celsius", result.TemperatureUom);
            Assert.Equal("Sunny", result.WeatherType);

            Assert.True(result.IsOfflineData);
            Assert.Equal("Anonymous", result.UserName);

            Assert.Equal(expectedSunrise, result.Sunrise);
            Assert.Equal(expectedSunset, result.Sunset);
            Assert.Equal(expectedTimeOfArrival, result.TimeOfArrival);
        }

        [Fact]
        public async Task Presentation_Profile_Is_Mapped_Correctly()
        {
            // Arrange
            var information = GetMockUserInformation();
            mockWeatherService.Setup(x => x.GetWeatherModelAsync(It.IsAny<string>())).ReturnsAsync(GetMockWeatherModel());
            mockTrafficService.Setup(x => x.GetTrafficModelAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(GetMockTrafficModel());

            var expectedSunrise = new DateTime(1, 1, 1, 8, 40, 0, DateTimeKind.Utc).ToLocalTime().ToString("HH:mm");
            var expectedSunset = new DateTime(1, 1, 1, 21, 23, 0, DateTimeKind.Utc).ToLocalTime().ToString("HH:mm");
            var expectedTimeOfArrival = DateTime.Now.AddMinutes(118).ToShortTimeString();

            // Act
            var result = await app.GenerateViewModel(information);

            // Assert
            Assert.Equal(47, result.Distance);
            Assert.Equal("miles", result.DistanceUom);
            Assert.Equal(22, result.Temperature);
            Assert.Equal("Celsius", result.TemperatureUom);
            Assert.Equal("1 hours and 58 minutes", result.TravelTime);
            Assert.Equal("Michiel", result.UserName);
            Assert.Equal("Sunny", result.WeatherType);
            Assert.Equal(expectedSunrise, result.Sunrise);
            Assert.Equal(expectedSunset, result.Sunset);
            Assert.Equal(expectedTimeOfArrival, result.TimeOfArrival);
            Assert.False(result.IsOfflineData);
        }

        // Mock data
        private WeatherModel GetMockWeatherModel()
        {
            return new WeatherModel
            {
                Location = "London",
                Sunrise = new DateTime(1, 1, 1, 8, 40, 0),
                Sunset = new DateTime(1, 1, 1, 21, 23, 0),
                Temperature = 22,
                TemperatureUom = TemperatureUom.Celsius,
                Icon = string.Empty,
                WeatherType = "Sunny"
            };
        }

        private TrafficModel GetMockTrafficModel()
        {
            return new TrafficModel
            {
                Destination = "London",
                Distance = 47,
                DistanceUom = DistanceUom.Imperial,
                Duration = 118 * 60,
                Origin = "Leeds",
                TimeOfArrival = DateTime.Now.AddMinutes(118)
            };
        }

        private UserSettings GetMockUserInformation()
        {
            return UserSettings.GetUserSettings();
        }
    }
}
