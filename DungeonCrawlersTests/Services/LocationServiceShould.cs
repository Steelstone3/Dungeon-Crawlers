using DungeonCrawlers.Services;
using DungeonCrawlers.States;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Services
{
    public class locationServiceShould
    {
        [Fact]
        public void GenerateLocations()
        {
            var locationController = new Mock<ILocationController>();
            locationController.Setup(x => x.GenerateSettlements());
            locationController.Setup(x => x.GenerateDungeons());

            var locationService = new LocationService();

            locationService.GenerateLocations(locationController.Object);

            locationController.Verify(x => x.GenerateSettlements());
            locationController.Verify(x => x.GenerateDungeons());
        }
    }
}