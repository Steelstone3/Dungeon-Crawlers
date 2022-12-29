using DungeonCrawlers.Components;

namespace DungeonCrawlers.Entities
{
    public class Monster : IMonster
    {
        public Monster(IName name, IRace race, IHealth health)
        {
            Name = name;
            Race = race;
            Health = health;
        }

        public IName Name { get; }
        public IRace Race { get; }
        public IHealth Health { get; }
    }
}