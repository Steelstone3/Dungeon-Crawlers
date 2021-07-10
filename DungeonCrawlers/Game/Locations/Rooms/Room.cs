using System.Collections.Generic;
using DungeonCrawlers.Contracts.Game.Encounters;
using DungeonCrawlers.Contracts.Game.Locations;

namespace DungeonCrawlers.Game.Locations.Rooms
{
    public abstract class Room : IDungeonRoom
    {
        public IEnumerable<IHostileEncounter> Encounters { get; protected set; }
    }
}