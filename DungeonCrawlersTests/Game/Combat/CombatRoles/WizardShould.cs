using DungeonCrawlers.Game.Combat.CombatRoles;
using Xunit;

namespace DungeonCrawlersTests.Game.Combat.CombatRoles
{
    public class WizardShould
    {
        [Fact]
        public void ContainAHeader()
        {
            var wizard = new Wizard();

            Assert.NotNull(wizard);
            Assert.Equal("Wizard", wizard.Name);
            Assert.NotNull(wizard.Description);
            //Assert.NotEmpty(wizard.CombatAbilities);
        }
    }
}