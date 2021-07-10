using DungeonCrawlers.States;
using DungeonCrawlers.Contracts;
using Moq;
using Xunit;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Locations;

namespace DungeonCrawlersTests
{
    public class DungeonStateShould
    {
        private Mock<ICharacterController> _characterController = new Mock<ICharacterController>();
        private Mock<ICombatController> _combatController = new Mock<ICombatController>();
        private Mock<IDungeonController> _dungeonController = new Mock<IDungeonController>();
        private Mock<IDungeon> _dungeon = new Mock<IDungeon>();

        [Fact]
        public void ExecutesTheStartState()
        {
            //Given
            var message = "Dungeon entered";
            var displayer = SetupDisplayerMock(message);
            _dungeonController.Setup(x => x.CurrentDungeon).Returns(_dungeon.Object);
            _dungeonController.Setup(x => x.CurrentDungeon.StartDungeon(_dungeon.Object.Rooms, _combatController.Object));

            var gameController = SetupGameControllerMock(displayer.Object);

            var dungeonState = new DungeonState(displayer.Object,
            gameController.Object,
            _characterController.Object,
            _combatController.Object,
            _dungeonController.Object,
            _dungeon.Object);

            //When
            dungeonState.StartState();

            //Then
            displayer.Verify(x => x.Write(message));
            //TODO AH change this out to the combat service that calls start
            _dungeonController.Verify(x => x.CurrentDungeon.StartDungeon(_dungeon.Object.Rooms, _combatController.Object));
        }

        [Fact]
        public void ExecutesTheStopState()
        {
            //Given
            var message = "Leaving dungeon";
            var displayer = SetupDisplayerMock(message);
            _dungeonController.Setup(x => x.CurrentDungeon).Returns(_dungeon.Object);

            var gameController = SetupGameControllerMock(displayer.Object);

            var characterCreationState = new DungeonState(displayer.Object,
            gameController.Object,
            _characterController.Object,
            _combatController.Object,
            _dungeonController.Object,
            _dungeon.Object);

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

        private Mock<IGameController> SetupGameControllerMock(IDisplayer displayer)
        {
            var gameController = new Mock<IGameController>();
            gameController.Setup(x => x.CurrentGameState).Returns(new DungeonState(displayer,
            gameController.Object,
            _characterController.Object,
            _combatController.Object,
            _dungeonController.Object,
            _dungeon.Object));

            gameController.Setup(x => x.CurrentGameState.StartState());

            return gameController;
        }
    }
}