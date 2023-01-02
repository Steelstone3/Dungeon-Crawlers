using System.Collections.Generic;
using DungeonCrawlers.Entities;

namespace DungeonCrawlersTests.Entities
{
    public class Dungeon : IDungeon
    {
        public Dungeon(IEnumerable<IRoom> rooms)
        {
            Rooms = rooms;
        }

        public IEnumerable<IRoom> Rooms { get; }
    }
}