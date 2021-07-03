using DungeonCrawlers.Contracts;
using DungeonCrawlers.States;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.States
{
    public class SettlementStateShould
    {
        [Fact]
        public void ExecutesTheStartState()
        {
            //Given
            var message = "Settlement entered";
            var displayer = SetupDisplayerMock(message);
            var gameController = SetupGameController(displayer);

            var newGameState = new SettlementState(displayer.Object, gameController.Object);

            //When
            newGameState.StartState();

            //Then
            //TODO AH Something with a settlement service naturally
            displayer.Verify(x => x.Write(message));
        }

        [Fact]
        public void ExecutesTheStopState()
        {
             //Given
            var message = "Leaving settlement";
            var displayer = SetupDisplayerMock(message);
            var gameController = SetupGameController(displayer);

            var newGameState = new SettlementState(displayer.Object, gameController.Object);

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
            gameController.Setup(x => x.CurrentGameState).Returns(new SettlementState(displayer.Object, gameController.Object));
            gameController.Setup(x => x.CurrentGameState.StartState());

            return gameController;
        }
    }
}