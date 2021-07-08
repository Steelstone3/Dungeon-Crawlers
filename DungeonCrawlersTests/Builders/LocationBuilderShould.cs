using DungeonCrawlers.Builders;
using DungeonCrawlers.Contracts.Builders;
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
                var locationBuilder = new LocationBuilder(encounterBuilder.Object, enemyController.Object);

                var dungeons = locationBuilder.BuildDungeons();

                Assert.NotNull(dungeons);
                Assert.NotEmpty(dungeons);
                Assert.InRange(dungeons.Count, 1, 10);
            }

            [Fact(Skip="Not implemented yet")]
            public void BuildASettlement()
            {
                
            }

    }
}