using DungeonCrawlers.Assets;
using Xunit;

namespace DungeonCrawlersTests.Assets
{
    public class MonsterNamesShould
    {
        [Fact]
        public void ContainFirstNames()
        {
            // Then
            Assert.NotEmpty(MonsterNames.FirstNames);
        }

        [Theory]
        [InlineData(1111, "Gendrid")]
        [InlineData(-122, "Fodark")]
        [InlineData(5656, "Fodark")]
        public void GetRandomFirstName(int seed, string randomName)
        {
            // When
            string firstName = MonsterNames.GetRandomFirstName(seed);

            // Then
            Assert.Equal(randomName, firstName);
        }

        [Fact]
        public void ContainSurname()
        {
            // Then
            Assert.NotEmpty(MonsterNames.Surnames);
        }

        [Theory]
        [InlineData(1111, "Gofer")]
        [InlineData(-122, "Genshin")]
        [InlineData(5656, "Genshin")]
        public void GetRandomSurname(int seed, string randomName)
        {
            // When
            string surname = MonsterNames.GetRandomSurname(seed);

            // Then
            Assert.Equal(randomName, surname);
        }

        [Fact]
        public void ContainMonsterRaces()
        {
            // Then
            Assert.NotEmpty(MonsterNames.Races);
        }

        [Theory]
        [InlineData(1111, "Henchman")]
        [InlineData(-122, "Bandit")]
        [InlineData(5656, "Goblin")]
        public void GetRandomMonsterRace(int seed, string randomRace)
        {
            // When
            string race = MonsterNames.GetRandomRace(seed);

            // Then
            Assert.Equal(randomRace, race);
        }
    }
}