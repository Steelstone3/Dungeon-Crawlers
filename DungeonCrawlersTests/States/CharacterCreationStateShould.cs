using System.Collections.Generic;
using DungeonCrawlers.Entities.Intefaces;
using DungeonCrawlers.Presenters;
using DungeonCrawlers.Presenters.Interfaces;
using DungeonCrawlers.States;
using DungeonCrawlers.States.Interfaces;
using DungeonCrawlers.Systems.Interfaces;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.States
{
    public class CharacterCreationStateShould
    {
        private const int CHARACTER_QUANTITY = 3;
        private readonly Mock<ICharacter> character = new();
        private readonly Mock<IPresenter> presenter = new();
        private readonly Mock<ICharacterPresenter> characterPresenter = new();
        private readonly Mock<ISeededRandomSystem> seededRandomSystem = new();
        private readonly Mock<ICharacterCreationSystem> characterCreation = new();
        private readonly Mock<IGameRepository> gameRepository = new();
        private readonly Mock<IGameStateRepository> gameStateRepository = new();
        private readonly int[] seeds = new int[] { 1, 1, 1 };
        private readonly IGameState gameState;

        public CharacterCreationStateShould()
        {
            gameRepository.Setup(gp => gp.CharacterParty).Returns(new List<ICharacter>());
            gameStateRepository.Setup(gsr => gsr.GameState).Returns(gameState);
            gameStateRepository.Setup(gsr => gsr.GameState.StartState());
            gameState = new CharacterCreationState(gameStateRepository.Object, presenter.Object, gameRepository.Object, characterCreation.Object, seededRandomSystem.Object);
        }

        [Fact]
        public void CreateCharacters()
        {
            // Given
            var characters = new List<ICharacter>() { character.Object, character.Object, character.Object };
            var characterParty = new List<ICharacter>() { character.Object, character.Object, character.Object, character.Object };
            characterCreation.Setup(cc => cc.Create()).Returns(character.Object);
            seededRandomSystem.Setup(srs => srs.CreateSeeds(CHARACTER_QUANTITY)).Returns(seeds);
            characterCreation.Setup(cc => cc.CreateMultiple(CHARACTER_QUANTITY, seeds)).Returns(characters);
            characterPresenter.Setup(p => p.PrintParty(characterParty));
            presenter.Setup(p => p.CharacterPresenter).Returns(characterPresenter.Object);

            // When
            gameState.StartState();

            // Then
            characterCreation.VerifyAll();
            presenter.VerifyAll();
        }
    }
}