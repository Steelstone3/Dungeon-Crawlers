using System.Collections.Generic;
using DungeonCrawlers.Entities;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Entities
{
    public class DungeonShould
    {
        private readonly Mock<IEnumerable<IRoom>> rooms = new();
        private readonly IDungeon dungeon;

        public DungeonShould()
        {
            dungeon = new Dungeon(rooms.Object);
        }

        [Fact]
        public void ContainsRooms()
        {
            // Then
            Assert.NotNull(dungeon.Rooms);
        }
    }
}