using DungeonCrawlers.Game.CharacterRaces;
using DungeonCrawlers.Game.Characters;
using DungeonCrawlers.Game.CombatClasses;
using Xunit;

namespace DungeonCrawlersTests
{
    public class CharacterShould
    {
        [Fact]
        public void GenerateACharacter()
        {
            var character = new Character();

            Assert.NotNull(character);
            Assert.NotNull(character.Name);
            Assert.NotNull(character.Description);

            Assert.NotNull(character.CombatClass);
            Assert.NotNull(character.CharacterRace);
        }

        [Theory]
        [InlineData("Steve")]
        [InlineData("Bob")]
        [InlineData("Terry")]
        public void HaveAName(string name)
        {
            var character = new Character(name);

            Assert.Equal(name, character.Name);

            Assert.NotNull(character);
            Assert.NotNull(character.Name);
            Assert.NotNull(character.Description);

            Assert.NotNull(character.CombatClass);
            Assert.NotNull(character.CharacterRace);
        }

        [Fact]
        public void HaveARace()
        {
            var human = new Human();
            var character = new Character(human);

            Assert.Equal(human, character.CharacterRace);

            Assert.NotNull(character);
            Assert.NotNull(character.Name);
            Assert.NotNull(character.Description);

            Assert.NotNull(character.CombatClass);
            Assert.NotNull(character.CharacterRace);
        }

        [Fact]
        public void HaveACombatClass()
        {
            var wizard = new Wizard();
            var character = new Character(wizard);

            Assert.Equal(wizard, character.CombatClass);

            Assert.NotNull(character);
            Assert.NotNull(character.Name);
            Assert.NotNull(character.Description);

            Assert.NotNull(character.CombatClass);
            Assert.NotNull(character.CharacterRace);
        }

        [Fact]
        public void HaveARaceAndCombatClass()
        {
            var elf = new Elf();
            var wizard = new Wizard();
            var character = new Character(elf, wizard);

            Assert.Equal(elf, character.CharacterRace);
            Assert.Equal(wizard, character.CombatClass);

            Assert.NotNull(character);
            Assert.NotNull(character.Name);
            Assert.NotNull(character.Description);

            Assert.NotNull(character.CombatClass);
            Assert.NotNull(character.CharacterRace);
        }

        [Theory]
        [InlineData("Steve")]
        [InlineData("Harry")]
        [InlineData("Dave")]
        public void HaveANameRaceAndCombatClass(string name)
        {
            var elf = new Elf();
            var wizard = new Wizard();
            var character = new Character(name, elf, wizard);

            Assert.Equal(name, character.Name);
            Assert.Equal(elf, character.CharacterRace);
            Assert.Equal(wizard, character.CombatClass);

            Assert.NotNull(character);
            Assert.NotNull(character.Name);
            Assert.NotNull(character.Description);

            Assert.NotNull(character.CombatClass);
            Assert.NotNull(character.CharacterRace);
        }
    }
}