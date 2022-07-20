using DungeonCrawlers.Display;
using DungeonCrawlers.States;
using DungeonCrawlers.States.GameControl;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.States
{
    public class NewGameStateShould
    {
        private readonly Mock<IDisplayer> displayer;
        private readonly Mock<IGameController> gameController;

        public NewGameStateShould()
        {
            displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.WriteLine("New game selected..."));

            gameController = new Mock<IGameController>();
            gameController.Setup(x => x.CurrentGameState).Returns(new NewGameState(displayer.Object, gameController.Object));
            gameController.Setup(x => x.CurrentGameState.StartState());
        }

        [Fact]
        public void ExecutesTheStartState()
        {
            //Given
            var newGameState = new NewGameState(displayer.Object, gameController.Object);

            //When
            newGameState.StartState();

            //Then
            displayer.VerifyAll();
            gameController.VerifyAll();
        }
    }
}