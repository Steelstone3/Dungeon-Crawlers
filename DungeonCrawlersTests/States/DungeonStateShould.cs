using DungeonCrawlers.States;
using DungeonCrawlers.Contracts;
using Moq;
using Xunit;
using DungeonCrawlers.Contracts.Services;
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
            var locationController = SetupLocationControllerMock();
            var dungeonController = SetupDungeonControllerMock();
            var dungeonCreationService = SetupDungeonCreationServiceMock(dungeonController);
            var gameController = SetupGameControllerMock(displayer, characterController, locationController, dungeonCreationService, dungeonController);

            var dungeonState = new DungeonState(displayer.Object,
            gameController.Object, 
            characterController.Object, 
            locationController.Object, 
            dungeonCreationService.Object, 
            dungeonController.Object);

            //When
            dungeonState.StartState();

            //Then
            displayer.Verify(x => x.Write(message));
            dungeonCreationService.Verify(x => x.GenerateDungeon(dungeonController.Object));
        }

        [Fact]
        public void ExecutesTheStopState()
        {
            //Given
            var message = "Leaving dungeon";
            var displayer = SetupDisplayerMock(message);
            var characterController = SetupCharacterControllerMock();
            var locationController = SetupLocationControllerMock();
            var dungeonController = SetupDungeonControllerMock();
            var dungeonCreationService = SetupDungeonCreationServiceMock(dungeonController);
            var gameController = SetupGameControllerMock(displayer, characterController,locationController,dungeonCreationService,dungeonController);

            var characterCreationState = new DungeonState(displayer.Object, 
            gameController.Object, 
            characterController.Object, 
            locationController.Object, 
            dungeonCreationService.Object, 
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

        private Mock<IGameController> SetupGameControllerMock(Mock<IDisplayer> displayer, Mock<ICharacterController> characterController, Mock<ILocationController> locationController, Mock<IDungeonCreationService> dungeonCreationService, Mock<IDungeonController> dungeonController)
        {
            var gameController = new Mock<IGameController>();
            gameController.Setup(x => x.CurrentGameState).Returns(new DungeonState(displayer.Object, gameController.Object, characterController.Object, locationController.Object, dungeonCreationService.Object, dungeonController.Object));
            gameController.Setup(x => x.CurrentGameState.StartState());

            return gameController;
        }

        private Mock<ICharacterController> SetupCharacterControllerMock()
        {
            var characterController = new Mock<ICharacterController>();

            return characterController;
        }

        private Mock<ILocationController> SetupLocationControllerMock()
        {
            var locationController = new Mock<ILocationController>();

            return locationController;
        }

        private Mock<IDungeonCreationService> SetupDungeonCreationServiceMock(Mock<IDungeonController> dungeonController)
        {
            var dungeonCreationService = new Mock<IDungeonCreationService>();
            dungeonCreationService.Setup(x => x.GenerateDungeon(dungeonController.Object));

            return dungeonCreationService;
        }

        private Mock<IDungeonController> SetupDungeonControllerMock()
        {
            var dungeonController = new Mock<IDungeonController>();

            return dungeonController;
        }
    }
}