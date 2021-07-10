using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Controllers;

namespace DungeonCrawlers.Controllers
{
    public class CombatController : ICombatController
    {
        public void DisplayCombatants(IDisplayer displayer, 
        ICharacterController characterController, 
        IEnemyController enemyController)
        {
            displayer.Write("Allies");
            characterController.DisplayParty(displayer);

            displayer.Write("Foes");
            enemyController.DisplayParty(displayer);
        }

        public void PlayerTurn(IDisplayer displayer, 
        ICharacterController characterController, 
        IEnemyController enemyController)
        {
            var opponent = characterController.SelectOpponent(enemyController.PartyMembers);
            characterController.AttackOpponent(opponent);
        }

        public void OpponentTurn(IDisplayer displayer, 
        ICharacterController characterController, 
        IEnemyController enemyController)
        {
            var opponent = enemyController.SelectOpponent(characterController.PartyMembers);
            enemyController.AttackOpponent(opponent);
        }
    }
}