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
            var character = characterController.SelectPlayer(displayer);
            var opponent = characterController.SelectOpponent(displayer, enemyController.PartyMembers);
            characterController.AttackOpponent(displayer, character, opponent);
        }

        public void OpponentTurn(IDisplayer displayer,
        ICharacterController characterController,
        IEnemyController enemyController)
        {
            var opponent = enemyController.SelectOpponent(displayer, characterController.PartyMembers);
            enemyController.AttackOpponent(opponent);
        }
    }
}