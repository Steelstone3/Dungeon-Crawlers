using DungeonCrawlers.Components;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Presenters;
using DungeonCrawlers.Systems;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Systems
{
    public class CombatSystemShould
    {
        private readonly Mock<IPresenter> presenter = new();
        private readonly ICombatSystem combatSystem;

        public CombatSystemShould()
        {
            combatSystem = new CombatSystem(presenter.Object);
        }

        [Theory]
        [InlineData(25, 100, 75)]
        [InlineData(50, 100, 50)]
        [InlineData(75, 100, 25)]
        [InlineData(100, 100, 0)]
        [InlineData(101, 100, 0)]
        public void ExecutePlayerTurn(byte maximumDamage, byte currentHealth, byte remainingHealth)
        {
            // Given
            IMonster monster = new Monster(null, null, new Health(currentHealth, 100, 0));
            ICharacter character = new Character(null, null, new Health(100, 100, 25), new Armour(100, 100, 5), new Weapon(null, null, maximumDamage, maximumDamage));
            ICharacter[] characters = new ICharacter[] { character };
            IMonster[] monsters = new IMonster[] { monster };
            presenter.Setup(p => p.SelectCharacter(characters)).Returns(character);
            presenter.Setup(p => p.SelectMonster(monsters)).Returns(monster);

            // When
            combatSystem.PlayerTurn(characters, monsters);

            // Then
            presenter.VerifyAll();
            Assert.Equal(remainingHealth, monsters[0].Health.CurrentHealth);
            Assert.Equal(100, monsters[0].Health.MaximumHealth);
            Assert.Equal(0, monsters[0].Health.RegenerationRate);
        }

        [Fact(Skip = "1 test at a time")]
        public void ExecuteMonsterTurn()
        {
            // Given

            // When
            combatSystem.MonsterTurn();

            // Then
        }
    }
}