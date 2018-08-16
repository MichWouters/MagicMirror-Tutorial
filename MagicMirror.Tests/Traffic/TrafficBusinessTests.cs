using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Entities.Traffic;
using Xunit;

namespace MagicMirror.Tests.Traffic
{
    public class TrafficBusinessTests
    {
        private ITrafficService _service;

        // Mock Data
        private const int Duration = 42;

        private const int Distance = 76;
        private const string Origin = "London, Uk";
        private const string Destination = "Leeds, Uk";

        public TrafficBusinessTests()
        {
            _service = new TrafficService();
        }

        [Fact]
        public void Can_Map_From_Entity()
        {
            // Arrange
            TrafficEntity entity = GetMockEntity();

            // Act
            TrafficModel model = _service.MapFromEntity(entity);

            // Assert
            Assert.Equal(Distance, model.Distance);
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