using DungeonCrawlers.Game.Combat.CombatRoles;
using Xunit;

namespace DungeonCrawlersTests.Game.Combat.CombatRoles
{
    public class RogueShould
    {
        [Fact]
        public void PopulateClass()
        {
            var rogue = new Rogue();

            Assert.InRange(rogue.Health, 20, 50);
            Assert.NotNull(rogue);
            Assert.Equal("Rogue", rogue.Name);
            Assert.NotNull(rogue.Description);
            Assert.NotNull(rogue.CombatAbilities);
            Assert.NotEmpty(rogue.CombatAbilities);
            Assert.Equal(4, rogue.CombatAbilities.Count);

        }
    }
}