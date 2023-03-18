using System.Collections.Generic;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Entities.Intefaces;
using DungeonCrawlers.Systems;
using DungeonCrawlers.Systems.Interfaces;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Systems
{
    public class RoomCreationSystemShould
    {
        private readonly Mock<ISeededRandomSystem> seededRandomSystem = new();
        private readonly Mock<IMonsterCreationSystem> monsterCreationSystem = new();
        private readonly IRoomCreationSystem roomCreationSystem;

        public RoomCreationSystemShould()
        {
            roomCreationSystem = new RoomCreationSystem(seededRandomSystem.Object, monsterCreationSystem.Object);
        }

        [Fact]
        public void CreateRoom()
        {
            // Given
            const int QUANTITY = 2;
            var seeds = new int[] { 1, 1 };
            var monster = new Monster(null, null, null, null);
            var monsters = new List<IMonster>() {monster, monster};
            seededRandomSystem.Setup(srs => srs.GetRandom(1, 10)).Returns(QUANTITY);
            seededRandomSystem.Setup(srs => srs.CreateSeeds(QUANTITY)).Returns(seeds);
            monsterCreationSystem.Setup(mcs => mcs.CreateMultiple(QUANTITY, seeds)).Returns(monsters);

            // When
            var rooms = roomCreationSystem.CreateRooms();

            // Then
            seededRandomSystem.VerifyAll();
            monsterCreationSystem.VerifyAll();
            Assert.NotEmpty(rooms);
            Assert.NotEmpty(rooms[0].Monsters);
            Assert.NotEmpty(rooms[1].Monsters);
        }
    }
}