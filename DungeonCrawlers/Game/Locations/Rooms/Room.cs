using System.Collections.Generic;
using DungeonCrawlers.Contracts.Game.Locations;

namespace DungeonCrawlers.Game.Locations.Rooms
{
    public abstract class Room : IRoom
    {
        public IEnumerable<IEncounter> Encounters { get; protected set; }
    }
}