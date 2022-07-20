using DungeonCrawlers.Components;
using DungeonCrawlers.Components.Character;

namespace DungeonCrawlers.Entities
{
    public class Character : ICharacter
    {
        private readonly CharacterMetaData characterMetaData;

        public Character(CharacterMetaData characterMetaData)
        {
            this.characterMetaData = characterMetaData;
        }

        public CharacterMetaData MetaData => characterMetaData;

        public ILocation Location => new Location(1, 1);

        public char GetDisplaySymbol() => 'P';
    }
}