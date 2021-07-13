using Xunit;

namespace DungeonCrawlersTests.Game.Combat.DamageTypes
{
    public class BlugeonShould
    {
        [Fact]
        public void PopulateClass()
        {
            var blugeoning = new Blugeoning();

            Assert.Equal("Blugeoning", blugeoning.Name);
            Assert.NotNull(blugeoning.Name);
            Assert.NotNull(blugeoning.Description);
        }
    }
}