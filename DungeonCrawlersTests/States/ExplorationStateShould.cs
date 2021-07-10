using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Locations;
using DungeonCrawlers.Contracts.Services;
using DungeonCrawlers.States;
using Moq;
using Xunit;

namespace Name
{
    public class ExplorationStateShould
    {
        private Mock<ICharacterController> _characterController = new Mock<ICharacterController>();
        private Mock<ILocationService> _locationService = new Mock<ILocationService>();
        private Mock<IDungeonService> _dungeonService = new Mock<IDungeonService>();
        private Mock<IDungeonController> _dungeonController = new Mock<IDungeonController>();
        private Mock<IDungeonBuilder> _dungeonBuilder = new Mock<IDungeonBuilder>();

        [Fact]
        public void ExecutesTheStartState()
        {
            //When
            var message = "Exploration started...";
            var displayer = SetupDisplayerMock(message);

            var dungeon = new Mock<IDungeon>();
            _dungeonService.Setup(x => x.SelectDungeon(displayer.Object, _locationService.Object, _dungeonController.Object, _dungeonBuilder.Object)).Returns(dungeon.Object);

            var gameController = SetupGameControllerMock(displayer.Object);

            var explorationState = new ExplorationState(displayer.Object,
            gameController.Object,
            _characterController.Object,
            _locationService.Object,
            _dungeonService.Object,
            _dungeonController.Object,
            _dungeonBuilder.Object);

            //Given
            explorationState.StartState();

            //Then
            displayer.Verify(x => x.Write(message));
            _dungeonService.Verify(x => x.SelectDungeon(displayer.Object, _locationService.Object, _dungeonController.Object, _dungeonBuilder.Object));
        }

        [Fact]
        public void ExecutesTheStopState()
        {
            //When
            var message = "Entering dungeon";
            var displayer = SetupDisplayerMock(message);


            var gameController = SetupGameControllerMock(displayer.Object);

            var explorationState = new ExplorationState(displayer.Object,
            gameController.Object,
            _characterController.Object,
            _locationService.Object,
            _dungeonService.Object,
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

        private Mock<IGameController> SetupGameControllerMock(IDisplayer displayer)
        {
            var gameController = new Mock<IGameController>();

            gameController.Setup(x => x.CurrentGameState).Returns(new ExplorationState(displayer,
            gameController.Object,
            _characterController.Object,
            _locationService.Object,
            _dungeonService.Object,
            _dungeonController.Object,
            _dungeonBuilder.Object));

            gameController.Setup(x => x.CurrentGameState.StartState());

            return gameController;
        }
    }
}