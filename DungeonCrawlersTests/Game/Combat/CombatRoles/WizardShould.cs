using DungeonCrawlers.Game.Combat.CombatRoles;
using Xunit;

namespace DungeonCrawlersTests.Game.Combat.CombatRoles
{
    public class WizardShould
    {
        [Fact]
        public void PopulateClass()
        {
            var wizard = new Wizard();

            Assert.InRange(wizard.Health, 20, 50);
            Assert.NotNull(wizard);
            Assert.Equal("Wizard", wizard.Name);
            Assert.NotNull(wizard.Description);
            Assert.NotNull(wizard.CombatAbilities);
            Assert.NotEmpty(wizard.CombatAbilities);
            Assert.Equal(4, wizard.CombatAbilities.Count);
        }
    }
}