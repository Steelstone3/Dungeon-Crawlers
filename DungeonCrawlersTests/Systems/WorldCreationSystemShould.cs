using DungeonCrawlers.Entities;
using DungeonCrawlers.States;
using Xunit;

namespace DungeonCrawlersTests.Systems
{
    public class WorldCreationSystemShould
    {
        private readonly IWorld world;
        private readonly IWorldCreationSystem worldCreationSystem;

        public WorldCreationSystemShould()
        {
            world = new World
            {
                worldGrid = new char[5, 5] { { '#', '#', '#', '#', '#' }, { '#', '.', '.', '.', '#' }, { '#', '.', '.', '.', '#' }, { '#', '.', '.', '.', '#' }, { '#', '#', '#', '#', '#' } }
            };

            worldCreationSystem = new WorldCreationSystem();
        }

        [Fact]
        public void CreateWorld()
        {
            //Act
            var actualWorld = worldCreationSystem.Create();

            //Assert
            Assert.NotNull(actualWorld);
            Assert.NotNull(actualWorld.worldGrid);
            Assert.Equal(world.worldGrid, actualWorld.worldGrid);
        }
    }
}