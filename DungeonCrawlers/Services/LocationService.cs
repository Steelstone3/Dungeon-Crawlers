using System.Collections.Generic;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Locations;
using DungeonCrawlers.Contracts.Services;

namespace DungeonCrawlers.Services
{
    public class LocationService : ILocationService
    {
        public void DisplayLocations(IDisplayer displayer, IDungeonController dungeonController)
        {
            dungeonController.DisplayDungeons(displayer);
        }

        public IList<IDungeon> GenerateDungeons(IDungeonController dungeonController, IDungeonBuilder dungeonBuilder)
        {
            dungeonController.GenerateDungeons(dungeonBuilder);
            return dungeonController.Dungeons;
        }

        public IDungeon SelectLocation(IDisplayer displayer, IEnumerable<IDungeon> dungeons)
        {
            return null;
        }
    }
}