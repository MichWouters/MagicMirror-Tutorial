using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MagicMirror.Tests.Weather
{
    public class WeatherDataTests
    {
        private WeatherRepo _repo;

        public WeatherDataTests()
        {
            _repo = new WeatherRepo();
        }

        [Fact]
        public async Task Can_Retrieve_Weather_Data()
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
        public async Task Return_Object_Should_Be_WeatherEntity()
        {
            // Arrange
            string city = "London";

            // Act
            var entity = await _repo.GetWeatherEntityByCityAsync(city);

            // Assert
            Assert.IsType<WeatherEntity>(entity);
        }
    }
}