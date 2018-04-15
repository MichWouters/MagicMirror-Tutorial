using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using Moq;
using System.Threading.Tasks;

namespace MagicMirror.Tests.Weather
{
    public static class WeatherMocks
    {
        public static Mock<IWeatherRepo> GetWeatherRepo()
        {
            var entity = GenerateMockWeatherData();
            var mockWeatherEntity = new Mock<IWeatherRepo>();

            mockWeatherEntity.Setup(repo => repo
                        .GetWeatherEntityByCityAsync(It.IsAny<string>()))
                        .Returns(Task.FromResult(entity));

            mockWeatherEntity.Setup(repo => repo
                        .Foo())
                        .Returns("bar");

            return mockWeatherEntity;
        }

        // Provide dummy mock data for unit tests
        private static WeatherEntity GenerateMockWeatherData()
        {
            var entity = new WeatherEntity
            {
                Coord = new Coord
                {
                    Lat = -71.06f,
                    Lon = 42.36f
                },
                Clouds = new Clouds
                {
                },
                Cod = 200,
                Dt = 1521392160,
                Id = 1274,
                Main = new Main
                {
                    Temp = 270.42f,
                    Pressure = 1011,
                    Humidity = 23,
                    Temp_max = 271.15f,
                    Temp_min = 269.15f
                },
                Name = "London",
                Sys = new Sys
                {
                    Type = 1,
                    Id = 1274,
                    Message = 0.0037f,
                    Country = "UK",
                    Sunrise = 1521370180,
                    Sunset = 1521413703
                },
                Visibility = 16093,
                Weather = new DataAccess.Entities.Weather.Weather[]
                {
                    new DataAccess.Entities.Weather.Weather{
                    Id= 801,
                    Main = "Clouds",
                    Description="few clouds",
                    Icon="02d"
                    }
                },
                Wind = new Wind
                {
                    Deg = 320,
                    Speed = 7.7f
                },
                _base = "stations"
            };

            return entity;
        }
    }
}