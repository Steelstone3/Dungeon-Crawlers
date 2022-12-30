using System.Collections.Generic;
using System.Linq;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Presenters;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Systems
{
    public class CharacterCreationSystemShould
    {
        private readonly Mock<IGamePresenter> gamePresenter = new();
        private readonly Mock<ICharacter> character = new();
        private readonly ICharacterCreationSystem characterCreationSystem;

        public CharacterCreationSystemShould()
        {
            characterCreationSystem = new CharacterCreationSystem(gamePresenter.Object);
        }

        [Fact]
        public void Create()
        {
            // Given
            gamePresenter.Setup(gp => gp.CreateCharacter()).Returns(character.Object);

            // When
            var result = characterCreationSystem.Create();

            // Then
            gamePresenter.VerifyAll();
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateMultiple()
        {
            // Given
            var seeds = new int[] { 1111, -122, 5656 };

            // When
            var results = characterCreationSystem.CreateMultiple(3, seeds).ToArray();

            // Then
            gamePresenter.VerifyAll();
            Assert.NotNull(results);
            Assert.NotEmpty(results);

            Assert.Equal("Master", results[0].Name.Prefix);
            Assert.Equal("Bob", results[0].Name.FirstName);
            Assert.Equal("Harken", results[0].Name.Surname);
            Assert.Equal("Jr", results[0].Name.Suffix);

            Assert.Equal("Count", results[1].Name.Prefix);
            Assert.Equal("April", results[1].Name.FirstName);
            Assert.Equal("Billiston", results[1].Name.Surname);
            Assert.Equal("", results[1].Name.Suffix);

            Assert.Equal("Lady", results[2].Name.Prefix);
            Assert.Equal("Bill", results[2].Name.FirstName);
            Assert.Equal("Bobbinton", results[2].Name.Surname);
            Assert.Equal("III", results[2].Name.Suffix);
        }
    }
}