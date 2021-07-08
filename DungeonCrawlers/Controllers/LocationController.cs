using System.Collections.Generic;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Game.Locations;
using DungeonCrawlers.States;

namespace DungeonCrawlers.Controllers
{
    public class LocationController : ILocationController
    {
        public IList<IDungeon> Dungeons { get; private set; } = new List<IDungeon>();

        public void GenerateDungeons(ILocationBuilder locationBuilder)
        {
            Dungeons = locationBuilder.BuildDungeons();
        }

        public void GenerateSettlements(ILocationBuilder locationBuilder)
        {

        }
    }
}