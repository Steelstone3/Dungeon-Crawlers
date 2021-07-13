using DungeonCrawlers.Game.Combat.CombatAbilities;
using Xunit;

namespace DungeonCrawlersTests.Game.Combat.CombatAbilities
{
    public class MaceBashShould
    {
        [Fact]
        public void PopulateClass()
        {
            var maceBash = new MaceBash();

            Assert.Equal("MaceBash", maceBash.Name);
            Assert.NotNull(maceBash.Name);
            Assert.NotNull(maceBash.Description);
            Assert.InRange(maceBash.Damage, 4, 8);
            Assert.NotNull(maceBash.DamageType);
        }
    }
}