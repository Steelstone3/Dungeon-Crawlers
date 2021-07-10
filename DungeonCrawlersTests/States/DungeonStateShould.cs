using DungeonCrawlers.States;
using DungeonCrawlers.Contracts;
using Moq;
using Xunit;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Services;
using DungeonCrawlers.Contracts.Game.Locations;

namespace DungeonCrawlersTests
{
    public class DungeonStateShould
    {
        private Mock<ICharacterController> _characterController = new Mock<ICharacterController>();
        private Mock<ICombatService> _combatService = new Mock<ICombatService>();
        private Mock<ICombatController> _combatController = new Mock<ICombatController>();
        private Mock<IDungeonService> _dungeonService = new Mock<IDungeonService>();
        private Mock<IDungeonController> _dungeonController = new Mock<IDungeonController>();
        private Mock<IDungeon> _dungeon = new Mock<IDungeon>();

        [Fact]
        public void ExecutesTheStartState()
        {
            //Given
            var message = "Dungeon entered";
            var displayer = SetupDisplayerMock(message);
            displayer.Setup(x => x.Write(message));

            _dungeonController.Setup(x => x.CurrentDungeon).Returns(_dungeon.Object);
            
            _dungeonService.Setup(x => x.StartDungeon(displayer.Object, 
            _combatService.Object, 
            _combatController.Object,
            _characterController.Object, 
            _dungeonController.Object.CurrentDungeon));

            var gameController = SetupGameControllerMock(displayer.Object);

            var dungeonState = new DungeonState(displayer.Object,
            gameController.Object,
            _characterController.Object,
            _combatService.Object,
            _combatController.Object,
            _dungeonService.Object,
            _dungeonController.Object);

            //When
            dungeonState.StartState();

            //Then
            displayer.Verify(x => x.Write(message));
            _dungeonService.Verify(x => x.StartDungeon(displayer.Object, 
            _combatService.Object, 
            _combatController.Object,
            _characterController.Object, 
            _dungeonController.Object.CurrentDungeon));
        }

        [Fact]
        public void ExecutesTheStopState()
        {
            //Given
            var message = "Leaving dungeon";
            var displayer = SetupDisplayerMock(message);

            var gameController = SetupGameControllerMock(displayer.Object);

            var characterCreationState = new DungeonState(displayer.Object,
            gameController.Object,
            _characterController.Object,
            _combatService.Object,
            _combatController.Object,
            _dungeonService.Object,
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

        private Mock<IGameController> SetupGameControllerMock(IDisplayer displayer)
        {
            var gameController = new Mock<IGameController>();
            gameController.Setup(x => x.CurrentGameState).Returns(new DungeonState(displayer,
            gameController.Object,
            _characterController.Object,
            _combatService.Object,
            _combatController.Object,
            _dungeonService.Object,
            _dungeonController.Object));

            gameController.Setup(x => x.CurrentGameState.StartState());

            return gameController;
        }
    }
}