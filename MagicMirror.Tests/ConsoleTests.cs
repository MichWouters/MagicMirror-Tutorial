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

namespace MagicMirror.Tests
{
    public class ConsoleTests
    {
        private IMagicMirrorApp _app;
        private readonly Mock<IWeatherService> _weatherMock;
        private readonly Mock<ITrafficService> _trafficMock;
        private readonly UserInformation _information;

        public ConsoleTests()
        {
            // Add mock dependencies
            _weatherMock = new Mock<IWeatherService>();
            _trafficMock = new Mock<ITrafficService>();

            // Initialize AutoMapper for Unit Tests
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperPresentationProfile>();
            });

            IMapper mapper = config.CreateMapper();

            _app = new MagicMirrorApp(_weatherMock.Object, _trafficMock.Object, mapper);
        }

        [Fact]
        public async Task Presentation_Profile_Is_Mapped_Correctly()
        {
            // Arrange
            var information = new UserInformation
            {
                Address = "1 Paris Garden",
                Name = "Michiel",
                Town = "London",
                Zipcode = "SE1 8NU",
                WorkAddress = "Tower Of London"
            };

            _weatherMock.Setup(x => x.GetWeatherModelAsync(It.IsAny<string>()))
                .ReturnsAsync(GetMockWeatherModel());

            _trafficMock.Setup(x => x.GetTrafficModelAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(GetMockTrafficModel());

            // Act
            var result = await _app.GenerateViewModel(information);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(47, result.Distance);
            Assert.Equal("miles", result.DistanceUom);
            Assert.Equal("08:40", result.Sunrise);
            Assert.Equal("21:23", result.Sunset);
            Assert.Equal(22, result.Temperature);
            Assert.Equal("Celsius", result.TemperatureUom);
            Assert.Equal(DateTime.Now.AddSeconds(118).ToString("HH:mm"), result.TimeOfArrival);
            Assert.Equal("1 hours and 58 minutes", result.TravelTime);
            Assert.Equal("Michiel", result.UserName);
            Assert.Equal("Sunny", result.WeatherType);
            Assert.False(result.IsOfflineData);
        }

        [Fact]
        public async Task GivenATravelTimeLongerThan60Minutes_ThenTravelTimeIsDisplayedAsHoursAndMinutes()
        {
            // Arrange
            UserInformation information = GetMockUserInformation();
            _weatherMock.Setup(x => x.GetWeatherModelAsync(It.IsAny<string>()))
                .ReturnsAsync(GetMockWeatherModel());

            _trafficMock.Setup(x => x.GetTrafficModelAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(GetMockTrafficModel());

            // Act
            var result = await _app.GenerateViewModel(information);

            // Assert
            Assert.Equal("1 hours and 58 minutes", result.TravelTime);
        }

        [Fact]
        public async Task GivenATravelTimeShorterThan60Minutes_ThenTravelTimeIsDisplayedAsMinutes()
        {
            // Arrange
            var information = GetMockUserInformation();
            information.Town = "London";

            _weatherMock.Setup(x => x.GetWeatherModelAsync(It.IsAny<string>()))
                .ReturnsAsync(GetMockWeatherModel());

            _trafficMock.Setup(x => x.GetTrafficModelAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new TrafficModel
                {
                    Duration = 32 * 60,
                });

            // Act
            var result = await _app.GenerateViewModel(information);

            // Assert
            Assert.Equal("32 minutes", result.TravelTime);
        }

        [Fact]
        public async Task EmptyWeatherInformation_ShouldDisplay_OfflineData()
        {
            // Arrange
            _trafficMock.Setup(x => x.GetTrafficModelAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new TrafficModel
                {
                    Duration = 32 * 60,
                });

            // Act
            var result = await _app.GenerateViewModel(null);

            // Assert
            Assert.True(result.IsOfflineData);
            Assert.Equal("Unknown user", result.UserName);
        }

        [Fact]
        public async Task EmptyTrafficInformation_ShouldDisplay_OfflineData()
        {
            // Arrange 
            _weatherMock.Setup(x => x.GetWeatherModelAsync(It.IsAny<string>()))
               .ReturnsAsync(GetMockWeatherModel());

            // Act
            var result = await _app.GenerateViewModel(null);

            // Assert
            Assert.True(result.IsOfflineData);
            Assert.Equal("Unknown user", result.UserName);
        }

        private WeatherModel GetMockWeatherModel()
        {
            return new WeatherModel
            {
                Location = "London",
                Sunrise = new DateTime(2019, 6, 1, 6, 40, 0).ToLocalTime(),
                Sunset = new DateTime(2019, 6, 1, 19, 23, 0).ToLocalTime(),
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
                TimeOfArrival = DateTime.Now.AddSeconds(118)
            };
        }

        private UserInformation GetMockUserInformation()
        {
            return new UserInformation
            {
                Address = "1 Paris Garden",
                Name = "Michiel",
                Town = "London",
                Zipcode = "SE1 8NU",
                WorkAddress = "Tower Of London"
            };
        }
    }
}