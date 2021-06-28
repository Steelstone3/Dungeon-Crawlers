using DungeonCrawlers.Game.Exploration;
using Xunit;

namespace DungeonCrawlersTests.Exploration
{
    public class BiomeShould
    {
        [Fact]
        public void ContainsAHeaderForSwamp()
        {
            var swamp = new Swamp();

            Assert.NotNull(swamp.Name);
            Assert.NotNull(swamp.Description);
        }
    }
}