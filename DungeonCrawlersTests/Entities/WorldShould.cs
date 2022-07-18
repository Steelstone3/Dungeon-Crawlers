using DungeonCrawlers.Entities;
using Xunit;

namespace DungeonCrawlersTests.Entities
{
    public class WorldShould
    {
        [Fact]
        public void ContainAWorldState()
        {
            var world = new World();

            world.worldGrid = new char[,] { { '#' }, { '#' } };

            Assert.NotNull(world);
            Assert.NotNull(world.worldGrid);
        }
    }
}