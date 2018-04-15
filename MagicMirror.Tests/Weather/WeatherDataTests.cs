using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;
using Xunit;

namespace MagicMirror.Tests.Weather
{
    public class WeatherDataTests
    {
        private IWeatherRepo _repo;

        public WeatherDataTests()
        {
            _repo = new WeatherRepo();
        }

        [Fact]
        public async Task Can_Fetch_Weather_Data()
        {
            // Arrange
            WeatherEntity entity = null;
            string city = "London";

            // Act
            entity = await _repo.GetWeatherEntityByCityAsync(city);

            // Assert
            Assert.NotNull(entity);
            Assert.Equal(city, entity.Name);
        }

        [Fact]
        public void FooBar()
        {
            // Arrange
            var mockWeatherRepo = WeatherMocks.GetWeatherRepo();

            // Act
            var result = mockWeatherRepo.Object.Foo();

            // Assert
            Assert.Equal("bar", result);
        }
    }
}