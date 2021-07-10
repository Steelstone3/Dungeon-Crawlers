using System.Collections.Generic;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Locations;

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

        public void StartDungeon(IList<IDungeonRoom> rooms)
        {
            /*foreach (var room in rooms)
            {
                foreach (var encounter in room.Encounters)
                {
                    //StartCombat(encounter.);
                }
            }*/
        }
    }
}