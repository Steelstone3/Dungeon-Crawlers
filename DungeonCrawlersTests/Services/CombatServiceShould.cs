using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Services;
using DungeonCrawlers.Services;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Services
{
    public class CombatServiceShould
    {
        private ICombatService _combatService = new CombatService();
        private Mock<IDisplayer> _displayer = new Mock<IDisplayer>();
        private Mock<ICombatController> _combatController = new Mock<ICombatController>();
        private Mock<ICharacterController> _characterController = new Mock<ICharacterController>();
        private Mock<IEnemyController> _enemyController = new Mock<IEnemyController>();

        [Fact]
        public void StartCombat()
        {
            //Given
            _combatController.Setup(x => x.DisplayCombatants(_displayer.Object,
            _characterController.Object, 
            _enemyController.Object));

            _combatController.Setup(x => x.PlayerTurn(_displayer.Object,
            _characterController.Object, 
            _enemyController.Object));

            _combatController.Setup(x => x.OpponentTurn(_displayer.Object,
            _characterController.Object, 
            _enemyController.Object));

            //When
            _combatService.StartCombat(_displayer.Object,
            _combatController.Object,
            _characterController.Object,
            _enemyController.Object);

            //Then
            _combatController.InSequence(new MockSequence());

            _combatController.Verify(x => x.DisplayCombatants(_displayer.Object,
            _characterController.Object, 
            _enemyController.Object));

            _combatController.Verify(x => x.PlayerTurn(_displayer.Object,
            _characterController.Object, 
            _enemyController.Object));

            _combatController.Verify(x => x.OpponentTurn(_displayer.Object,
            _characterController.Object, 
            _enemyController.Object));
        }

        [Fact(Skip = "Skip")]
        public void StopCombat()
        {

        }
    }
}