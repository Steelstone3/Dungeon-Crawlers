using DungeonCrawlers.Game.Combat.DamageTypes;
using Xunit;

namespace DungeonCrawlersTests.Combat
{
    public class DamageTypeShould
    {
        [Fact]
        public void ContainAHeaderAndEffectForSlashing()
        {
            var slashing = new Slashing();

            Assert.NotNull(slashing.Name);
            Assert.NotNull(slashing.Description);
            Assert.NotNull(slashing.DamageEffect);
        }

        [Fact]
        public void ContainAHeaderAndEffectForElementalFire()
        {
            var elementalFire = new ElementalFire();

            Assert.NotNull(elementalFire.Name);
            Assert.NotNull(elementalFire.Description);
            Assert.NotNull(elementalFire.DamageEffect);
        }
    }
}