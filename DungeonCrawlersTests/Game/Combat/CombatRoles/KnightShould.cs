using DungeonCrawlers.Game.Combat.CombatRoles;
using Xunit;

namespace DungeonCrawlersTests.Game.Combat.CombatRoles
{
    public class KnightShould
    {
        [Fact]
        public void PopulateClass()
        {
            var knight = new Knight();

            Assert.InRange(knight.Health, 20, 50);
            Assert.NotNull(knight);
            Assert.Equal("Knight", knight.Name);
            Assert.NotNull(knight.Description);
            Assert.NotNull(knight.CombatAbilities);
            Assert.NotEmpty(knight.CombatAbilities);
            Assert.Equal(4, knight.CombatAbilities.Count);
        }
    }
}