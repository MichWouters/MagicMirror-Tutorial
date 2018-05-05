using MagicMirror.DataAccess.Entities.Traffic;
using MagicMirror.DataAccess.Repos;
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
            string start = "London";
            string destination = "Brighton";

            // Act
            entity = await _repo.GetTrafficInfoAsync(start, destination);

            // Assert
            Assert.NotNull(entity);
        }
    }
}