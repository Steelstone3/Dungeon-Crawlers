using DungeonCrawlers.Game.CombatClasses;
using DungeonCrawlers.Game.CombatClasses.CombatAbilities;
using Xunit;

namespace DungeonCrawlersTests.Combat
{
    public class CombatClassShould
    {
        [Fact]
        public void ContainAHeaderAndCombatAbilitiesForKnight()
        {
            var knight = new Knight();

            Assert.NotNull(knight.Name);
            Assert.NotNull(knight.Description);
            Assert.NotNull(knight.CombatAbilities);
            Assert.NotEmpty(knight.CombatAbilities);
        }

        [Fact]
        public void ContainAHeaderAndCombatAbilitiesForWizard()
        {
            var wizard = new Wizard();

            Assert.NotNull(wizard.Name);
            Assert.NotNull(wizard.Description);
            Assert.NotNull(wizard.CombatAbilities);
            Assert.NotEmpty(wizard.CombatAbilities);
        }
    }
}