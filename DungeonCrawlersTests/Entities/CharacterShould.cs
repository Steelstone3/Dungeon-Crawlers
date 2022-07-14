using DungeonCrawlers.Components.Character;
using DungeonCrawlers.Components.Character.Race;
using DungeonCrawlers.Entities;
using Xunit;

namespace DungeonCrawlersTests.Entities
{
    public class CharacterShould{
        [Fact]
        public void ContainMetaData(){
            var race = new Elf();
            var name = new CharacterName("Sir", "Alex", "Burgen", "The Brave");
            var metaData = new CharacterMetaData(name, race);
            var character = new Character(metaData);

            Assert.Equal("Sir Alex Burgen The Brave", character.MetaData.Name.GetCharacterName());
            Assert.Equal("Elf", character.MetaData.Race.getCharacterRace());
        }
    }
}