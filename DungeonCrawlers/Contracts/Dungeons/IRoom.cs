using System.Collections.Generic;
using DungeonCrawlers.Contracts.Encounters;

namespace DungeonCrawlers.Contracts.Dungeons
{
    public interface IRoom
    {
        IEnumerable<IEncounter> Encounters{get;}
    }
}
