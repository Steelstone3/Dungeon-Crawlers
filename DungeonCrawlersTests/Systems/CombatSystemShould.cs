using DungeonCrawlers.Components;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Systems;
using Xunit;

namespace DungeonCrawlersTests.Systems
{
    public class CombatSystemShould
    {
        private readonly ICombatSystem combatSystem = new CombatSystem();

        [Fact]
        public void ExecutePlayerTurn()
        {
            // Given
            ICharacter character = new Character(null, null, new Health(100, 100, 25), new Armour(100, 100, 5), new Weapon(null, null, 25, 5));
            IMonster monster = new Monster(null, null, new Health(100, 100, 0));
            
            // When
            combatSystem.PlayerTurn(character, monster);

            // Then
            Assert.Equal(75, monster.Health.CurrentHealth);
            Assert.Equal(100, monster.Health.MaximumHealth);
            Assert.Equal(0, monster.Health.RegenerationRate);
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