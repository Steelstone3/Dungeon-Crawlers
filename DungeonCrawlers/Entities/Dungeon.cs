using System.Collections.Generic;
using DungeonCrawlers.Entities;

namespace DungeonCrawlersTests.Entities
{
    public class Dungeon : IDungeon
    {
        public Dungeon(List<IRoom> rooms)
        {
            Rooms = rooms;
        }

        public List<IRoom> Rooms { get; }
    }
}