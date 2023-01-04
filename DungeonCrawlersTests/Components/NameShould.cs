using DungeonCrawlers.Components;
using Xunit;

namespace DungeonCrawlersTests.Components
{
    public class NameShould
    {
        private const string PREFIX = "Dr";
        private const string FIRST_NAME = "Jeff";
        private const string SURNAME = "Loomis";
        private const string SUFFIX = "Jr";
        private readonly IName name;

        public NameShould()
        {
            name = new Name(PREFIX, FIRST_NAME, SURNAME, SUFFIX);
        }

        [Fact]
        public void ContainsPrefix()
        {
            // Then
            Assert.Equal(PREFIX, name.Prefix);
        }

        [Fact]
        public void ContainsFirstName()
        {
            // Then
            Assert.Equal(FIRST_NAME, name.FirstName);
        }

        [Fact]
        public void ContainsSurname()
        {
            // Then
            Assert.Equal(SURNAME, name.Surname);
        }

        [Fact]
        public void ContainsSuffix()
        {
            // Then
            Assert.Equal(SUFFIX, name.Suffix);
        }
    }
}