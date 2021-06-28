using System.Collections.Generic;
using DungeonCrawlers.Contracts.Dungeons;

namespace asdas
{
    public interface IDungeon
    {
        IEnumerable<IRoom> Rooms{get;}
    }
}