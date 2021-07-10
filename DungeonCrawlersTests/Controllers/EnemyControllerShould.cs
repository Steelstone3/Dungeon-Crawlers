using DungeonCrawlers.Contracts;
using DungeonCrawlers.Controllers;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Controllers
{
    public class EnemyControllerShould
    {
        [Fact]
        public void GenerateEnemies()
        {
            var enemyController = new EnemyController();

            enemyController.GenerateEnemies();

            Assert.NotNull(enemyController.PartyMembers);
            Assert.NotEmpty(enemyController.PartyMembers);
        }

        [Fact]
        public void DisplayEnemyPartyMembers()
        {
            //Given
            var displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Write("Jeff the Goblin"));

            var characterController = new EnemyController();
            characterController.GenerateEnemies();

            //When
            characterController.DisplayParty(displayer.Object);

            //Then
            displayer.Verify(x => x.Write("Jeff the Goblin"));
        }

        [Fact(Skip = "Not implemented yet")]
        public void SelectOpponent()
        {
            //Cycle through each party member
            //Display that characters abilities
            //Allow the player to select an opponent
            //Allow the player to select the character ability
            //The character ability
        }

        [Fact(Skip = "Not implemented yet")]
        public void AttackOpponent()
        {
            //Cycle through each party member
            //Display that characters abilities
            //Allow the player to select an opponent
            //Allow the player to select the character ability
            //The character ability
        }
    }
}