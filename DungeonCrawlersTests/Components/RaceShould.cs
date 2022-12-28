using DungeonCrawlers.Components;
using Xunit;

namespace DungeonCrawlersTests.Components
{
    public class RaceShould
    {
        private readonly IRace race;

        public RaceShould()
        {
            race = new Race("Elf");
        }

        [Fact]
        public void ContainsName()
        {
            // Then
            Assert.Equal("Elf", race.Name);
        }
    }
}