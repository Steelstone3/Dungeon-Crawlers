using DungeonCrawlers.Components;

namespace DungeonCrawlers.Entities
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