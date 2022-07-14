using DungeonCrawlers.Display;
using DungeonCrawlers.States;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.States
{
    public class NewGameShould
    {
        private readonly Mock<IDisplayer> displayer;
        private readonly Mock<IGameController> gameController;

        public NewGameShould()
        {
            string newGameMessage = "New game selected...";
            
            displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Write(newGameMessage));

            gameController = new Mock<IGameController>();
            gameController.Setup(x => x.CurrentGameState).Returns(new NewGame(displayer.Object, gameController.Object));
            gameController.Setup(x => x.CurrentGameState.StartState());
        }

        [Fact]
        public void ExecutesTheStartState()
        {
            //Given
            var newGameState = new NewGame(displayer.Object, gameController.Object);

            //When
            newGameState.StartState();

            //Then
            displayer.VerifyAll();
        }
    }
}