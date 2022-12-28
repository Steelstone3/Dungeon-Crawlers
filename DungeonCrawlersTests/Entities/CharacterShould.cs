using DungeonCrawlers.Components;
using DungeonCrawlers.Entities;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Entities
{
    public class CharacterShould
    {
        private Mock<IName> name = new();
        private Mock<IRace> race = new();
        private Mock<IHealth> health = new();
        private Mock<IArmour> armour = new();
        private readonly ICharacter character;

        public CharacterShould()
        {
            character = new Character(name.Object, race.Object, health.Object, armour.Object);
        }

        [Fact]
        public void ContainsCharacterName()
        {
            // Then
            Assert.NotNull(character.Name);
        }

        [Fact]
        public void ContainsCharacterRace()
        {
            // Then
            Assert.NotNull(character.Race);
        }

        [Fact]
        public void ContainsCharacterHealth()
        {
            // Then
            Assert.NotNull(character.Health);
        }

        [Fact]
        public void ContainsCharacter()
        {
            // Then
            Assert.NotNull(character.Armour);
        }
    }
}