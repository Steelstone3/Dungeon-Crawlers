using System.Collections.Generic;
using DungeonCrawlers.Controllers;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Presenters;
using DungeonCrawlers.States;
using DungeonCrawlers.Systems;
using DungeonCrawlersTests.Systems;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.States
{
    public class CharacterCreationStateShould
    {
        private readonly Mock<ICharacter> character = new();
        private readonly Mock<IPresenter> presenter = new();
        private readonly Mock<ICharacterCreationSystem> characterCreation = new();
        private readonly Mock<IGameRepository> gameRepo = new();
        private readonly Mock<IGameStateRepository> gameStateRepo = new();
        private readonly int[] seeds = new int[] { 1, 1, 1 };
        private readonly IGameState gameState;

        public CharacterCreationStateShould()
        {
            gameRepo.Setup(gp => gp.CharacterParty).Returns(new List<ICharacter>());
            gameState = new CharacterCreationState(gameStateRepo.Object, presenter.Object, gameRepo.Object, characterCreation.Object, seeds);
        }

        [Fact]
        public void CreateCharacters()
        {
            // Given
            var characters = new List<ICharacter>() { character.Object, character.Object, character.Object };
            var characterParty = new List<ICharacter>() { character.Object, character.Object, character.Object, character.Object };
            characterCreation.Setup(cc => cc.Create()).Returns(character.Object);
            characterCreation.Setup(cc => cc.CreateMultiple(3, seeds)).Returns(characters);
            presenter.Setup(p => p.PrintParty(characterParty));

            // When
            gameState.StartState();

            // Then
            characterCreation.VerifyAll();
            presenter.VerifyAll();
        }
    }
}