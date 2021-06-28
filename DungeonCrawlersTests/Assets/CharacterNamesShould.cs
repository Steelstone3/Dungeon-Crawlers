using DungeonCrawlers.Assets;
using Xunit;

namespace DungeonCrawlersTests.Assets
{
    public class CharacterNamesShould
    {
        [Fact]
        public void ContainFirstNames()
        {
            // Then
            Assert.NotEmpty(CharacterNames.FirstNames);
        }

        [Theory]
        [InlineData(1111, "Kontas")]
        [InlineData(-122, "Baakshi")]
        [InlineData(5656, "Hemm")]
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
        [InlineData(1111, "Katz")]
        [InlineData(-122, "Albertine")]
        [InlineData(5656, "Fox")]
        public void GetRandomSurname(int seed, string randomName)
        {
            // When
            string surname = CharacterNames.GetRandomSurname(seed);

            // Then
            Assert.Equal(randomName, surname);
        }
    }
}