using DungeonCrawlers.Game.Characters.Races;
using Xunit;

namespace DungeonCrawlersTests.Game.Characters.Races
{
    public class DwarfShould
    {
        [Fact]
        public void ContainAHeader()
        {
            var dwarf = new Dwarf();

            Assert.NotNull(dwarf);
            Assert.Equal("Dwarf", dwarf.Name);
            Assert.NotNull(dwarf.Description);
        } 
    }
}