using DungeonCrawlers.Game.Combat.DamageEffects;
using Xunit;

namespace DungeonCrawlersTests.Combat
{
    public class DamageEffectShould
    {
        [Fact]
        public void ContainAHeaderAndEffectForBurning()
        {
            var burning = new Burning();

            Assert.NotNull(burning.Name);
            Assert.NotNull(burning.Description);
        }

        [Fact]
        public void ContainAHeaderAndEffectForElementalFire()
        {
            var bleeding = new Bleeding();

            Assert.NotNull(bleeding.Name);
            Assert.NotNull(bleeding.Description);
        }
    }
}