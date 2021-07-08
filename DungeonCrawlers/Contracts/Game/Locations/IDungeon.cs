using System.Collections.Generic;

namespace DungeonCrawlers.Contracts.Game.Locations
{
    public interface IDungeon
    {
        IList<IRoom> Rooms { get; }
    }
}