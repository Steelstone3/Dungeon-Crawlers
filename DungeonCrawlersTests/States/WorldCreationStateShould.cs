using DungeonCrawlers.Display;
using DungeonCrawlers.Entities;
using DungeonCrawlers.States;
using DungeonCrawlers.States.GameControl;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.States
{
    public class WorldCreationStateShould
    {
        private readonly Mock<IDisplayer> displayer;
        private readonly Mock<IGameController> gameController;
        private readonly Mock<ICharacter> player;
        private readonly Mock<IWorld> world;
        private readonly Mock<IWorldCreationSystem> worldCreationSystem;

        public WorldCreationStateShould()
        {
            displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Write("World creation started..."));

            world = new Mock<IWorld>();
            
            worldCreationSystem = new Mock<IWorldCreationSystem>();
            worldCreationSystem.Setup(x => x.Create(displayer.Object)).Returns(world.Object);

            player = new Mock<ICharacter>();

            gameController = new Mock<IGameController>();
            gameController.Setup(x => x.CurrentGameState).Returns(new WorldCreationState(displayer.Object, gameController.Object, player.Object, worldCreationSystem.Object));
            gameController.Setup(x => x.CurrentGameState.StartState());
        }

        [Fact]
        public void ExecutesTheStartState()
        {
            //Given
            var worldCreationState = new WorldCreationState(displayer.Object, gameController.Object, player.Object, worldCreationSystem.Object);

            //When
            worldCreationState.StartState();

            //Then
            displayer.VerifyAll();
            gameController.VerifyAll();
            player.VerifyAll();
            worldCreationSystem.VerifyAll();
        }
    }
}