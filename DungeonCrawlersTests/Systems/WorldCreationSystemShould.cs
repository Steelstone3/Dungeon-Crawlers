using DungeonCrawlers.Display;
using DungeonCrawlers.States;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Systems
{
public class WorldCreationSystemShould{

        private readonly Mock<IDisplayer> displayer;
        private readonly IWorldCreationSystem worldCreationSystem;

        public WorldCreationSystemShould(){
            worldCreationSystem = new WorldCreationSystem();

            displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Write("Creating world..."));
        }
        
        [Fact]
        public void CreateWorld() {
            //Act
            var world = worldCreationSystem.Create(displayer.Object);

            //Assert
            displayer.VerifyAll();
            Assert.NotNull(world);
        }
}
}