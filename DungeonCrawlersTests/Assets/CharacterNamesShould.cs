using DungeonCrawlers.Assets;
using Xunit;

namespace DungeonCrawlersTests.Assets
{
    public class CharacterNamesShould
    {
        [Fact]
        public void ContainPrefixes()
        {
            // Then
            Assert.NotEmpty(CharacterNames.Prefixes);
        }

        [Fact]
        public void ContainFirstNames()
        {
            // Then
            Assert.NotEmpty(CharacterNames.FirstNames);
        }

        [Fact]
        public void ContainSurname()
        {
            // Then
            Assert.NotEmpty(CharacterNames.Surname);
        }

        [Fact]
        public void ContainSuffix()
        {
            // Then
            Assert.NotEmpty(CharacterNames.Suffixes);
        }
    }
}