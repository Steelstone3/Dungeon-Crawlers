using DungeonCrawlers.Components;
using DungeonCrawlers.Components.Interfaces;
using Xunit;

namespace DungeonCrawlersTests.Components
{
    public class RaceShould
    {
        private const string RACE_NAME = "Elf";
        private readonly IRace race;

        public RaceShould()
        {
            race = new Race(RACE_NAME);
        }

        [Fact]
        public void ContainsName()
        {
            // Then
            Assert.Equal(RACE_NAME, race.Name);
        }
    }
}