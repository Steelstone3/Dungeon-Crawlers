using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Services;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Services
{
    public class DungeonCreationServiceShould
    {
        [Fact]
        public void GenerateDungeon()
        {
            var dungeonController = new Mock<IDungeonController>();
            dungeonController.Setup(x => x.GenerateRooms());
            dungeonController.Setup(x => x.GenerateEncounters());

            var dungeonCreationService = new DungeonCreationService();

            dungeonCreationService.GenerateDungeon(dungeonController.Object);

            dungeonController.Verify(x => x.GenerateRooms());
            dungeonController.Verify(x => x.GenerateEncounters());
        }
    }
}