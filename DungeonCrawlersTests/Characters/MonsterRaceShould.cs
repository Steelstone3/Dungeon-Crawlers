using DungeonCrawlers.Game.Characters.MonsterRaces;
using Xunit;

namespace DungeonCrawlersTests.Characters
{
    public class MonsterRaceShould
    {
        [Fact]
        public void ContainsAHeaderForGoblins()
        {
            var goblin = new Goblin();

            Assert.NotNull(goblin.Name);
            Assert.NotNull(goblin.Description);
            Assert.NotNull(goblin.Biome);
        }
    }
}