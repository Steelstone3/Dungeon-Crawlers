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
            gamePresenter.Setup(gp => gp.CreateCharacter()).Returns(character.Object);

            // When
            var results = characterCreationSystem.CreateMultiple(4);

            // Then
            gamePresenter.VerifyAll();
            Assert.NotNull(results);
            Assert.NotEmpty(results);
        }
    }
}