using DungeonCrawlers.Game.Characters.Races;
using Xunit;

namespace DungeonCrawlersTests.Game.Characters.Races
{
    public class ElfShould
    {
        [Fact]
        public void ContainAHeader()
        {
            var elf = new Elf();

            Assert.NotNull(elf);
            Assert.Equal("Elf", elf.Name);
            Assert.NotNull(elf.Description);
        } 
    }
}