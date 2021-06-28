using DungeonCrawlers.Game.CharacterRaces;
using DungeonCrawlers.Game.Characters.CharacterRaces;
using Xunit;

namespace DungeonCrawlersTests.Characters
{
    public class CharacterRaceShould
    {
        [Fact]
        public void HaveARaceNameAndDescriptionForHumans()
        {
            var human = new Human();

            Assert.NotNull(human.Name);
            Assert.NotNull(human.Description);
        }

        [Fact]
        public void HaveARaceNameAndDescriptionForElves()
        {
            var elf = new Elf();

            Assert.NotNull(elf.Name);
            Assert.NotNull(elf.Description);
        }

        [Fact]
        public void HaveARaceNameAndDescriptionForDwarves()
        {
            var dwarf = new Dwarf();

            Assert.NotNull(dwarf.Name);
            Assert.NotNull(dwarf.Description);
        }
    }
}