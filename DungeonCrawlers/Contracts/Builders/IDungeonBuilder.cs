using System.Collections.Generic;
using DungeonCrawlers.Contracts.Game.Locations;

namespace DungeonCrawlers.Contracts.Builders
{
    public interface IDungeonBuilder
    {
        IList<IDungeon> BuildDungeons();
    }
}