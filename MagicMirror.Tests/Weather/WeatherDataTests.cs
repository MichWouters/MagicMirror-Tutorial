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
        private IWeatherRepo _repo;

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
        public async Task Not_Found_Should_Throw_HttpRequestException()
        {
            // Arrange
            string city = "gdrsgrdgdr";

            // Act
            var ex = await Assert.ThrowsAsync<HttpRequestException>
                (async () => await _repo.GetWeatherEntityByCityAsync(city));
        }

        [Fact]
        public async Task No_Input_Should_Throw_ArgumentNullException()
        {
            // Arrange
            string city = "";

            // Act
            var ex = await Assert.ThrowsAsync<ArgumentNullException>
                (async () => await _repo.GetWeatherEntityByCityAsync(city));
        }
    }
}