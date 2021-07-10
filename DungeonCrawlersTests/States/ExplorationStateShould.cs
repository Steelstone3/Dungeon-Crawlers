using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Services;
using DungeonCrawlers.States;
using Moq;
using Xunit;

namespace Name
{
    public class ExplorationStateShould
    {
        private Mock<ICharacterController> _characterController = new Mock<ICharacterController>();
        private Mock<IDungeonController> _dungeonController = new Mock<IDungeonController>();
        private Mock<IDungeonBuilder> _dungeonBuilder = new Mock<IDungeonBuilder>();

        [Fact]
        public void ExecutesTheStartState()
        {
            //When
            var message = "Exploration started...";

            var displayer = SetupDisplayerMock(message);

            var locationService = SetupLocationServiceMock(displayer.Object,
            _dungeonController.Object,
            _dungeonBuilder.Object);

            var gameController = SetupGameControllerMock(displayer.Object);

            var explorationState = new ExplorationState(displayer.Object,
            gameController.Object,
            _characterController.Object,
            locationService.Object,
            
            _dungeonController.Object,
           
            _dungeonBuilder.Object);

            //Given
            explorationState.StartState();

            //Then
            displayer.Verify(x => x.Write(message));
            locationService.Verify(x => x.GenerateDungeons(_dungeonController.Object, _dungeonBuilder.Object));
            locationService.Verify(x => x.DisplayLocations(displayer.Object, _dungeonController.Object));
            locationService.Verify(x => x.SelectLocation(displayer.Object, _dungeonController.Object.Dungeons));
        }

        [Fact]
        public void ExecutesTheStopState()
        {
            //When
            var message = "Entering dungeon";

            var displayer = SetupDisplayerMock(message);

            var locationService = SetupLocationServiceMock(displayer.Object, 
            _dungeonController.Object,
            _dungeonBuilder.Object);

            var gameController = SetupGameControllerMock(displayer.Object);

            var explorationState = new ExplorationState(displayer.Object,
            gameController.Object,
            _characterController.Object,
            locationService.Object,
            _dungeonController.Object,
            _dungeonBuilder.Object);

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

        private Mock<ILocationService> SetupLocationServiceMock(IDisplayer displayer, 
        IDungeonController dungeonController, 
        IDungeonBuilder dungeonBuilder)
        {
            var locationService = new Mock<ILocationService>();
            locationService.Setup(x => x.GenerateDungeons(dungeonController, dungeonBuilder));
            locationService.Setup(x => x.DisplayLocations(displayer, dungeonController));
            locationService.Setup(x => x.SelectLocation(displayer, dungeonController.Dungeons));

            return locationService;
        }

        private Mock<IGameController> SetupGameControllerMock(IDisplayer displayer)
        {
            var locationService = SetupLocationServiceMock(displayer, 
            _dungeonController.Object, 
            _dungeonBuilder.Object).Object;

            var gameController = new Mock<IGameController>();

            gameController.Setup(x => x.CurrentGameState).Returns(new ExplorationState(displayer,
            gameController.Object,
            _characterController.Object,
            locationService,
            _dungeonController.Object,
            _dungeonBuilder.Object));

            gameController.Setup(x => x.CurrentGameState.StartState());

            return gameController;
        }
    }
}