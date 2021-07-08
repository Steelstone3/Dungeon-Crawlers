using System.Collections.Generic;
using DungeonCrawlers.Game.Locations.Rooms;

namespace DungeonCrawlers.Contracts.Game.Locations
{
    public interface IRoom
    {
        IEnumerable<IEncounter> Encounters { get; }
    }
}