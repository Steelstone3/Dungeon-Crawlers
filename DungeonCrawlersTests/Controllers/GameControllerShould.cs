using System.Collections.Generic;
using DungeonCrawlers.Controllers;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Presenters;
using DungeonCrawlers.States;
using DungeonCrawlers.Systems;
using DungeonCrawlersTests.Systems;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Controllers
{
    public class GameControllerShould
    {
        private readonly Mock<ICharacter> character = new();
        private readonly Mock<IMonster> monster = new();
        private readonly Mock<IPresenter> presenter = new();
        private readonly Mock<IGameRepository> gameState = new();
        private readonly Mock<ICharacterCreationSystem> characterCreation = new();
        private readonly Mock<IMonsterCreationSystem> monsterCreation = new();
        private readonly Mock<ICombatSystem> combat = new();
        private readonly IGameController gameController;

        public GameControllerShould()
        {
            gameState.Setup(gs => gs.CharacterParty).Returns(new List<ICharacter>());
            gameState.Setup(gs => gs.MonsterParty).Returns(new List<IMonster>());
            gameController = new GameController(presenter.Object, gameState.Object, characterCreation.Object, monsterCreation.Object, combat.Object);
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

        [Fact]
        public void SpawnMonsters()
        {
            // Given
            var monsters = new List<IMonster>() { monster.Object, monster.Object, monster.Object, monster.Object, monster.Object };
            monsterCreation.Setup(mc => mc.CreateMultiple(5, new int[] { 1, 1, 1, 1, 1 })).Returns(monsters);
            presenter.Setup(p => p.PrintParty(monsters));

            // When
            gameController.SpawnMonsters(5, new int[] { 1, 1, 1, 1, 1 });

            // Then
            monsterCreation.VerifyAll();
            presenter.VerifyAll();
        }

        [Fact]
        public void StartCombat()
        {
            // Given
            gameState.Object.CharacterParty.Add(character.Object);
            gameState.Object.MonsterParty.Add(monster.Object);
            presenter.Setup(p => p.Print("Combat started"));
            combat.Setup(cs => cs.PlayerTurn(gameState.Object.CharacterParty, gameState.Object.MonsterParty));
            combat.Setup(cs => cs.MonsterTurn(gameState.Object.MonsterParty,gameState.Object.CharacterParty));

            // When
            gameController.StartCombat();

            // Then
            presenter.VerifyAll();
            combat.VerifyAll();
        }
    }
}