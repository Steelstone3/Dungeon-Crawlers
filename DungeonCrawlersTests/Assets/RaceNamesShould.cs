using DungeonCrawlers.Assets;
using Xunit;

namespace DungeonCrawlersTests.Assets
{
    public class RaceNamesShould
    {
        [Fact]
        public void ContainRaceNames()
        {
            // Then
            Assert.NotEmpty(RaceNames.Races);
        }
    }
}