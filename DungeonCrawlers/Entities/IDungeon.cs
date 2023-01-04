using System.Collections.Generic;
using DungeonCrawlers.Entities;

namespace DungeonCrawlersTests.Entities
{
    public interface IDungeon
    {
        IEnumerable<IRoom> Rooms { get; }
    }
}