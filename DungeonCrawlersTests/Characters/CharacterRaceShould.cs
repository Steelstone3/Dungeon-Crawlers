using DungeonCrawlers.Game.Characters.CharacterRaces;
using Xunit;

namespace DungeonCrawlersTests.Characters
{
    public class CharacterRaceShould
    {
        [Fact]
        public void ContainsAHeaderForHumans()
        {
            var human = new Human();

            Assert.NotNull(human.Name);
            Assert.Equal("Human", human.Name);
            Assert.NotNull(human.Description);
        }

        [Fact]
        public void ContainsAHeaderForElves()
        {
            var elf = new Elf();

            Assert.NotNull(elf.Name);
            Assert.Equal("Elf", elf.Name);
            Assert.NotNull(elf.Description);
        }

        [Fact]
        public void ContainsAHeaderForDwarves()
        {
            var dwarf = new Dwarf();

            Assert.NotNull(dwarf.Name);
            Assert.Equal("Dwarf", dwarf.Name);
            Assert.NotNull(dwarf.Description);
        }

        [Fact]
        public void ContainsAHeaderForGnomes()
        {
            var gnome = new Gnome();

            Assert.NotNull(gnome.Name);
            Assert.Equal("Gnome", gnome.Name);
            Assert.NotNull(gnome.Description);
        }

        [Fact]
        public void ContainsAHeaderForHalfElves()
        {
            var halfElf = new HalfElf();

            Assert.NotNull(halfElf.Name);
            Assert.Equal("HalfElf", halfElf.Name);
            Assert.NotNull(halfElf.Description);
        }

        [Fact]
        public void ContainsAHeaderForHalfGiants()
        {
            var halfGiant = new HalfGiant();

            Assert.NotNull(halfGiant.Name);
            Assert.Equal("HalfGiant", halfGiant.Name);
            Assert.NotNull(halfGiant.Description);
        }

        [Fact]
        public void ContainsAHeaderForHalfOrcs()
        {
            var halfOrc = new HalfOrc();

            Assert.NotNull(halfOrc.Name);
            Assert.Equal("HalfOrc", halfOrc.Name);
            Assert.NotNull(halfOrc.Description);
        }

        [Fact]
        public void ContainsAHeaderForHalflings()
        {
            var halfling = new Halfling();

            Assert.NotNull(halfling.Name);
            Assert.Equal("Halfling", halfling.Name);
            Assert.NotNull(halfling.Description);
        }

        [Fact]
        public void ContainsAHeaderForLizardfolk()
        {
            var lizardfolk = new Lizardfolk();

            Assert.NotNull(lizardfolk.Name);
            Assert.Equal("Lizardfolk", lizardfolk.Name);
            Assert.NotNull(lizardfolk.Description);
        }

        [Fact]
        public void ContainsAHeaderForOrcs()
        {
            var orc = new Orc();

            Assert.NotNull(orc.Name);
            Assert.Equal("Orc", orc.Name);
            Assert.NotNull(orc.Description);
        }

        [Fact]
        public void ContainsAHeaderForWolfen()
        {
            var wolfen = new Wolfen();

            Assert.NotNull(wolfen.Name);
            Assert.Equal("Wolfen", wolfen.Name);
            Assert.NotNull(wolfen.Description);
        }
    }
}