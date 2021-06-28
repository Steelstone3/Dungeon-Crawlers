using System.Linq;
using Xunit;

namespace DungeonCrawlersTests
{
    public class DungeonShould
    {
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        public void ContainRooms(int numberOfRooms)
        {
            var dungeon = new Dungeon(numberOfRooms);

            Assert.NotNull(dungeon.Rooms);
            Assert.NotEmpty(dungeon.Rooms);
            Assert.Equal(numberOfRooms, dungeon.Rooms.ToList().Count);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(-1)]
        public void ContainNoMoreThanTenRooms(int numberOfRooms)
        {
            var dungeon = new Dungeon(numberOfRooms);

            Assert.NotNull(dungeon.Rooms);
            Assert.NotEmpty(dungeon.Rooms);
            Assert.NotInRange(dungeon.Rooms.ToList().Count, 11, int.MaxValue);
        }

        [Fact(Skip = "Needs implementing")]
        public void EndOnTheLastRoomsCompletion()
        {
            //var dungeon = new Dungeon();
        }
    }
}