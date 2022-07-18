using DungeonCrawlers.Display;
using DungeonCrawlers.Entities;
using DungeonCrawlers.States;
using DungeonCrawlers.States.GameControl;
using DungeonCrawlers.Systems;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.States
{
    public class ExplorationStateShould
    {
        private readonly Mock<IDisplayer> displayer;
        private readonly Mock<IGameController> gameController;
        private readonly Mock<ICharacter> player;
        private readonly Mock<IWorld> world;

        public ExplorationStateShould()
        {
            displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Write("Exploration started..."));

            player = new Mock<ICharacter>();
            
            world = new Mock<IWorld>();

            gameController = new Mock<IGameController>();
            gameController.Setup(x => x.CurrentGameState).Returns(new ExplorationState(displayer.Object, gameController.Object, player.Object, world.Object));
            gameController.Setup(x => x.CurrentGameState.StartState());
        }

        [Fact (Skip = "Needs implementing")]
        public void ExecutesTheStartState()
        {
            //Given
            var explorationState = new ExplorationState(displayer.Object, gameController.Object, player.Object, world.Object);

            //When
            explorationState.StartState();

            //Then
            displayer.VerifyAll();
            gameController.VerifyAll();
            player.VerifyAll();
        }
    }
}