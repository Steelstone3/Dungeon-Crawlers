using System.Collections.Generic;
using DungeonCrawlers.Entities;

namespace DungeonCrawlersTests.Entities
{
    public interface IDungeon
    {
        List<IRoom> Rooms { get; }
    }
}