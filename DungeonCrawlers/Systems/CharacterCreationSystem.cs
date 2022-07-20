using DungeonCrawlers.Components.Character;
using DungeonCrawlers.Components.Character.Race;
using DungeonCrawlers.Display;
using DungeonCrawlers.Entities;

namespace DungeonCrawlers.Systems
{
    public class CharacterCreationSystem : ICharacterCreationSystem
    {
        public ICharacter Create(IDisplayer displayer)
        {
            displayer.WriteLine("Character creation: ");
            var prefix = displayer.ReadString("Enter prefix: ");
            var firstName = displayer.ReadString("Enter first name: ");
            var surname = displayer.ReadString("Enter surname: ");
            var suffix = displayer.ReadString("Enter suffix: ");

            CharacterName characterName = new(prefix, firstName, surname, suffix);
            Elf race = new();
            CharacterMetaData characterMetaData = new(characterName, race);

            return new Character(characterMetaData);
        }
    }
}