using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Services;

namespace DungeonCrawlers.Services
{
    public class CombatService : ICombatService
    {
        public void StartCombat(IDisplayer displayer, 
        ICombatController combatController, 
        ICharacterController characterController,
        IEnemyController enemyController)
        {
            displayer.Write("Combat Started");
            combatController.DisplayCombatants(displayer,characterController,enemyController);
            combatController.PlayerTurn(displayer,characterController,enemyController);
            combatController.OpponentTurn(displayer,characterController,enemyController);
        }

        public void StopCombat(IDisplayer displayer)
        {
            displayer.Write("Combat Ended");
        }
    }
}