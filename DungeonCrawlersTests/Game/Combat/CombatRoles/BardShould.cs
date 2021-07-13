using DungeonCrawlers.Game.Combat.CombatRoles;
using Xunit;

namespace DungeonCrawlersTests.Game.Combat.CombatRoles
{
    public class BardShould
    {
        [Fact]
        public void PopulateClass()
        {
            var bard = new Bard();

            Assert.InRange(bard.Health, 20, 50);
            Assert.NotNull(bard);
            Assert.Equal("Bard", bard.Name);
            Assert.NotNull(bard.Description);
            Assert.NotNull(bard.CombatAbilities);
            Assert.NotEmpty(bard.CombatAbilities);
            Assert.Equal(4, bard.CombatAbilities.Count);
        }
    }
}