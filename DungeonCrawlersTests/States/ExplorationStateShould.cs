using DungeonCrawlers.Contracts;
using DungeonCrawlers.States;
using Moq;
using Xunit;

namespace Name
{
    public class ExplorationStateShould
    {
        [Fact]
        public void ExecutesTheStartState()
        {
            //When
            var message = "Exploration started...";

            var displayer = SetupDisplayerMock(message);
            var characterController = SetupCharacterControllerMock();
            var locationController = SetupLocationControllerMock();
            var locationService = SetupLocationServiceMock(locationController);
            var gameController = SetupGameControllerMock(displayer, characterController, locationService, locationController);

            var explorationState = new ExplorationState(displayer.Object, gameController.Object, characterController.Object, locationService.Object, locationController.Object);

            //Given
            explorationState.StartState();

            //Then
            displayer.Verify(x => x.Write(message));
            locationService.Verify(x => x.GenerateLocations(locationController.Object));
        }

        [Fact]
        public void ExecutesTheStopState()
        {
            //When
            var message = "Entering dungeon";

            var displayer = SetupDisplayerMock(message);
            var characterController = SetupCharacterControllerMock();
            var locationController = SetupLocationControllerMock();
            var locationService = SetupLocationServiceMock(locationController);
            var gameController = SetupGameControllerMock(displayer, characterController, locationService, locationController);

            var explorationState = new ExplorationState(displayer.Object, gameController.Object, characterController.Object, locationService.Object, locationController.Object);

            //Given
            explorationState.StartState();

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

        private Mock<IGameController> SetupGameControllerMock(Mock<IDisplayer> displayer, Mock<ICharacterController> characterController, Mock<ILocationService> locationService, Mock<ILocationController> locationController)
        {
            var gameController = new Mock<IGameController>();
            gameController.Setup(x => x.CurrentGameState).Returns(new ExplorationState(displayer.Object, gameController.Object, characterController.Object, locationService.Object, locationController.Object));
            gameController.Setup(x => x.CurrentGameState.StartState());

            return gameController;
        }

        private Mock<ICharacterController> SetupCharacterControllerMock()
        {
            var characterController = new Mock<ICharacterController>();

            return characterController;
        }

        private Mock<ILocationService> SetupLocationServiceMock(Mock<ILocationController> locationController)
        {
            var locationService = new Mock<ILocationService>();
            locationService.Setup(x => x.GenerateLocations(locationController.Object));

            return locationService;
        }

        private Mock<ILocationController> SetupLocationControllerMock()
        {
            var locationController = new Mock<ILocationController>();

            return locationController;
        }
    }
}