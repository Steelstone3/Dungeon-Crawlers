using DungeonCrawlers.Components.Character;
using DungeonCrawlers.Components.Character.Race;
using Xunit;

namespace DungeonCrawlersTests.Components.Character
{
    public class CharacterMetaDataShould
    {
        [Fact]
        public void ContainCharacterMetaData()
        {
            var race = new Elf();
            var name = new CharacterName("Sir", "Alex", "Burgen", "The Brave");
            var metaData = new CharacterMetaData(name, race);

            Assert.Equal("Sir Alex Burgen The Brave", metaData.Name.GetCharacterName());
            Assert.Equal("Elf", metaData.Race.getCharacterRace());
        }
    }
}