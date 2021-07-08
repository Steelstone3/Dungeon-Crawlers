using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
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
            var locationBuilder = SetupLocationBuilderMock();
            var locationService = SetupLocationServiceMock(locationController, locationBuilder);
            var gameController = SetupGameControllerMock(displayer, 
            characterController, 
            locationService, 
            locationController, 
            locationBuilder);

            var explorationState = new ExplorationState(displayer.Object, 
            gameController.Object, 
            characterController.Object, 
            locationService.Object, 
            locationController.Object, 
            locationBuilder.Object);

            //Given
            explorationState.StartState();

            //Then
            displayer.Verify(x => x.Write(message));
            locationService.Verify(x => x.GenerateLocations(locationController.Object, locationBuilder.Object));
        }

        [Fact]
        public void ExecutesTheStopState()
        {
            //When
            var message = "Entering dungeon";

           var displayer = SetupDisplayerMock(message);
            var characterController = SetupCharacterControllerMock();
            var locationController = SetupLocationControllerMock();
            var locationBuilder = SetupLocationBuilderMock();
            var locationService = SetupLocationServiceMock(locationController, locationBuilder);
            var gameController = SetupGameControllerMock(displayer, 
            characterController, 
            locationService, 
            locationController, 
            locationBuilder);

            var explorationState = new ExplorationState(displayer.Object, 
            gameController.Object, 
            characterController.Object, 
            locationService.Object, 
            locationController.Object, 
            locationBuilder.Object);

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

        private Mock<IGameController> SetupGameControllerMock(Mock<IDisplayer> displayer,
        Mock<ICharacterController> characterController,
        Mock<ILocationService> locationService,
        Mock<ILocationController> locationController,
        Mock<ILocationBuilder> locationBuilder)
        {
            var gameController = new Mock<IGameController>();

            gameController.Setup(x => x.CurrentGameState).Returns(new ExplorationState(displayer.Object,
            gameController.Object,
            characterController.Object,
            locationService.Object,
            locationController.Object,
            locationBuilder.Object));

            gameController.Setup(x => x.CurrentGameState.StartState());

            return gameController;
        }

        private Mock<ICharacterController> SetupCharacterControllerMock()
        {
            var characterController = new Mock<ICharacterController>();

            return characterController;
        }

        private Mock<ILocationService> SetupLocationServiceMock(Mock<ILocationController> locationController, Mock<ILocationBuilder> locationBuilder)
        {
            var locationService = new Mock<ILocationService>();
            locationService.Setup(x => x.GenerateLocations(locationController.Object, locationBuilder.Object));

            return locationService;
        }

        private Mock<ILocationController> SetupLocationControllerMock()
        {
            var locationController = new Mock<ILocationController>();

            return locationController;
        }

        private Mock<ILocationBuilder> SetupLocationBuilderMock()
        {
            var locationBuilder = new Mock<ILocationBuilder>();

            return locationBuilder;
        }
    }
}