using System.Collections.Generic;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Locations;

namespace DungeonCrawlers.Contracts.Services
{
    public interface IDungeonCreationService
    {
        IList<IDungeon> GenerateDungeons(IDungeonController dungeonController, IDungeonBuilder dungeonBuilder);
    }
}