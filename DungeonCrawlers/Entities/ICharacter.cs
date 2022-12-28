using DungeonCrawlers.Components;

namespace DungeonCrawlers.Entities
{
    public interface ICharacter
    {
        IName Name { get; }
        IRace Race { get; }
    }
}