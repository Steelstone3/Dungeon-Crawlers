using DungeonCrawlers.Components.Interfaces;
using DungeonCrawlers.Entities.Intefaces;

namespace DungeonCrawlers.Entities
{
    public class Monster : IMonster
    {
        public Monster(IName name, IRace race, IHealth health, IWeapon weapon)
        {
            Name = name;
            Race = race;
            Health = health;
            Weapon = weapon;
        }

        public IName Name { get; }
        public IRace Race { get; }
        public IHealth Health { get; }
        public IWeapon Weapon { get; }
    }
}