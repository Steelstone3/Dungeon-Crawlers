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
    }
}