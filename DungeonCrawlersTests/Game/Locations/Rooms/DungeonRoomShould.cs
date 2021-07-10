using System.Collections.Generic;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Encounters;
using DungeonCrawlers.Game.Locations.Rooms;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Game.Locations.Rooms
{
    public class DungeonRoomShould
    {
        [Fact]
        public void BuildEncounters()
        {
            var encounterBuilder = new Mock<IEncounterBuilder>();
            var enemyController = new Mock<IEnemyController>();
            encounterBuilder.Setup(x => x.BuildCombatEncounters(enemyController.Object)).Returns(new List<IHostileEncounter>());
            var dungeonRoom = new DungeonRoom(encounterBuilder.Object, enemyController.Object);

            encounterBuilder.Verify(x => x.BuildCombatEncounters(enemyController.Object));
        }
    }
}