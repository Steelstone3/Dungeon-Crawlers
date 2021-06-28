using DungeonCrawlers.Components.Interfaces;

namespace DungeonCrawlers.Entities.Intefaces
{
    public interface IMonster
    {
        IName Name { get; }
        IRace Race { get; }
        IHealth Health { get; }
        IWeapon Weapon { get; }
    }
}