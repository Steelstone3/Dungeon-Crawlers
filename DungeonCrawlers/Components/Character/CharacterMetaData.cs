using System.Reflection.Metadata.Ecma335;
using DungeonCrawlers.Components.Character.Race;

namespace DungeonCrawlers.Components.Character
{
    public class CharacterMetaData
    {
        private readonly CharacterName name;
        private readonly IRace race;

        public CharacterMetaData(CharacterName name, IRace race)
        {
            this.name = name;
            this.race = race;
        }

        public CharacterName Name => name;
        public IRace Race => race;
    }
}