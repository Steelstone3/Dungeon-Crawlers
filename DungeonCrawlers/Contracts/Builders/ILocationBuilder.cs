using System.Collections.Generic;
using DungeonCrawlers.Contracts.Game.Locations;

namespace DungeonCrawlers.Contracts.Builders
{
    public interface ILocationBuilder
    {
        IList<IDungeon> BuildDungeons();
    }
}