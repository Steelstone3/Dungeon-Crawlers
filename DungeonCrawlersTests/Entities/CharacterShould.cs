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
        private readonly ICharacter character;

        public CharacterShould()
        {
            character = new Character(name.Object, race.Object);
        }

        [Fact]
        public void ContainCharacterName()
        {
            // Then
            Assert.NotNull(character.Name);
        }

        [Fact]
        public void ContainCharacterRace()
        {
            // Then
            Assert.NotNull(character.Race);
        }
    }
}