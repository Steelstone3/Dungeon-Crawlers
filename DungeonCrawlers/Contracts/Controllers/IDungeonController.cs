using System.Collections.Generic;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Game.Locations;

namespace DungeonCrawlers.Contracts.Controllers
{
    public interface IDungeonController
    {
        IList<IDungeon> Dungeons { get; set;}
        IDungeon CurrentDungeon { get; set; }
        void GenerateDungeons(IDungeonBuilder dungeonBuilder);
        void DisplayDungeons(IDisplayer displayer);
    }
}