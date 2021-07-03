using DungeonCrawlers.Game.Characters.Races;
using Xunit;

namespace DungeonCrawlersTests.Game.Characters.Races
{
    public class HumanShould
    {
        [Fact]
        public void ContainAHeader()
        {
            var human = new Human();

            Assert.NotNull(human);
            Assert.Equal("Human", human.Name);
            Assert.NotNull(human.Description);
        } 
    }
}