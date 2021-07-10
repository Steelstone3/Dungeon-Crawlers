using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Controllers;

namespace DungeonCrawlers.Controllers
{
    public class CombatController : ICombatController
    {
        public void DisplayCombatants(IDisplayer displayer, ICharacterController characterController, IEnemyController enemyController)
        {
            throw new System.NotImplementedException();
        }

        public void OpponentTurn(IDisplayer displayer, ICharacterController characterController, IEnemyController enemyController)
        {
            throw new System.NotImplementedException();
        }

        public void PlayerTurn(IDisplayer displayer, ICharacterController characterController, IEnemyController enemyController)
        {
            throw new System.NotImplementedException();
        }
    }
}