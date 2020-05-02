using MagicMirror.DataAccess.Entities.Traffic;
using MagicMirror.DataAccess.Repos;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MagicMirror.Tests.Traffic
{
    public class GoogleMapsTrafficDataTests
    {
        private IGoogleMapsRepo _repo;

        public GoogleMapsTrafficDataTests()
        {
            _repo = new GoogleMapsRepo();
        }

        [Fact(Skip = "No longer using Google Maps")]
        public async Task Can_Retrieve_Traffic_Data()
        {
            // Arrange
            string start = "London, UK";
            string destination = "Brighton, UK";

            // Act
            GoogleMapsTrafficEntity entity = await _repo.GetTrafficInfoAsync(start, destination);

            // Assert
            Assert.NotNull(entity);
            Assert.Equal("OK", entity.Status);
        }

        [Fact(Skip = "No longer using Google Maps")]
        public async Task Return_Type_Should_Be_TrafficEntity()
        {
            // Arrange
            string start = "London, UK";
            string destination = "Brighton, UK";

            // Act
            var entity = await _repo.GetTrafficInfoAsync(start, destination);

            // Assert
            Assert.IsType<GoogleMapsTrafficEntity>(entity);
        }

        [Fact(Skip = "No longer using Google Maps")]
        public async Task Empty_Input_Should_Throw_ArgumentNull()
        {
            // Arrange
            string start = "";
            string destination = "Brighton, UK";

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>
                (async () => await _repo.GetTrafficInfoAsync(start, destination));
        }

        [Fact(Skip = "No longer using Google Maps")]
        public async Task No_Traffic_Found_Should_Throw_HttpRequest()
        {
            // Arrange
            string start = "FEIFJIEFUESFYU";
            string destination = "FOOBAR";

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>
                (async () => await _repo.GetTrafficInfoAsync(start, destination));
        }
    }
}