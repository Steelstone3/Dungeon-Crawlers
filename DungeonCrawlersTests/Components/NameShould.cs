using DungeonCrawlers.Components;
using DungeonCrawlers.Components.Interfaces;
using Xunit;

namespace DungeonCrawlersTests.Components
{
    public class NameShould
    {
        private const string FIRST_NAME = "Jeff";
        private const string SURNAME = "Loomis";
        private readonly IName name;

        public NameShould()
        {
            name = new Name(FIRST_NAME, SURNAME);
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
    }
}