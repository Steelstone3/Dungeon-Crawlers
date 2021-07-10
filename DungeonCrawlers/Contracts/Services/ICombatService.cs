using DungeonCrawlers.Contracts.Controllers;

namespace DungeonCrawlers.Contracts.Services
{
    public interface ICombatService
    {
        void StartCombat(IDisplayer displayer, 
        ICombatController combatController, 
        ICharacterController characterController, 
        IEnemyController enemyController);
        void StopCombat(IDisplayer displayer);
    }
}