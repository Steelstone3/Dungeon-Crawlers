using DungeonCrawlers.Controllers;
using DungeonCrawlers.Game.Encounters;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Game.Locations
{
    public class CombatEncounterShould
    {
        [Fact]
        public void GenerateEncounter()
        {
            var enemyController = new Mock<IEnemyController>();
            enemyController.Setup(x => x.GenerateEnemies());

            var combatEncounter = new CombatEncounter(enemyController.Object);

            enemyController.Verify(x => x.GenerateEnemies());
        }
    }
}