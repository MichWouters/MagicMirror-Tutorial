using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Entities.Traffic;
using MagicMirror.DataAccess.Repos;
using Moq;
using System;
using Xunit;
using AutoMapper;
using MagicMirror.Business.Configuration;
using System.Threading.Tasks;

namespace MagicMirror.Tests.Traffic
{
    public class TrafficBusinessTests
    {
        private Mock<ITrafficRepo> _mockRepo;
        private ITrafficService _service;

        // Mock Data
        private const int Duration = 42;
        private const int Distance = 76;
        private const string Origin = "London, Uk";
        private const string Destination = "Leeds, Uk";

        public TrafficBusinessTests()
        {
            // Initialize AutoMapper for Unit Tests
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperBusinessProfile>();
            });

            IMapper mapper = config.CreateMapper();

            // Initialize Service with Dependencies
            _mockRepo = new Mock<ITrafficRepo>();
            _service = new TrafficService();
        }

        [Fact]
        public async Task Calculate_Values_Correctly()
        {
            // Arrange
            _mockRepo.Setup(x => x.GetTrafficInfoAsync(
                It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(GetMockEntity());

            DateTime timeOfArrival = DateTime.Now.AddSeconds(Duration);

            // Act
            TrafficModel model = await _service.GetTrafficModelAsync(Origin, Destination);
            model.ConvertValues();

            // Assert
            Assert.Equal(122.31, model.Distance);
            Assert.Equal(timeOfArrival.Hour, model.TimeOfArrival.Hour);
            Assert.Equal(timeOfArrival.Minute, model.TimeOfArrival.Minute);
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