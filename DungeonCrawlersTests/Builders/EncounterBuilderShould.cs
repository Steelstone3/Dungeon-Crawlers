using DungeonCrawlers.Builders;
using DungeonCrawlers.Contracts.Controllers;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Builders
{
    public class EncounterBuilderShould
    {
        [Fact]
        public void BuildCombatEncounters()
        {
            var enemyController = new Mock<IEnemyController>();
            var encounterBuilder = new EncounterBuilder();

            var encounters = encounterBuilder.BuildCombatEncounters(enemyController.Object);

            Assert.NotNull(encounters);
            Assert.NotEmpty(encounters);
        }
    }
}