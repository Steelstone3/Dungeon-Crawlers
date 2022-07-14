using System.Reflection.Metadata.Ecma335;
using DungeonCrawlers.Components.Character.Race;

namespace DungeonCrawlers.Components.Character
{
    public class CharacterMetaData
    {
        private CharacterName name;
        private IRace race;

        public CharacterMetaData(CharacterName characterName, IRace characterRace)
        {
            this.name = characterName;
            this.race = characterRace;
        }

        public CharacterName Name => name;
        public IRace Race => race;
    }
}