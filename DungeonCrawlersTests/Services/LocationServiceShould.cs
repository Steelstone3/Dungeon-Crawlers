using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Services;
using DungeonCrawlers.States;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Services
{
    public class LocationServiceShould
    {
        [Fact]
        public void GenerateLocations()
        {
            var locationBuilder = new Mock<ILocationBuilder>();
            var locationController = new Mock<ILocationController>();
            locationController.Setup(x => x.GenerateSettlements(locationBuilder.Object));
            locationController.Setup(x => x.GenerateDungeons(locationBuilder.Object));

            var locationService = new LocationService();

            locationService.GenerateLocations(locationController.Object, locationBuilder.Object);

            locationController.Verify(x => x.GenerateSettlements(locationBuilder.Object));
            locationController.Verify(x => x.GenerateDungeons(locationBuilder.Object));
        }
    }
}