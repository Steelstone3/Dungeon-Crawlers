using System.Collections.Generic;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Entities.Intefaces;
using DungeonCrawlers.Systems;
using DungeonCrawlers.Systems.Interfaces;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Systems
{
    public class DungeonCreationSystemShould
    {
        private readonly Mock<IRoomCreationSystem> roomCreationSystem = new();
        private readonly IDungeonCreationSystem dungeonCreationSystem;

        public DungeonCreationSystemShould()
        {
            dungeonCreationSystem = new DungeonCreationSystem(roomCreationSystem.Object);
        }

        [Fact]
        public void CreateDungeon()
        {
            // Given
            var monster = new Monster(null, null, null, null);
            var monsters = new List<IMonster> { monster, monster };
            var room = new Room(monsters);
            var rooms = new List<IRoom>() { room, room };
            roomCreationSystem.Setup(rcs => rcs.CreateRooms()).Returns(rooms);

            // When
            var dungeon = dungeonCreationSystem.CreateDungeon();

            // Then
            Assert.NotNull(dungeon);
            Assert.NotEmpty(dungeon.Rooms);
            roomCreationSystem.VerifyAll();
        }
    }
}