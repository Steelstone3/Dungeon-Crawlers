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

            Assert.NotNull(enemyController.EnemyParty);
            Assert.NotEmpty(enemyController.EnemyParty);
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
            characterController.DisplayEnemyParty(displayer.Object);

            //Then
            displayer.Verify(x => x.Write("Jeff the Goblin"));
        }
    }
}