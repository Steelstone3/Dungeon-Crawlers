using System.Net.Security;
using DungeonCrawlers.Components;
using DungeonCrawlers.Components.Character;

namespace DungeonCrawlers.Entities
{
    public interface ICharacter
    {
        CharacterMetaData MetaData { get; }
        ILocation Location {get;}
        char GetDisplaySymbol();
    }
}