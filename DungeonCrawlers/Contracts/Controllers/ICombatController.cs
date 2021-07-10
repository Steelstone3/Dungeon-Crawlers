using System.Collections.Generic;
using DungeonCrawlers.Contracts.Game.Locations;

namespace DungeonCrawlers.Contracts.Controllers
{
    public interface ICombatController
    {
        void DisplayCombatants(IDisplayer displayer, ICharacterController characterController, IEnemyController enemyController);
        void PlayerTurn(IDisplayer displayer, ICharacterController characterController, IEnemyController enemyController);
        void OpponentTurn(IDisplayer displayer, ICharacterController characterController, IEnemyController enemyController);
    }
}