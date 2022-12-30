using System.Collections.Generic;
using DungeonCrawlers.Controllers;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Presenters;
using DungeonCrawlers.States;
using DungeonCrawlersTests.Systems;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Controllers
{
    public class GameControllerShould
    {
        private readonly Mock<ICharacter> character = new();
        private readonly Mock<IPresenter> presenter = new();
        private readonly Mock<IGameState> gameState = new();
        private readonly Mock<ICharacterCreationSystem> characterCreation = new();
        private readonly IGameController gameController;

        public GameControllerShould()
        {
            gameState.Setup(gs => gs.CharacterParty).Returns(new List<ICharacter>());
            gameController = new GameController(presenter.Object, gameState.Object, characterCreation.Object);
        }

        [Fact]
        public void StartGame()
        {
            // Given
            var seeds = new int[] { 1, 1, 1 };
            var characters = new List<ICharacter>() { character.Object, character.Object, character.Object };
            var characterParty = new List<ICharacter>() { character.Object, character.Object, character.Object, character.Object };
            characterCreation.Setup(cc => cc.Create()).Returns(character.Object);
            characterCreation.Setup(cc => cc.CreateMultiple(3, seeds)).Returns(characters);
            presenter.Setup(p => p.PrintParty(characterParty));

            // When
            gameController.StartGame(seeds);

            // Then
            characterCreation.VerifyAll();
            presenter.VerifyAll();
        }
    }
}