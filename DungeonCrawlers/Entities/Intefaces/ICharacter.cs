using DungeonCrawlers.Components.Interfaces;

namespace DungeonCrawlers.Entities.Intefaces
{
    public interface ICharacter
    {
        IName Name { get; }
        IRace Race { get; }
        IHealth Health { get; }
        IArmour Armour { get; }
        IWeapon Weapon { get; }
    }
}