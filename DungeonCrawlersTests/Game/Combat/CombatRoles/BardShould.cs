using DungeonCrawlers.Game.Combat.CombatRoles;
using Xunit;

namespace DungeonCrawlersTests.Game.Combat.CombatRoles
{
    public class BardShould
    {
        [Fact]
        public void ContainAHeader()
        {
            var bard = new Bard();

            Assert.NotNull(bard);
            Assert.Equal("Bard", bard.Name);
            Assert.NotNull(bard.Description);
            //Assert.NotEmpty(bard.CombatAbilities);
        }
    }
}