using MagicMirror.DataAccess.Entities.Weather;
using Xunit;

namespace MagicMirror.Tests.Weather
{
    public class WeatherBusinessTest
    {
        [Fact]
        public WeatherEntity GetMockWeatherData()
        {
            // Arrange
            var mockWeatherRepo = WeatherMocks.GetWeatherRepo();
            string city = "London";

            // Act
            var result = mockWeatherRepo.Object.GetWeatherEntityByCityAsync(city).Result;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(city, result.Name);

            return result;
        }
    }
}