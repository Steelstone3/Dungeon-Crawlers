using DungeonCrawlers.Components;

namespace DungeonCrawlers.Entities
{
    public interface IMonster
    {
        IName Name { get; }
        IRace Race { get; }
        IHealth Health { get; }
        IWeapon Weapon { get; }
    }
}