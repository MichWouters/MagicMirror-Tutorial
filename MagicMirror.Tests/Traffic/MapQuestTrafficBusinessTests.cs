﻿using AutoMapper;
using MagicMirror.Business.Configuration;
using MagicMirror.Business.Enums;
using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Entities.Entities;
using MagicMirror.DataAccess.Repos;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MagicMirror.Tests.Traffic
{
    public class MapQuestTrafficBusinessTests
    {
        private ITrafficService _service;

        // Mock Data
        private const int Duration = 42;
        private const int Distance = 76;
        private const string Origin = "London, Uk";
        private const string Destination = "Leeds, Uk";

        // Mock objects
        private Mock<IMapQuestTrafficRepo> mockRepo;

        public MapQuestTrafficBusinessTests()
        {
            mockRepo = new Mock<IMapQuestTrafficRepo>();

            // Initialize AutoMapper for Unit Tests
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperBusinessProfile>();
            });

            IMapper mapper = config.CreateMapper();

            // Initialize Service with Dependencies
            _service = new MapQuestTrafficService(mockRepo.Object, mapper);
        }

        [Fact]
        public async Task Calculate_Values_Correctly()
        {
            // Arrange
            mockRepo.Setup(x => x.GetTrafficInfoAsync(
                It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(GetMockEntity());

            DateTime timeOfArrival = DateTime.Now.AddSeconds(Duration);

            // Act
            TrafficModel model = await _service.GetTrafficModelAsync(Origin, Destination);

            // Assert
            Assert.Equal(122.31, model.Distance);
            Assert.Equal(DistanceUom.Metric, model.DistanceUom);
            Assert.Equal(timeOfArrival.Hour, model.TimeOfArrival.Hour);
            Assert.Equal(timeOfArrival.Minute, model.TimeOfArrival.Minute);
        }

        [Fact]
        public async Task Repo_GetEntity_Called_Once()
        {
            // Arrange
            mockRepo.Setup(x => x.GetTrafficInfoAsync(
                It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(GetMockEntity());

            // Act
            TrafficModel model = await _service.GetTrafficModelAsync(Origin, Destination);

            // Assert
            mockRepo.Verify(x => x.GetTrafficInfoAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        private MapQuestTrafficEntity GetMockEntity()
        {
            return new MapQuestTrafficEntity
            {
                Info = new DataAccess.Entities.MapQuestTraffic.Info
                {
                    Statuscode = 0
                },
                Route = new DataAccess.Entities.MapQuestTraffic.Route
                {
                    Distance = Distance,
                    Time = Duration,
                }
            };
        }
    }
}