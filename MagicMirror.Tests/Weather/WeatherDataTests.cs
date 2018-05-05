using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using System;
using System.Collections.Generic;
using System.Text;
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
        public void Can_Retrieve_Weather_Data()
        {
            // Arrange
            WeatherEntity entity = null;
            string city = "London";

            // Act
            entity = _repo.GetWeatherEntityByCityAsync(city);
        }
    }
}