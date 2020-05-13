using MagicMirror.DataAccess.Entities.Entities;
using MagicMirror.DataAccess.Repos;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MagicMirror.Tests.Traffic
{
    public class OpenMapTrafficDataTests
    {
        private IOpenMapTrafficRepo _repo;

        public OpenMapTrafficDataTests()
        {
            _repo = new OpenMapTrafficRepo();
        }

        [Fact]
        public async Task Can_Retrieve_Traffic_Data()
        {
            // Arrange
            string start = "London, UK";
            string destination = "Brighton, UK";

            // Act
            var entity = await _repo.GetTrafficInfoAsync(start, destination);

            // Assert
            Assert.NotNull(entity);
            Assert.Equal(0, entity.Info.Statuscode);
        }

        [Fact]
        public async Task Return_Type_Should_Be_OpenMapTrafficEntity()
        {
            // Arrange
            string start = "London, UK";
            string destination = "Brighton, UK";

            // Act
            var entity = await _repo.GetTrafficInfoAsync(start, destination);

            // Assert
            Assert.IsType<OpenMapTrafficEntity>(entity);
        }

        [Fact]
        public async Task Empty_Input_Should_Throw_ArgumentNull()
        {
            // Arrange
            string start = "";
            string destination = "Brighton, UK";

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>
                (async () => await _repo.GetTrafficInfoAsync(start, destination));
        }

        [Fact]
        [Trait("Category", "Slow")]
        public async Task No_Traffic_Found_Should_Throw_HttpRequest()
        {
            // Arrange
            string start = "-1";
            string destination = "-2";

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>
                (async () => await _repo.GetTrafficInfoAsync(start, destination));
        }
    }
}