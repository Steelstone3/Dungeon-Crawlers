using DungeonCrawlers.Components.Character;
using DungeonCrawlers.Components.Character.Race;
using DungeonCrawlers.Systems;
using Xunit;

namespace DungeonCrawlersTests.Systems
{
    public class CharacterCreationShould
    {
        [Fact]
        public void CreateCharacter() {
            var characterRace = new Elf();
            var characterName = new CharacterName("Sir", "Alex", "Burgen", "The Brave");
            var characterMetaData = new CharacterMetaData(characterName, characterRace );
        
            var character = CharacterCreation.Create(characterMetaData);

            Assert.Equal("Sir Alex Burgen The Brave", character.MetaData.Name.GetCharacterName());
            Assert.Equal("Elf", character.MetaData.Race.getCharacterRace());
        }
    }
}