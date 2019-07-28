using AutoMapper;
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

        private Mock<ITrafficRepo> mockRepo;
        private readonly Mock<IMapper> mockMapper;

        public TrafficBusinessTests()
        {
            // Setup mocking behaviour
            mockRepo = new Mock<ITrafficRepo>();
            mockMapper = new Mock<IMapper>();

            // Initialize Service with Dependencies
            _service = new TrafficService(mockRepo.Object, mockMapper.Object);
        }

        [Fact]
        public async Task Calculate_Values_Correctly()
        {
            // Arrange
            DateTime timeOfArrival = DateTime.Now.AddSeconds(Duration);
            mockRepo.Setup(x => x.GetTrafficInfoAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(GetMockEntity());

            mockMapper.Setup(x => x.Map<TrafficModel>(It.IsAny<TrafficEntity>()))
                .Returns(GetMockMappedModel());

            // Act
            TrafficModel model = await _service.GetTrafficModelAsync(Origin, Destination);
            model.InitializeModel();

            // Assert
            Assert.Equal(122.31, model.Distance);
            Assert.Equal(timeOfArrival.Hour, model.TimeOfArrival.Hour);
            Assert.Equal(timeOfArrival.Minute, model.TimeOfArrival.Minute);
        }

        [Fact]
        public async Task Repo__GetModel_Called_Once()
        {
            // Arrange
            mockRepo.Setup(x => x.GetTrafficInfoAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(GetMockEntity());

            mockMapper.Setup(x => x.Map<TrafficModel>(It.IsAny<TrafficEntity>()))
                .Returns(GetMockMappedModel());

            // Act
            var model = await _service.GetTrafficModelAsync("foo", "bar");

            // Assert
            mockRepo.Verify(x => x.GetTrafficInfoAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
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


        private TrafficModel GetMockMappedModel()
        {
            return new TrafficModel
            {
                Destination = Destination,
                Distance = Distance,
                DistanceUom = Business.Enums.DistanceUom.Imperial,
                Duration = Duration,
                Origin = Origin,
                TimeOfArrival = DateTime.Now.AddSeconds(Duration)
            };
        }
    }
}