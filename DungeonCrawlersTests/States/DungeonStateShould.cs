using System.Collections.Generic;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Presenters;
using DungeonCrawlers.States;
using DungeonCrawlers.Systems;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.States
{
    public class DungeonStateShould
    {
        Mock<IGameStateRepository> gameStateRepository = new();
        Mock<IPresenter> presenter = new();
        Mock<IGameRepository> gameRepository = new();
        Mock<IMonsterCreationSystem> monsterCreationSystem = new();
        Mock<ICombatSystem> combatSystem = new();
        Mock<ISeededRandomSystem> seededRandomSystem = new();
        IGameState gameState;

        public DungeonStateShould()
        {
            gameRepository.Setup(gr => gr.CharacterParty).Returns(new List<ICharacter>());
            gameRepository.Setup(gr => gr.MonsterParty).Returns(new List<IMonster>());
            gameStateRepository.Setup(gsr => gsr.GameState).Returns(gameState);
            gameStateRepository.Setup(gsr => gsr.GameState.StartState());
            gameState = new DungeonState(gameStateRepository.Object, presenter.Object, gameRepository.Object, monsterCreationSystem.Object, combatSystem.Object, seededRandomSystem.Object);
        }

        [Fact]
        public void SpawnMonsters()
        {
            // Given
            var quantity = 5;
            var seeds = new int[] { 1, 1, 1, 1, 1 };
            var monster = new Monster(null, null, null, null);
            var monsters = new IMonster[] { monster, monster, monster, monster, monster };
            seededRandomSystem.Setup(srs => srs.GetRandom(1, 10)).Returns((ulong)quantity);
            seededRandomSystem.Setup(srs => srs.CreateSeeds(quantity)).Returns(seeds);
            monsterCreationSystem.Setup(srs => srs.CreateMultiple(quantity, seeds)).Returns(monsters);
            presenter.Setup(p => p.PrintParty(monsters));

            // When
            gameState.StartState();

            // Then
            seededRandomSystem.VerifyAll();
            monsterCreationSystem.VerifyAll();
            presenter.VerifyAll();
        }

        [Fact]
        public void StartCombat()
        {
            // Given
            var character = new Character(null, null, null, null, null);
            var monster = new Monster(null, null, null, null);
            gameRepository.Setup(gr => gr.CharacterParty).Returns(new List<ICharacter>() { character });
            gameRepository.Setup(gr => gr.MonsterParty).Returns(new List<IMonster>() { monster });
            presenter.Setup(p => p.Print("Combat started"));
            combatSystem.Setup(cs => cs.PlayerTurn(gameRepository.Object.CharacterParty, gameRepository.Object.MonsterParty)).Returns(false);
            combatSystem.Setup(cs => cs.MonsterTurn(gameRepository.Object.MonsterParty, gameRepository.Object.CharacterParty)).Returns(false);

            // When
            gameState.StartState();

            // Then
            presenter.VerifyAll();
            combatSystem.VerifyAll();
        }
    }
}