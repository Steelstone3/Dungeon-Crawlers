using DungeonCrawlers.Game.Characters.Enemies;
using Xunit;

namespace DungeonCrawlersTests.Game.Enemies.Races
{
    public class GoblinShould
    {
        [Fact]
        public void ContainAHeader()
        {
            var goblin = new Goblin();
            
            Assert.NotNull(goblin);
            Assert.Equal("Goblin", goblin.Name);
            Assert.NotNull(goblin.Description);
        }
    }
}