using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Game.Locations;
using DungeonCrawlers.Game.Locations;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Game.Locations
{
    public class DungeonShould
    {
        [Fact]
        public void ContainRooms()
        {
            //Given
            var encounterBuilder = new Mock<IEncounterBuilder>();
            var enemyController = new Mock<IEnemyController>();
            IDungeon dungeon = new Dungeon(encounterBuilder.Object, enemyController.Object);

            //Then
            Assert.NotNull(dungeon.Rooms);
            Assert.NotEmpty(dungeon.Rooms);
            Assert.InRange(dungeon.Rooms.Count, 1, 10);
        }
    }
}