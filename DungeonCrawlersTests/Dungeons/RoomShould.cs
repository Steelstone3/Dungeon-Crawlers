using System.Linq;
using DungeonCrawlers.Game.Dungeons;
using Xunit;

namespace DungeonCrawlersTests.Dungeons
{
    public class RoomShould
    {
        [Fact]
        public void ContainsAtLeastOneCombatEncounterPerRoom()
        {
            var room = new Room(1);

            Assert.NotNull(room.Encounters);
            Assert.NotEmpty(room.Encounters);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(-1)]
        public void ContainsAtNoMoreThanFiveEncountersPerRoom(int numberOfEncounters)
        {
            var room = new Room(numberOfEncounters);

            Assert.NotNull(room.Encounters);
            Assert.NotEmpty(room.Encounters);
            Assert.NotInRange(room.Encounters.ToList().Count, 6, int.MaxValue);
        }
    }
}

