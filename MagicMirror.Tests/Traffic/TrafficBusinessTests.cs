using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Entities.Traffic;
using MagicMirror.DataAccess.Repos;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MagicMirror.Tests.Traffic
{
    public class TrafficBusinessTests
    {
        private readonly ITrafficService _service;

        // Mock Data
        private const int Duration = 42;
        private const int Distance = 76;
        private const string Origin = "London, Uk";
        private const string Destination = "Leeds, Uk";

        public TrafficBusinessTests()
        {
            var mockRepo = new Mock<ITrafficRepo>();
            _service = new TrafficService(mockRepo.Object);

            // Arrange
            mockRepo.Setup(x => x.GetTrafficInfoAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(GetMockEntity());
        }

        [Fact]
        public async Task Calculate_Values_Correctly()
        {
            // Arrange
            DateTime timeOfArrival = DateTime.Now.AddMinutes(Duration);

            // Act
            TrafficModel model = await _service.GetTrafficModelAsync(Origin, Destination);

            // Assert
            Assert.Equal(122.31, model.Distance);
            Assert.Equal(timeOfArrival.Hour, model.TimeOfArrival.Hour);
            Assert.Equal(timeOfArrival.Minute, model.TimeOfArrival.Minute);
        }

        [Fact]
        public async Task Can_Map_From_Entity()
        {
            // Act
            TrafficModel model = await _service.GetTrafficModelAsync(Origin, Destination);

            // Assert
            Assert.Equal(Duration, model.Duration);
            Assert.Equal(Destination, model.Destination);
            Assert.Equal(Origin, model.Origin);
        }

        private TrafficEntity GetMockEntity()
        {
            var element = new Element
            {
                Distance = new Distance { Value = Distance },
                Duration = new Duration { Value = Duration },
            };

            var entity = new TrafficEntity
            {
                Origin_addresses = new[] { Origin },
                Destination_addresses = new[] { Destination },
                Rows = new[]
                {
                    new Row
                    {
                        Elements = new [] {element}
                    }
                }
            };
            return entity;
        }
    }
}