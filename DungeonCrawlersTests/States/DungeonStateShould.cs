using DungeonCrawlers.Display;
using DungeonCrawlers.Entities;
using DungeonCrawlers.States;
using DungeonCrawlers.States.GameControl;
using Moq;
using Xunit;

namespace Name
{
    public class DungeonStateShould {
        private readonly Mock<IDisplayer> displayer;
        private readonly Mock<IGameController> gameController;
        private readonly Mock<ICharacter> player;
        private readonly Mock<IWorld> world;

        public DungeonStateShould()
        {
            displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.WriteLine("Dungeon entered..."));

            player = new Mock<ICharacter>();
            
            world = new Mock<IWorld>();

            gameController = new Mock<IGameController>();
            gameController.Setup(x => x.CurrentGameState).Returns(new DungeonState(displayer.Object, gameController.Object, player.Object, world.Object));
            gameController.Setup(x => x.CurrentGameState.StartState());
        }

        [Fact]
        public void ExecutesTheStartState()
        {
            //Given
            var explorationState = new DungeonState(displayer.Object, gameController.Object, player.Object, world.Object);

            //When
            explorationState.StartState();

            //Then
            displayer.VerifyAll();
            gameController.VerifyAll();
            player.VerifyAll();
        }
    }
}