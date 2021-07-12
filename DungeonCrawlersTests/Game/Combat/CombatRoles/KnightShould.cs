using DungeonCrawlers.Game.Combat.CombatRoles;
using Xunit;

namespace DungeonCrawlersTests.Game.Combat.CombatRoles
{
    public class KnightShould
    {
        [Fact]
        public void ContainAHeader()
        {
            var knight = new Knight();

            Assert.NotNull(knight);
            Assert.Equal("Knight", knight.Name);
            Assert.NotNull(knight.Description);
            //Assert.NotNull(bard.CombatAbilities);
            //Assert.NotEmpty(bard.CombatAbilities);
        }
    }
}