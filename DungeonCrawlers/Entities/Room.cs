using System.Collections.Generic;

namespace DungeonCrawlers.Entities
{
    public class Room : IRoom
    {
        public Room(IEnumerable<IMonster> monsters)
        {
            Monsters = monsters;
        }

        public IEnumerable<IMonster> Monsters { get; }
    }
}