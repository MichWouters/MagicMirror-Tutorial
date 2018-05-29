using MagicMirror.DataAccess.Entities.Traffic;
using MagicMirror.DataAccess.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MagicMirror.Tests.Traffic
{
    public class TrafficDataTests
    {
        private ITrafficRepo _repo;

        public TrafficDataTests()
        {
            _repo = new TrafficRepo();
        }

        [Fact]
        public async Task Can_Retrieve_Traffic_Data()
        {
            // Arrange
            TrafficEntity entity = null;
            string start = "London, UK";
            string destination = "Brighton, UK";

            // Act
            entity = await _repo.GetTrafficInfoAsync(start, destination);

            // Assert
            Assert.NotNull(entity);
            Assert.Equal("OK", entity.Status);
        }

        [Fact]
        public async Task Empty_Input_Should_Throw_ArgumentNull()
        {
            // Arrange
            TrafficEntity entity = null;
            string start = "";
            string destination = "Brighton, UK";

            // Act & Assert
            var ex = await Assert.ThrowsAsync<ArgumentNullException>
                (async () => await _repo.GetTrafficInfoAsync(start, destination));
        }
    }
}