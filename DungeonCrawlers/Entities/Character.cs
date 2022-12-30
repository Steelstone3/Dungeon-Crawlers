using DungeonCrawlers.Components;

namespace DungeonCrawlers.Entities
{
    public class Character : ICharacter
    {
        public Character(IName name, IRace race, IHealth health, IArmour armour, IWeapon weapon)
        {
            Name = name;
            Race = race;
            Health = health;
            Armour = armour;
            Weapon = weapon;
        }

        public IName Name { get; }
        public IRace Race { get; }
        public IHealth Health { get; }
        public IArmour Armour { get; }
        public IWeapon Weapon { get; }
    }
}