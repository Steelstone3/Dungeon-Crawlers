using System.Collections.Generic;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Game.Locations;

namespace DungeonCrawlers.States
{
    public interface ILocationController
    {
        IList<IDungeon> Dungeons { get; }
        void GenerateSettlements(ILocationBuilder locationBuilder);
        void GenerateDungeons(ILocationBuilder locationBuilder);
    }
}