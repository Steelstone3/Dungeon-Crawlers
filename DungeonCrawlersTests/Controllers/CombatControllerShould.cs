using Xunit;

namespace DungeonCrawlersTests.Controllers
{
    public class CombatControllerShould
    {
        [Fact(Skip="Skip")]
        public void DisplayCombatants()
        {
            //TODO AH Will display the both friendly and enemy forces
        }

        [Fact(Skip ="Skip")]
        public void PlayerTurn()
        {
            //TODO AH Player will select each character in turn and select a combat ability to perform on a target
            //TODO AH If there is no enemies then combat ends
            //TODO AH If all player characters die the game ends
        }

        [Fact(Skip ="Skip")]
        public void OpponentTurn()
        {
            //TODO AH Opponent will select each character in turn and select a combat ability to perform on a target
            //TODO AH If there is no enemies then combat ends
            //TODO AH If all player characters die the game ends
        }
    }
}