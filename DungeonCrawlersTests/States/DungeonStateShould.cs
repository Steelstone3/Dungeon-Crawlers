using DungeonCrawlers.States;
using DungeonCrawlers.Contracts;
using Moq;
using Xunit;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Game.Locations;
using DungeonCrawlers.Contracts.Game.Locations;

namespace DungeonCrawlersTests
{
    public class DungeonStateShould
    {
        private Mock<ICharacterController> _characterController = new Mock<ICharacterController>();
        private Mock<IDungeonController> _dungeonController = new Mock<IDungeonController>();

        [Fact]
        public void ExecutesTheStartState()
        {
            //Given
            var message = "Dungeon entered";
            var displayer = SetupDisplayerMock(message);
            var dungeon = new Mock<IDungeon>();
            _dungeonController.Setup(x => x.CurrentDungeon).Returns(dungeon.Object);
            _dungeonController.Setup(x => x.CurrentDungeon.StartDungeon());

            var gameController = SetupGameControllerMock(displayer, 
            _characterController, 
            _dungeonController);

            var dungeonState = new DungeonState(displayer.Object,
            gameController.Object,
            _characterController.Object,
            _dungeonController.Object);

            //When
            dungeonState.StartState();

            //Then
            displayer.Verify(x => x.Write(message));
            _dungeonController.Verify(x => x.CurrentDungeon.StartDungeon());
        }

        [Fact]
        public void ExecutesTheStopState()
        {
            //Given
            var message = "Leaving dungeon";
            var displayer = SetupDisplayerMock(message);
            var dungeon = new Mock<IDungeon>();
            _dungeonController.Setup(x => x.CurrentDungeon).Returns(dungeon.Object);
            
            var gameController = SetupGameControllerMock(displayer,
            _characterController, 
            _dungeonController);

            var characterCreationState = new DungeonState(displayer.Object,
            gameController.Object,
            _characterController.Object,
            _dungeonController.Object);

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
    }
}