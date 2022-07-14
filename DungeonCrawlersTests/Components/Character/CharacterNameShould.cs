using DungeonCrawlers.Components.Character;
using Xunit;

namespace DungeonCrawlersTests.Components.Character
{
    public class CharacterNameShould
    {
        [Fact]
        public void ContainCharacterMetaData()
        {
            var name = new CharacterName("Sir", "Alex", "Burgen", "The Brave");

            Assert.Equal("Sir Alex Burgen The Brave", name.GetCharacterName());
        }
    }
}