using System.Collections.Generic;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Entities.Intefaces;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Entities
{
    public class RoomShould
    {
        private readonly Mock<IEnumerable<IMonster>> monsters = new();
        private readonly IRoom room;

        public RoomShould()
        {
            room = new Room(monsters.Object);
        }

        [Fact]
        public void ContainMonsters()
        {
            // Then
            Assert.NotNull(room.Monsters);
        }
    }
}