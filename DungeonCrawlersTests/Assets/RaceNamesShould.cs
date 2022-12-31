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

        [Theory]
        [InlineData(1111, "Half-Elf")]
        [InlineData(-122, "Bunny-Folk")]
        [InlineData(5656, "Giant")]
        public void GetRandomRace(int seed, string randomName)
        {
            // When
            string race = RaceNames.GetRandomRace(seed);

            // Then
            Assert.Equal(randomName, race);
        }
    }
}