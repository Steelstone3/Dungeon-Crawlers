using DungeonCrawlers.Display;
using DungeonCrawlers.Entities;
using DungeonCrawlers.States;
using DungeonCrawlers.States.GameControl;
using Moq;
using Xunit;

namespace Name
{
    public class CombatStateShould {
        private readonly Mock<IDisplayer> displayer;
        private readonly Mock<IGameController> gameController;
        private readonly Mock<ICharacter> player;
        private readonly Mock<IWorld> world;

        public CombatStateShould()
        {
            displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.WriteLine("Combat started..."));

            player = new Mock<ICharacter>();
            
            world = new Mock<IWorld>();

            gameController = new Mock<IGameController>();
            gameController.Setup(x => x.CurrentGameState).Returns(new CombatState(displayer.Object, gameController.Object, player.Object, world.Object));
            gameController.Setup(x => x.CurrentGameState.StartState());
        }

        [Fact]
        public void ExecutesTheStartState()
        {
            //Given
            var explorationState = new CombatState(displayer.Object, gameController.Object, player.Object, world.Object);

            //When
            explorationState.StartState();

            //Then
            displayer.VerifyAll();
            //gameController.VerifyAll();
            player.VerifyAll();
        }
    }
}