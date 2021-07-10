using System.Collections.Generic;
using DungeonCrawlers.Contracts.Game.Encounters;
using DungeonCrawlers.Game.Locations.Rooms;

namespace DungeonCrawlers.Contracts.Game.Locations
{
    public interface IDungeonRoom
    {
        IEnumerable<IEncounter> Encounters { get; }
    }
}