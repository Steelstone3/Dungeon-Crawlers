using DungeonCrawlers.States;
using DungeonCrawlers.Contracts;
using Moq;
using Xunit;

namespace DungeonCrawlersTests
{
    public class NewGameStateShould
    {
        private Mock<IDisplayer> _displayer;
        private Mock<IGameController> _gameController;

        [Fact]
        public void ExecutesTheStartState()
        {
            //Given
            var message = "New game selected";
            var displayer = SetupDisplayerMock(message);
            var gameController = SetupGameController(displayer);

            var newGameState = new NewGameState(displayer.Object, gameController.Object);
            
            //When
            newGameState.StartState();

            //Then
            displayer.Verify(x => x.Write(message));
        }

        [Fact]
        public void ExecutesTheStopState()
        {
           //Given
            var message = "New game started";
            var displayer = SetupDisplayerMock(message);
            var gameController = SetupGameController(displayer);

            var newGameState = new NewGameState(displayer.Object, gameController.Object);
            
            //When
            newGameState.StartState();

            //Then
            displayer.Verify(x => x.Write(message));
            gameController.Verify(x => x.CurrentGameState.StartState());
        }

        private Mock<IDisplayer> SetupDisplayerMock(string message)
        {
            var displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Write(message));

            return displayer;
        }

        private Mock<IGameController> SetupGameController(Mock<IDisplayer> displayer)
        {
            var gameController = new Mock<IGameController>();
            gameController.Setup(x => x.CurrentGameState).Returns(new NewGameState(displayer.Object, gameController.Object));
            gameController.Setup(x => x.CurrentGameState.StartState());

            return gameController;
        }
    }
}