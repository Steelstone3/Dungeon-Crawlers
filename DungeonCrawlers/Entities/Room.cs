using System.Collections.Generic;
using DungeonCrawlers.Entities.Intefaces;

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