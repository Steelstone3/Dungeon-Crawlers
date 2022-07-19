using DungeonCrawlers.Display;
using DungeonCrawlers.Entities;
using DungeonCrawlers.States;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Systems
{
    public class WorldCreationSystemShould
    {
        private readonly Mock<IWorld> world;
        private readonly Mock<IDisplayer> displayer;
        private readonly IWorldCreationSystem worldCreationSystem;

        public WorldCreationSystemShould()
        {
            world = new Mock<IWorld>();
            world.Setup(x => x.worldGrid).Returns(new char[,] {{'#', '#'}, {'#', '#'}});

            worldCreationSystem = new WorldCreationSystem();

            displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Write("Creating world..."));
            displayer.Setup(x => x.DrawMap(world.Object.worldGrid));
        }

        [Fact]
        public void CreateWorld()
        {
            //Act
            var world = worldCreationSystem.Create(displayer.Object);

            //Assert
            displayer.VerifyAll();
            Assert.NotNull(world);
            Assert.NotNull(world.worldGrid);
        }
    }
}