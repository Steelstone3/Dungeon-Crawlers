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
            gamePresenter.Verify();
            Assert.NotNull(result);
        }
    }
}