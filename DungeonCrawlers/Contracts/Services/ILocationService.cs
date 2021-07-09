using System.Collections.Generic;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Locations;

namespace DungeonCrawlers.Contracts.Services
{
    public interface ILocationService : IDungeonCreationService
    {
        void DisplayLocations(IDisplayer displayer, IDungeonController dungeonController);
        IDungeon SelectLocation(IDisplayer displayer, IEnumerable<IDungeon> dungeons);

    }
}