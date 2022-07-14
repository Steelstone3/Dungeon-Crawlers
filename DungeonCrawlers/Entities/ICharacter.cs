using DungeonCrawlers.Components.Character;

namespace DungeonCrawlers.Entities
{
    public interface ICharacter
    {
        CharacterMetaData MetaData { get; }
    }
}