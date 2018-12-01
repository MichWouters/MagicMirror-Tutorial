using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MagicMirror.Tests.Weather
{
    public class WeatherDataTests
    {
        private readonly IWeatherRepo _repo;

        public WeatherDataTests()
        {
            _repo = new WeatherRepo();
        }

        [Fact]
        public async Task Can_Retrieve_Weather_Data()
        {
            // Arrange
            string city = "London";

            // Act
            WeatherEntity entity = await _repo.GetWeatherEntityByCityAsync(city);

            // Assert
            Assert.NotNull(entity);
            Assert.Equal(city, entity.Name);
        }

        [Fact]
        public async Task Return_Type_Should_Be_WeatherEntity()
        {
            // Arrange
            string city = "London";

            // Act
            var entity = await _repo.GetWeatherEntityByCityAsync(city);

            // Assert
            Assert.IsType<WeatherEntity>(entity);
        }

        [Fact]
        public async Task No_Input_Should_Throw_ArgumentNull()
        {
            // Arrange
            string city = "";

            // Act
            var method = _repo.GetWeatherEntityByCityAsync(city);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await method);
        }

        [Fact]
        public async Task No_City_Found_Should_Throw_HttpRequest()
        {
            // Arrange
            string city = "FEIFJIEFUESFYU";

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>
                (async () => await _repo.GetWeatherEntityByCityAsync(city));
        }
    }
}