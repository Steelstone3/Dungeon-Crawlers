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

        public WorldCreationStateShould()
        {
            displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Write("Exploration started..."));

            gameController = new Mock<IGameController>();
            gameController.Setup(x => x.CurrentGameState).Returns(new NewGameState(displayer.Object, gameController.Object));
            gameController.Setup(x => x.CurrentGameState.StartState());
            
            player = new Mock<ICharacter>();

            world = new Mock<IWorld>();
        }

        [Fact (Skip = "Needs implementing")]
        public void ExecutesTheStartState()
        {
            //Given
            var newGameState = new ExplorationState(displayer.Object, gameController.Object, player.Object, world.Object);

            //When
            newGameState.StartState();

            //Then
            displayer.VerifyAll();
            gameController.VerifyAll();
            player.VerifyAll();
        }
    }
}