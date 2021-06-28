using System.Collections.Generic;

namespace DungeonCrawlers.Entities.Intefaces
{
    public interface IDungeon
    {
        List<IRoom> Rooms { get; }
    }
}