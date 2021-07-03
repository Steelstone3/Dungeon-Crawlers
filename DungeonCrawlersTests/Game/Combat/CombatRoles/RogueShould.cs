using DungeonCrawlers.Game.Combat.CombatRoles;
using Xunit;

namespace DungeonCrawlersTests.Game.Combat.CombatRoles
{
    public class RogueShould
    {
        [Fact]
        public void ContainAHeader()
        {
            var rogue = new Rogue();

            Assert.NotNull(rogue);
            Assert.Equal("Rogue", rogue.Name);
            Assert.NotNull(rogue.Description);
            //Assert.NotEmpty(rogue.CombatAbilities);
        }
    }
}