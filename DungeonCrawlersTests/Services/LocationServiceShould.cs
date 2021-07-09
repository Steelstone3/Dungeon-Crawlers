using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Services;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Services
{
    public class LocationServiceShould
    {
        [Fact]
        public void GenerateDungeon()
        {
            var dungeonBuilder = new Mock<IDungeonBuilder>();
            var dungeonController = new Mock<IDungeonController>();
            dungeonController.Setup(x => x.GenerateDungeons(dungeonBuilder.Object));
            var dungeonCreationService = new LocationService();

            dungeonCreationService.GenerateDungeons(dungeonController.Object, dungeonBuilder.Object);

            dungeonController.Verify(x => x.GenerateDungeons(dungeonBuilder.Object));
        }

        [Fact]
        public void DisplayLocations()
        {
            var displayer = new Mock<IDisplayer>();
            var dungeonController = new Mock<IDungeonController>();
            dungeonController.Setup(x => x.DisplayDungeons(displayer.Object));
            
            var locationService = new LocationService();

            locationService.DisplayLocations(displayer.Object, dungeonController.Object);

            dungeonController.Verify(x => x.DisplayDungeons(displayer.Object));
        }

        [Fact(Skip ="Next test")]
        public void SelectLocation()
        {
            
        }
    }
}