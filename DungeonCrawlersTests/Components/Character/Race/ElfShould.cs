using DungeonCrawlers.Components.Character.Race;
using Xunit;

namespace DungeonCrawlersTests.Components.Character.Race
{
    public class ElfShould
    {
        [Fact]
        public void ContainRace()
        {
            var race = new Elf();

            Assert.Equal("Elf", race.getCharacterRace());
        }
    }
}