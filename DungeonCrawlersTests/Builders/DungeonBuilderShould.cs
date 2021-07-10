using DungeonCrawlers.Builders;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlersTests.Game.Locations;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Builders
{
    public class LocationBuilderShould
    {
            [Fact]
            public void BuildADungeon()
            {
                var encounterBuilder = new Mock<IEncounterBuilder>();
                var enemyController = new Mock<IEnemyController>();
                var locationBuilder = new DungeonBuilder(encounterBuilder.Object, enemyController.Object);

                var dungeons = locationBuilder.BuildDungeons();

                Assert.NotNull(dungeons);
                Assert.NotEmpty(dungeons);
                Assert.InRange(dungeons.Count, 1, 10);
            }
    }
}