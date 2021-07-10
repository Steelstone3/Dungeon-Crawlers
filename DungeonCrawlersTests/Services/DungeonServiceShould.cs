using DungeonCrawlers.Builders;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Services;
using DungeonCrawlers.Game.Locations;
using DungeonCrawlers.Services;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Services
{
    public class DungeonServiceShould
    {
        private IDungeonService _dungeonService = new DungeonService();
        private Mock<IDisplayer> _displayer = new Mock<IDisplayer>();
        private Mock<ICombatService> _combatService = new Mock<ICombatService>();
        private Mock<ICombatController> _combatController = new Mock<ICombatController>();
        private Mock<ICharacterController> _characterController = new Mock<ICharacterController>();
        private Mock<IDungeonController> _dungeonController = new Mock<IDungeonController>();
        private Mock<IDungeonBuilder> _dungeonBuilder = new Mock<IDungeonBuilder>();
        private Mock<IEnemyController> _enemyController = new Mock<IEnemyController>();

        [Fact]
        public void SelectDungeon()
        {
            //Given
            var locationService = SetupLocationServiceMock();

            //When
            _dungeonService.SelectDungeon(_displayer.Object,
            locationService.Object,
            _dungeonController.Object,
            _dungeonBuilder.Object);

            //Then
            locationService.InSequence(new MockSequence());
            locationService.Verify(x => x.GenerateDungeons(_dungeonController.Object, _dungeonBuilder.Object));
            locationService.Verify(x => x.DisplayLocations(_displayer.Object, _dungeonController.Object));
            locationService.Verify(x => x.SelectLocation(_displayer.Object, _dungeonController.Object.Dungeons));
        }

        [Fact]
        public void StartDungeon()
        {
            //Have had to use concrete implementations for this test not to throw a null exception
            //Given
            var encounterBuilder = new EncounterBuilder();
            var dungeon = new Dungeon(encounterBuilder, _enemyController.Object);

            _dungeonController.Setup(x => x.CurrentDungeon).Returns(dungeon);

            _combatService.Setup(x => x.StartCombat(_displayer.Object,
            _combatController.Object,
            _characterController.Object,
            _enemyController.Object));

            //When
            _dungeonService.StartDungeon(_displayer.Object,
            _combatService.Object,
            _combatController.Object,
            _characterController.Object,
            _dungeonController.Object.CurrentDungeon);

            //Then
            _combatService.Verify(x => x.StartCombat(_displayer.Object,
            _combatController.Object,
            _characterController.Object,
            _enemyController.Object));
        }

        private Mock<ILocationService> SetupLocationServiceMock()
        {
            var locationService = new Mock<ILocationService>();
            locationService.Setup(x => x.GenerateDungeons(_dungeonController.Object, _dungeonBuilder.Object));
            locationService.Setup(x => x.DisplayLocations(_displayer.Object, _dungeonController.Object));
            locationService.Setup(x => x.SelectLocation(_displayer.Object, _dungeonController.Object.Dungeons));

            return locationService;
        }
    }
}