using System.Collections.Generic;
using DungeonCrawlers.Components;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Presenters;
using DungeonCrawlers.States;
using DungeonCrawlers.Systems;
using DungeonCrawlersTests.Entities;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.States
{
    public class DungeonStateShould
    {
        private readonly Mock<IGameStateRepository> gameStateRepository = new();
        private readonly Mock<IPresenter> presenter = new();
        private readonly Mock<IGameRepository> gameRepository = new();
        private readonly Mock<IDungeonCreationSystem> dungeonCreationSystem = new();
        private readonly Mock<ICombatSystem> combatSystem = new();
        private readonly Mock<ISeededRandomSystem> seededRandomSystem = new();
        private readonly IGameState gameState;

        public DungeonStateShould()
        {
            var monster = new Monster(null, null, null, null);
            var monsters = new List<IMonster>() { monster, monster };
            var room = new Room(monsters);
            var rooms = new List<IRoom>() { room, room };
            gameRepository.Setup(gr => gr.Dungeon).Returns(new Dungeon(rooms));
            var character = new Character(null, null, null, null, null);
            gameRepository.Setup(gr => gr.CharacterParty).Returns(new List<ICharacter>() { character, character });
            gameStateRepository.Setup(gsr => gsr.GameState).Returns(gameState);
            gameStateRepository.Setup(gsr => gsr.GameState.StartState());
            gameState = new DungeonState(gameStateRepository.Object, presenter.Object, gameRepository.Object, dungeonCreationSystem.Object, combatSystem.Object);
        }

        [Fact]
        public void SpawnDungeon()
        {
            // Given
            dungeonCreationSystem.Setup(srs => srs.CreateDungeon());

            // When
            gameState.StartState();

            // Then
            dungeonCreationSystem.VerifyAll();
        }

        [Fact]
        public void StartCombat()
        {
            // Given
            combatSystem.Setup(cs => cs.PlayerTurn(gameRepository.Object.CharacterParty, gameRepository.Object.Dungeon.Rooms[0].Monsters));
            combatSystem.Setup(cs => cs.MonsterTurn(gameRepository.Object.Dungeon.Rooms[0].Monsters, gameRepository.Object.CharacterParty));
            presenter.Setup(p => p.Print("Combat started"));

            // When
            gameState.StartState();

            // Then
            presenter.VerifyAll();
            combatSystem.VerifyAll();
        }
    }
}