using DungeonCrawlers.Game.Characters;
using DungeonCrawlers.Game.Characters.Races;
using DungeonCrawlers.Game.Combat.CombatRoles;
using Xunit;

namespace DungeonCrawlersTests.Game
{
    public class CharacterShould
    {
        [Theory]
        [InlineData("Bob")]
        [InlineData("Steve")]
        public void PopulateClassFromAName(string name)
        {
            var character = new Character(name);

            Assert.NotNull(character);
            Assert.Equal(name, character.Name);
            Assert.NotNull(character.Race);
            Assert.NotNull(character.CombatRole);
        }

        [Fact]
        public void PopulateClassFromSetupParameters()
        {
            var name = "Steven";
            var character = new Character(name, new Elf(), new Wizard());

            Assert.NotNull(character);
            Assert.Equal(name, character.Name);
            Assert.NotNull(character.Race);
            Assert.NotNull(character.CombatRole);
        }
    }
}