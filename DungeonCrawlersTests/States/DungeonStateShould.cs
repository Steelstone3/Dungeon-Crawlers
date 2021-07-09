using DungeonCrawlers.States;
using DungeonCrawlers.Contracts;
using Moq;
using Xunit;
using DungeonCrawlers.Contracts.Controllers;

namespace DungeonCrawlersTests
{
    public class DungeonStateShould
    {
        [Fact]
        public void ExecutesTheStartState()
        {
            //Given
            var message = "Dungeon entered";
            var displayer = SetupDisplayerMock(message);
            var characterController = SetupCharacterControllerMock();

            var dungeonController = SetupDungeonControllerMock();

            var gameController = SetupGameControllerMock(displayer, characterController, dungeonController);

            var dungeonState = new DungeonState(displayer.Object,
            gameController.Object,
            characterController.Object,
            dungeonController.Object);

            //When
            dungeonState.StartState();

            //Then
            displayer.Verify(x => x.Write(message));
        }

        [Fact]
        public void ExecutesTheStopState()
        {
            //Given
            var message = "Leaving dungeon";
            var displayer = SetupDisplayerMock(message);
            var characterController = SetupCharacterControllerMock();
            var dungeonController = SetupDungeonControllerMock();
            var gameController = SetupGameControllerMock(displayer, characterController, dungeonController);

            var characterCreationState = new DungeonState(displayer.Object,
            gameController.Object,
            characterController.Object,
            dungeonController.Object);

            //When
            characterCreationState.StartState();

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

        private Mock<IGameController> SetupGameControllerMock(Mock<IDisplayer> displayer, Mock<ICharacterController> characterController, Mock<IDungeonController> dungeonController)
        {
            var gameController = new Mock<IGameController>();
            gameController.Setup(x => x.CurrentGameState).Returns(new DungeonState(displayer.Object, gameController.Object, characterController.Object, dungeonController.Object));
            gameController.Setup(x => x.CurrentGameState.StartState());

            return gameController;
        }

        private Mock<ICharacterController> SetupCharacterControllerMock()
        {
            var characterController = new Mock<ICharacterController>();

            return characterController;
        }

        private Mock<IDungeonController> SetupDungeonControllerMock()
        {
            var dungeonController = new Mock<IDungeonController>();

            return dungeonController;
        }
    }
}