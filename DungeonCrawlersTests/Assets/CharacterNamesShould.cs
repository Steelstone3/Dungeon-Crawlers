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

        [Theory]
        [InlineData(1111, "Master")]
        [InlineData(-122, "Count")]
        [InlineData(5656, "Lady")]
        public void GetRandomPrefix(int seed, string randomName)
        {
            // When
            string prefix = CharacterNames.GetRandomPrefix(seed);

            // Then
            Assert.Equal(randomName, prefix);
        }

        [Fact]
        public void ContainFirstNames()
        {
            // Then
            Assert.NotEmpty(CharacterNames.FirstNames);
        }

        [Theory]
        [InlineData(1111, "Bob")]
        [InlineData(-122, "April")]
        [InlineData(5656, "Bill")]
        public void GetRandomFirstName(int seed, string randomName)
        {
            // When
            string firstName = CharacterNames.GetRandomFirstName(seed);

            // Then
            Assert.Equal(randomName, firstName);
        }

        [Fact]
        public void ContainSurname()
        {
            // Then
            Assert.NotEmpty(CharacterNames.Surname);
        }

        [Theory]
        [InlineData(1111, "Harken")]
        [InlineData(-122, "Billiston")]
        [InlineData(5656, "Bobbinton")]
        public void GetRandomSurname(int seed, string randomName)
        {
            // When
            string surname = CharacterNames.GetRandomSurname(seed);

            // Then
            Assert.Equal(randomName, surname);
        }

        [Fact]
        public void ContainSuffix()
        {
            // Then
            Assert.NotEmpty(CharacterNames.Suffixes);
        }

        [Theory]
        [InlineData(1111, "Jr")]
        [InlineData(-122, "")]
        [InlineData(5656, "III")]
        public void GetRandomSuffix(int seed, string randomName)
        {
            // When
            string suffix = CharacterNames.GetRandomSuffix(seed);

            // Then
            Assert.Equal(randomName, suffix);
        }
    }
}