using DungeonCrawlers.Game.Characters.Enemies;
using DungeonCrawlers.Game.Enemies;
using Xunit;

namespace DungeonCrawlersTests.Game.Enemies
{
    public class MonsterShould
    {
        [Fact]
        public void GenerateAMonsterFromARace()
        {
            var monster = new Monster(new Goblin());

            Assert.NotNull(monster);
            Assert.NotNull(monster.Name);
            Assert.NotNull(monster.Race);
        }
    }
}